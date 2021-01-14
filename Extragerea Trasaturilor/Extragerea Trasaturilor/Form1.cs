using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Extragerea_Trasaturilor
{
    public partial class Form1 : Form
    {
        List<string> globalDictionary;
        List<string> stopwords;
        private PorterStemmer porterStemmer;
        List<Article> ListaXml = new List<Article>();
        List<Dictionary<int, int>> vectRar = new List<Dictionary<int, int>>();
        List<Tuple<string, string>> docInfo = new List<Tuple<string, string>>(); 



        

        public Form1()
        {
            InitializeComponent();
            globalDictionary = new List<string>();
            stopwords = new List<string>();
            porterStemmer = new PorterStemmer();

            
        }

        //======Metode pentru a extrage cuvintele din string===============
        //luate de pe :https://stackoverflow.com/questions/4970538/how-to-get-all-words-of-a-string-in-c
        // la data de : 08.11.2020

        static string[] GetWords(string input)
        {
            MatchCollection matches = Regex.Matches(input, @"\b[\w']*\b");

            var words = from m in matches.Cast<Match>()
                        where !string.IsNullOrEmpty(m.Value)
                        select TrimSuffix(m.Value);

            return words.ToArray();
        }

        static string TrimSuffix(string word)
        {
            int apostropheLocation = word.IndexOf('\'');
            if (apostropheLocation != -1)
            {
                word = word.Substring(0, apostropheLocation);
            }

            return word;
        }

        //======End metode pentru a extrage cuvintele din string===============

        public void ReadFileInList(out List<string> lines, string filePath)
        {
            lines = new List<string>();
            string line;
            StreamReader file = new StreamReader(filePath);

            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);

            }
        }
        public bool IsStopword(string word)
        {
            string lowWord = word.ToLower(); // fac orice cuvant sa aiba litere mici pentru 
                                             //a verifica indiferent de marimea literelor
                                             // adica chiar daca incepe cu litera mare

            foreach (string s in stopwords)
            {
                if (s == lowWord)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsInGlobalDictionary(string word)
        {
            foreach (string str in globalDictionary)
            {
                if (str == word)
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOfTheWordInGlobalDictionary(string word)
        {
            return (globalDictionary.IndexOf(word)); // returneaza index-ul cuv din globalDictionary
        }

        public void RareVector(Dictionary<int, int> dictionary, int key)
        {

            if (dictionary.ContainsKey(key))
            {
                int tempValue;
                dictionary.TryGetValue(key, out tempValue);
                dictionary[key] = tempValue + 1; //verific daca exista cheia si daca da o incrementez
                                                 //cheia(key) este indexul din vectorul global globalDictionary

            }
            else
            {
                dictionary.Add(key, 1); //daca nu exista cheia o adaug cu valuarea 1, deoarece aprare 1 data cuvantul
            }

        }

        public List<Dictionary<int, int>> CreateGlobalVectorAndRareVectors(List<Article> articleList)
        {
            List<Dictionary<int, int>> vectoriRari = new List<Dictionary<int, int>>();

            string filePath = @"./../../InputData/stopwords.txt";
            ReadFileInList(out stopwords, filePath); //citire si punere in lista a tuturor stepwords
                                                     //fac acest lucru aici ca sa nu citesc fisierul de fiecare data
                                                     //cand trebuie sa verific daca un cuvant este sau nu stopword
                                                     //Citesc 1 data si pun intr-o lista cu care lucrez mereu
                                                     //Lista este o lista globala de string "List<string> stopwords"


            foreach (Article article in articleList)
            {
                Dictionary<int, int> tempDictionary = new Dictionary<int, int>();
                string[] titleWords = GetWords(article.GetTitle());
                string[] textWords = GetWords(article.GetText());

                //aici se aplica algoritmul pentru stringurile din titulu articolului
                foreach (string str in titleWords)
                {
                    if (!IsStopword(str)) //verifica daca este sau nu Stopword
                    {
                        string wordRoot = porterStemmer.StemWord(str);//extrage radacina cuvantului
                        if (!IsInGlobalDictionary(wordRoot)) //verifica daca exista deja in vectorul global
                        {
                            globalDictionary.Add(wordRoot);
                        }

                        int indexGlobalDictionary = IndexOfTheWordInGlobalDictionary(wordRoot);
                        RareVector(tempDictionary, indexGlobalDictionary); //incrementeaza sau introduce in vector rar

                    }
                }

                //aici se aplica algoritmul pentru stringurile din textul articolului
                foreach (string str in textWords)
                {
                    if (!IsStopword(str)) //verifica daca este sau nu Stopword
                    {
                        string wordRoot = porterStemmer.StemWord(str);//extrage radacina cuvantului
                        if (!IsInGlobalDictionary(wordRoot)) //verifica daca exista deja in vectorul global
                        {
                            globalDictionary.Add(wordRoot);
                        }

                        int indexGlobalDictionary = IndexOfTheWordInGlobalDictionary(wordRoot);
                        RareVector(tempDictionary, indexGlobalDictionary); //incrementeaza sau introduce in vector rar

                    }
                }
                vectoriRari.Add(tempDictionary);
            }

            return vectoriRari;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListaXml = Article.VerificareSiInstantiereFisiereXml("Reuters_34");
            vectRar = CreateGlobalVectorAndRareVectors(ListaXml);

            using (StreamWriter fisier = new StreamWriter(@"./../../InputData/trasaturiExtraseFisiereXML.txt"))

                for (var i = 0; i < vectRar.Count(); i++)
                {
                    string linie;
                    if (i == 0)
                    {
                        linie = "@data\n\n";
                    }
                    else
                    {
                        linie = "";
                    }
                    foreach (KeyValuePair<int, int> kvp in vectRar[i])
                    {
                        linie = linie + kvp.Key.ToString() + ":" + kvp.Value.ToString() + " ";
                    }
                    List<string> temp = ListaXml[i].GetClassCodes();
                    linie = linie + "#";
                    foreach (string v in temp)
                    {
                        linie = linie + " " + v;
                    }
                    linie = linie + " # " + ListaXml[i].GetData_Set();
                    docInfo.Add(Tuple.Create(temp[0], ListaXml[i].GetData_Set()));
                    fisier.WriteLine(linie);

                }

            List<double> gainList = Gain();
            MessageBox.Show("File is write", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        }

        public double Entropy(Dictionary<string, int> repartitiaPeClase, double nrTotalElmente)
        {
            double valEntropie = 0;
            foreach (KeyValuePair<string, int> kvp in repartitiaPeClase)
            {
                double logarithm = Math.Log(((double)kvp.Value / nrTotalElmente), 2);
                valEntropie -= ((double)kvp.Value / nrTotalElmente) * logarithm;
            }

            return valEntropie;
        }

        public Dictionary<int, int> NormalizareBinara(Dictionary<int, int> vectorRar)
        {

            Dictionary<int, int> vectorNormalizat = new Dictionary<int, int>();

            foreach (KeyValuePair<int, int> kvp in vectorRar)
            {
                if (kvp.Value == 0)
                {
                    vectorNormalizat[kvp.Key] = 0;
                }
                else 
                {
                    vectorNormalizat[kvp.Key] = 1;
                }
                
            }

            return vectorNormalizat;
        }
        public List<Tuple<double, double>> EntropyWordInClass(List<Tuple<string, string>> dataInfo)
        {
            List<Tuple<double, double>> entropyList = new List<Tuple<double, double>>();

            foreach (var cuv in globalDictionary)
            {
                Dictionary<string, int> tempDictionary = new Dictionary<string, int>();
                int key = globalDictionary.IndexOf(cuv);
                int count = 0; //de cate ori apare cuvantul in toate documentele

                foreach (var doc in vectRar)
                {
                    if (doc.ContainsKey(key))
                    {
                        int indexDoc = vectRar.IndexOf(doc);

                        if (tempDictionary.ContainsKey(dataInfo[indexDoc].Item1))
                        {
                            int tempValue;
                            tempDictionary.TryGetValue(dataInfo[indexDoc].Item1, out tempValue);
                            tempDictionary[dataInfo[indexDoc].Item1] = tempValue + 1;
                            count++;

                        }
                        else
                        {
                            tempDictionary.Add(dataInfo[indexDoc].Item1, 1);
                            count++;
                        }
                    }
                }

                entropyList.Add(Tuple.Create(Entropy(tempDictionary, count), Convert.ToDouble(count)));
            }

            return entropyList;

        }

        public List<Tuple<double, double>> EntropyWordNotInClass(List<Tuple<string, string>> dataInfo)
        {
            List<Tuple<double, double>> entropyList = new List<Tuple<double, double>>();

            foreach (var cuv in globalDictionary)
            {
                Dictionary<string, int> tempDictionary = new Dictionary<string, int>();
                int key = globalDictionary.IndexOf(cuv);
                int count = 0; //de cate ori apare cuvantul in toate documentele

                foreach (var doc in vectRar)
                {
                    if (!doc.ContainsKey(key))
                    {
                        int indexDoc = vectRar.IndexOf(doc);

                        if (tempDictionary.ContainsKey(dataInfo[indexDoc].Item1))
                        {
                            int tempValue;
                            tempDictionary.TryGetValue(dataInfo[indexDoc].Item1, out tempValue);
                            tempDictionary[dataInfo[indexDoc].Item1] = tempValue + 1;
                            count++;

                        }
                        else
                        {
                            tempDictionary.Add(dataInfo[indexDoc].Item1, 1);
                            count++;
                        }
                    }
                }
                entropyList.Add(Tuple.Create(Entropy(tempDictionary, count), Convert.ToDouble(count)));
            }

            return entropyList;

        }
        public double EntropieTotala(List<Tuple<string, string>> dataInfo)
        {
            Dictionary<string, int> repartitiePeClase = new Dictionary<string, int>();
          
            foreach (var info in dataInfo)
            {
                string keyClass = info.Item1;
                if (repartitiePeClase.ContainsKey(keyClass))
                {
                    int tempValue;
                    repartitiePeClase.TryGetValue(keyClass, out tempValue);
                    repartitiePeClase[keyClass] = tempValue + 1;
                }
                else
                {
                    repartitiePeClase.Add(keyClass, 1);
                    
                }
            }
            
            return Entropy(repartitiePeClase, dataInfo.Count);
        }

        public List<double> Gain()
        {
            List<double> gainList = new List<double>();
            List<Tuple<double, double>> entropyWordInClass = EntropyWordInClass(docInfo);
            List<Tuple<double, double>> entropyWordNotInClass = EntropyWordNotInClass(docInfo);
            double totalEntropy = EntropieTotala(docInfo);

            foreach (var word in globalDictionary)
            {
                int index = globalDictionary.IndexOf(word);
                double inClass = (entropyWordInClass[index].Item2 / (entropyWordInClass[index].Item2 + entropyWordNotInClass[index].Item2)) * entropyWordInClass[index].Item1;
                double notInClass= (entropyWordNotInClass[index].Item2 / (entropyWordInClass[index].Item2 + entropyWordNotInClass[index].Item2)) * entropyWordNotInClass[index].Item1;
                double gain = totalEntropy - inClass - notInClass;
                gainList.Add(gain);
            }
            return gainList; 
        }
    }
}



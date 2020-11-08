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
        private List<string> stopwords;

        private PorterStemmer porterStemmer;

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

        public void ReadFileInList(out List<string> lines,string filePath)
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

        public void RareVectors(List<Dictionary<int, int>> vectoriRari,int key)
        {
            foreach (Dictionary<int, int> v in vectoriRari)
            {
                if (v.ContainsKey(key))  
                {
                    v[key]++; //verific daca exista cheia si daca da o incrementez
                                    //cheia(key) este indexul din vectorul global globalDictionary
                }
                else
                {
                    v.Add(key, 0); //daca nu exista cheia o adaug cu valuarea 1, deoarece aprare 1 data cuvantul
                }
            }
        }

        public List<Dictionary<int, int>>CreateGlobalVectorAndRareVectors(List<Article> articleList)
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
                        RareVectors(vectoriRari, indexGlobalDictionary); //incrementeaza sau introduce in vector rar
                        
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
                        RareVectors(vectoriRari, indexGlobalDictionary); //incrementeaza sau introduce in vector rar

                    }
                }

            }

            return vectoriRari;
        }

    }
}

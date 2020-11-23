using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace Extragerea_Trasaturilor
{
    public class Article
    {
        private string Tile;
        private string Text;
        private string Data_Set;
        private List<string> ClassCodes = new List<string>();


        public Article(string tile1, string text1, List<string> classCodes1, string dataset)
        {
            Tile = tile1;
            Text = text1;
            ClassCodes = classCodes1;
            Data_Set = dataset;
        }

        public string GetTitle()
        {
            return Tile;
        }

        public string GetText()
        {
            return Text;
        }

        public List<string> GetClassCodes()
        {
            return ClassCodes;
        }

        public void SetTitle(string tile)
        {
            Tile = tile;
        }

        public void SetText(string text)
        {
            Text = text;
        }

        public void SetClassCodes(List<string> classCodes)
        {
            ClassCodes = classCodes;
        }

        public static string GetXmlNodeContentByName(XmlDocument Obj, string NumeNod)
        {
            string Info = "";
            
            foreach(XmlNode xmlNode in Obj)
            {
                Info += xmlNode[NumeNod].InnerText;
            }

            return Info;
        }

        public static List<string> GetClassCodesFromXml(XmlDocument Obj)
        {
            List<string> NoduriCodesCareContinClasaBipTopics = new List<string>();
            

            foreach (XmlNode xmlNode in Obj.SelectNodes("codes"))
            {
                if (xmlNode.Attributes.Equals("bip:topics:1.0"))
                {
                    string aux = xmlNode.ChildNodes.ToString();
                    NoduriCodesCareContinClasaBipTopics.Add(aux);
                }
            }


            return NoduriCodesCareContinClasaBipTopics;
        }

        public static List<Article> VerificareSiInstantiereFisiereXml(string CaleRelativaCatreFolderCuFisiere)
        {
            List<Article> ListaFisiereXml = new List<Article>();
            string cale = "./../../InputData/" + CaleRelativaCatreFolderCuFisiere;
            string folder = ""; 
            XmlDocument xmlDocument = new XmlDocument();

            if (CaleRelativaCatreFolderCuFisiere.Contains("Training"))
            {
                folder = "training";
            }
            if (CaleRelativaCatreFolderCuFisiere.Contains("Testing"))
            {
                folder = "testing";
            }

            string[] AllDirectories = Directory.GetFiles(cale, "*", SearchOption.AllDirectories);
            
            for(var i = 0; i < AllDirectories.Length; i++)
            {
                if(AllDirectories[i].EndsWith("xml"))
                {
                    xmlDocument.LoadXml(AllDirectories[i]);                 
                    Article obj = new Article(GetXmlNodeContentByName(xmlDocument,"title"),
                                              GetXmlNodeContentByName(xmlDocument,"text"),
                                              GetClassCodesFromXml(xmlDocument),
                                              folder);

                    ListaFisiereXml.Add(obj);
                    folder = "";
                }
            }


            return ListaFisiereXml;
        }
    }
}

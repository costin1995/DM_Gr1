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

        public string GetData_Set()
        {
            return Data_Set;
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

        public void SetData_Set(string dataset)
        {
            Data_Set = dataset;
        }

        public void SetText(string text)
        {
            Text = text;
        }

        public void SetClassCodes(List<string> classCodes)
        {
            ClassCodes = classCodes;
        }

        public static string GetXmlNodeContentByName(XmlDocument obj, string numeNod)
        {
            string info = "";

            XmlNode nodeTitle = obj.DocumentElement.SelectSingleNode(numeNod);
            info += nodeTitle.InnerText;

            return info;
        }

        public static List<string> GetClassCodesFromXml(XmlDocument obj)
        {
            List<string> noduriCodesCareContinClasaBipTopics = new List<string>();

            XmlNode nodMetadataParinteCodes = obj.DocumentElement.SelectSingleNode("metadata");
            XmlNodeList noduriCodesCopilMetadata = nodMetadataParinteCodes.ChildNodes;

            foreach (XmlNode nodCodes in noduriCodesCopilMetadata)
            {
                foreach (XmlAttribute atributNoduCodes in nodCodes.Attributes)
                {
                    if (atributNoduCodes.Value.Equals("bip:topics:1.0"))
                    {
                        XmlNodeList noduriCopilCodes = nodCodes.ChildNodes;

                        foreach (XmlNode noduriCode in noduriCopilCodes)
                        {
                            foreach (XmlAttribute atributNoduriCode in noduriCode.Attributes)
                            {
                                string auxString = atributNoduriCode.Value;
                                noduriCodesCareContinClasaBipTopics.Add(auxString);
                            }
                        }
                    }
                }
            }

            return noduriCodesCareContinClasaBipTopics;
        }

        public static List<Article> VerificareSiInstantiereFisiereXml(string caleRelativaCatreFolderCuFisiere)
        {
            List<Article> listaFisiereXml = new List<Article>();
            string cale = "./../../InputData/" + caleRelativaCatreFolderCuFisiere;
            string folder = "";
            XmlDocument xmlDocument = new XmlDocument();
            string[] allDirectories = Directory.GetFiles(cale, "*", SearchOption.AllDirectories);

            for (var i = 0; i < allDirectories.Length; i++)
            {
                if (allDirectories[i].EndsWith("XML"))
                {
                    if (allDirectories[i].Contains("Training"))
                    {
                        folder = "training";
                    }
                    if (allDirectories[i].Contains("Testing"))
                    {
                        folder = "testing";
                    }

                    xmlDocument.Load(allDirectories[i]);
                    Article obj = new Article(GetXmlNodeContentByName(xmlDocument, "title"),
                                              GetXmlNodeContentByName(xmlDocument, "text"),
                                              GetClassCodesFromXml(xmlDocument),
                                              folder);

                    listaFisiereXml.Add(obj);
                    folder = "";
                }
            }

            return listaFisiereXml;
        }
    }
}

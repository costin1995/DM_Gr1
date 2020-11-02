using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extragerea_Trasaturilor
{
    class Article
    {
        public string Tile;
        private string Text;
        private List<string> ClassCodes = new List<string>();

        public Article(string tile1, string text1, List<string> classCodes1)
        {
            Tile = tile1;
            Text = text1;
            ClassCodes = classCodes1;
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
            Tile=tile;
        }

        public void SetText(string text)
        {
            Text=text;
        }

        public void SetClassCodes(List<string> classCodes)
        {
            ClassCodes=classCodes;
        }


    }
}

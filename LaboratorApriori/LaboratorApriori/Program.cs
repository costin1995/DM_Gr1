using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorApriori
{
    class Program
    {
        static string[,] ReadCSVFile(string fisier)
        {
            string cale = @"./../../InputData/" + fisier;
            

            string[] dateFisier = System.IO.File.ReadAllLines(cale);

            int randuri = dateFisier.Length;
            int coloane = dateFisier[0].Split(',').Length;

            string[,] continutCelule = new string[randuri, coloane];

            for(int i = 0; i < randuri; i++)
            {
                string[] linie = dateFisier[i].Split(',');
                for(int j = 0; j < coloane; j++)
                {
                    continutCelule[i, j] = linie[j];
                    
                }

            }

            return continutCelule;
        }

            int nrRows = mat.GetLength(0);
        static void Main(string[] args)
        {
            Console.WriteLine("!!!!Hello World si spor la scris, dragi mei coechipieri!!!!!");
            ReadCSVFile(@"test_59_2.csv");
            Console.ReadLine();
        }
    }
}

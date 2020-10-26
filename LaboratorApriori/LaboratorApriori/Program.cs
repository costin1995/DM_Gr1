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

        static Dictionary<string, int> GetStatistics(string[,] mat)
        {

            Dictionary<string, int> aux = new Dictionary<string, int>();
            int nrRows = mat.GetLength(0);
            int nrCols = mat.GetLength(1);

            for (int i = 0; i < nrRows; i++)
            {
                for (int j = 0; j < nrCols; j++)
                {
                    if (mat[i, j] != "-" && !aux.ContainsKey(mat[i, j]))
                    {
                        aux.Add(mat[i, j], 1);
                    }
                    else if (aux.ContainsKey(mat[i, j]))
                    {
                        aux[mat[i, j]]++;
                    }
                }
            }


            return aux;
        }

        static string[,]EliminaCapTabel(string[,] matrice)
        {
            int rand = matrice.GetLength(0)-1;
            int coloana = matrice.GetLength(1)-1;
            string[,] matx = new string[rand,coloana];

            for(int i =0;i<rand;i++)
            {
                for(int j=0;j<coloana;j++)
                {
                    if(matrice[i+1,j+1] = "?")
                    {
                        matrice[i+1,j+1]= "-";
                    }
                    
                    matx[i,j]=matrice[i+1,j+1];
                    
                }
            }

            return matx;

        }

        static void Main(string[] args)
        {
            Console.WriteLine("!!!!Hello World si spor la scris, dragi mei coechipieri!!!!!");
            ReadCSVFile(@"test_59_2.csv");
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    internal class Enigme3
    {
        public void ResolutionEnigme()
        {
            String line;
            try
            {
                long password = 0; //nombre de passage à zéro
                //long Solution = 0;

                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Users\\Mathieu\\Documents\\GitHub\\calendrier de l'event\\input.txt");

                //Read the first line of text
                line = sr.ReadLine();

                //long countTotalJoltage = 0;

                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    //Console.WriteLine(line);

                    //Variable commune
                    int tailleligne = line.Length;
                    string[] voltage = new string[12];
                    int[] emplacement = new int[12];
                    int memindex = 0;
                    string resultat = null;

                    // solution part2
                    bool suite = true;
                    for (int i = 12; (tailleligne - memindex != i) && (i!=0) && (suite == true); i--)
                    {
                        string nb = line.Substring(memindex, 1);
                        memindex++;
                        bool mod = false;
                        for (int j = memindex; (j <= tailleligne - i) && (nb != "9"); j++)
                        {
                                if (Int32.Parse(nb) < Int32.Parse(line.Substring(j,1))) 
                                { 
                                    nb = line.Substring(j,1);
                                    memindex = j;
                                    mod = true;
                                    if (j == tailleligne) suite = false;
                                }
                        }
                        resultat = resultat + nb;
                        if (mod && suite) memindex++;
                    }
                    if (resultat.Length != 12) resultat = resultat + line.Substring(memindex);


                    //solution part1
                    //string nb1 = line.Substring(0, 1);
                    //for (int i = 1; (i < tailleligne - 1) && (nb1 != "9"); i++)
                    //{
                    //    if (Int32.Parse(nb1) < Int32.Parse(line.Substring(i,1))) 
                    //    { 
                    //        nb1 = line.Substring(i,1);
                    //        memindex = i;
                    //    }
                    //}
                    //
                    //string nb2 = line.Substring(memindex + 1, 1);
                    //for (int i = memindex + 2; (i < tailleligne) && (nb2 != "9"); i++)
                    //{
                    //    if (Int32.Parse(nb2) < Int32.Parse(line.Substring(i, 1)))
                    //    {
                    //        nb2 = line.Substring(i, 1);
                    //    }
                    //}
                    //
                    //int resultat = Int32.Parse(nb1+nb2);

                    Console.WriteLine($"Le résultat de la caisse est {resultat}");
                    password = password + Int64.Parse(resultat);

                    //Read the next line
                    line = sr.ReadLine();
                }

                //écrit le résultat
                Console.WriteLine($"La solution est {password}");
                //Solution = countTotalJoltage;
                //Console.WriteLine($"Solution = {Solution}");

                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}

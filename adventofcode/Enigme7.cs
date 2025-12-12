using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    internal class Enigme7
    {
        public void ResolutionEnigme()
        {
            String line;
            try
            {
                long password = 0;
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Users\\Mathieu\\Documents\\GitHub\\calendrier de l'event\\input.txt");

                //Read the first line of text
                line = sr.ReadLine();
                List<int> lstIndex = new List<int>();
                lstIndex.Add(line.IndexOf('S'));
                List<string> lineAvant = new List<string>();
                foreach (char i in line)
                    lineAvant.Add(Convert.ToString(i));

                //initaliser la première ligne
                //Read the next line
                line = sr.ReadLine();
                List<string> lineActu = new List<string>();
                foreach (char i in line)
                    lineActu.Add(Convert.ToString(i));
                lineActu[lstIndex[0]] = "1";

                //Read the next line
                lineAvant = lineActu;
                line = sr.ReadLine();


                //Continue to read until you reach end of file
                while (line != null)
                {
                    lineActu = new List<string>();
                    foreach (char i in line)
                        lineActu.Add(Convert.ToString(i));
                    List<int> lstIndexTampon = new List<int>();
                    long sommePassage = 0;
                    //remplace l'élement juste en dessus d'un rayon
                    foreach (int index in lstIndex)
                    {
                        switch (lineActu[index])
                        {
                            case ("."):
                                lineActu[index] = lineAvant[index];
                                lstIndexTampon.Add(index);
                                break;
                            case ("^"):
                                if (lineActu[index - 1] == ".")
                                    sommePassage = Int64.Parse(lineAvant[index]);
                                else
                                    sommePassage = Int64.Parse(lineActu[index - 1]) + Int64.Parse(lineAvant[index]);

                                lineActu[index - 1] = Convert.ToString(sommePassage);
                                lstIndexTampon.Add(index - 1);

                                if (lineActu[index + 1] == ".")
                                    sommePassage = Int64.Parse(lineAvant[index]);
                                else
                                    sommePassage = Int64.Parse(lineActu[index + 1]) + Int64.Parse(lineAvant[index]);

                                lineActu[index + 1] = Convert.ToString(sommePassage);
                                lstIndexTampon.Add(index + 1);
                                //password++;
                                break;
                            default:
                                sommePassage = Int64.Parse(lineActu[index]) + Int64.Parse(lineAvant[index]);
                                lineActu[index] = Convert.ToString(sommePassage);
                                lstIndexTampon.Add(index);
                                break;
                        }
                    }
                    //Tri et stokage des nouveaux index
                    lstIndexTampon = lstIndexTampon.Distinct().ToList();
                    lstIndexTampon.Sort();
                    lstIndex = lstIndexTampon;

                    //Read the next line en ignorant la ligne tampon
                    lineAvant = lineActu;
                    line = sr.ReadLine();
                    line = sr.ReadLine();
                }

                //password = lstIndex.Count;
                foreach (int index in lstIndex)
                    password += Int64.Parse(lineActu[index]);

                //écrit le résultat
                Console.WriteLine($"Le mot de passe est {password}");

                //close the file
                sr.Close();
                Console.ReadLine();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            //finally
            //{
            //    Console.WriteLine("Executing finally block.");
            //}
        }
    }
}

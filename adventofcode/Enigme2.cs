using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    internal class Enigme2
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

                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    //Console.WriteLine(line);

                    string[] words = line.Split(',');

                    foreach (var word in words)
                    {
                        string[] number = word.Split('-');
                        long NumberDebut = Int64.Parse(number[0]);
                        long NumberFin = Int64.Parse(number[1]);
                        Console.WriteLine($"{NumberDebut} - {NumberFin}");
                        for (long i = NumberDebut; i <= NumberFin; i++)
                        {
                            //Console.WriteLine($"début {i}");
                            int taille = Math.Abs(i).ToString().Length;
                            //Console.WriteLine($"{taille}");
                            decimal tempon = taille / 2;
                            int tai = (int)Math.Floor(tempon);
                            //Console.WriteLine($"{tempon}");
                            int trep = 1;
                            //Console.WriteLine($"{trep}");
                            bool switching = false;

                            while (trep <= tai && switching == false)
                            {
                                int nbrep = 0;
                                //Console.WriteLine($"{nbrep}");
                                bool duplic = true;
                                bool boucle = false;
                                //Console.WriteLine($"{duplic}");
                                while ( duplic == true && (nbrep + trep) < taille && taille%trep == 0)
                                {
                                    boucle = true;
                                    //Console.WriteLine($"{i.ToString().Substring(0, trep)}");
                                    //Console.WriteLine($"{i.ToString().Substring(trep + nbrep, trep)}");
                                    if (i.ToString().Substring(0, trep) == i.ToString().Substring(trep + nbrep, trep))
                                    {
                                        duplic = true;
                                    }
                                    else
                                    {
                                        duplic = false;
                                    }
                                    nbrep = nbrep + trep;
                                }
                                if (duplic == true && boucle == true) 
                                { 
                                    password = password + i;
                                    switching = true;
                                    //Console.WriteLine($"La valeur invalide est {i}");
                                }
                                trep++;
                            }
                            //if (taille % 2 == 0)
                            //{
                            //    long compare1 = Int64.Parse(i.ToString().Substring(0, taille / 2));
                            //    long compare2 = Int64.Parse(i.ToString().Substring(taille / 2));
                            //    //Console.WriteLine($"{compare1} - {compare2}");
                            //    if (compare1 == compare2) { password = password + i; }
                            //}
                        }
                        Console.WriteLine($"Le mot de passe est {password}");
                    }

                    //Read the next line
                    line = sr.ReadLine();
                }

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
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}

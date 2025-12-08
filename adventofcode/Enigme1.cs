using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    internal class Enigme1
    {
        public void ResolutionEnigme()
        {
            String line;
            try
            {
                int Dpoint = 50; //point de départ à 50
                int password = 0; //nombre de passage à zéro

                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Users\\Mathieu\\Documents\\GitHub\\calendrier de l'event\\input.txt");

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    //Console.WriteLine(line);

                    string LorR = line[0].ToString();
                    int LorRnumber = Int32.Parse(line.Substring(1).ToString());

                    if (LorR == "L")
                    {
                        if (LorRnumber > 99)
                        {
                            password = password + Math.Abs(LorRnumber / 100 % 10);
                            LorRnumber = Math.Abs(LorRnumber % 100);
                        }
                        int Npoint = Dpoint - LorRnumber;
                        if (Npoint < 0)
                        {
                            int Dpointi = Dpoint;
                            Dpoint = 100 - Math.Abs(Npoint);
                            if (Dpoint != 0 && Dpointi != 0) { password++; }
                        }
                        else
                        {
                            Dpoint = Npoint;
                        }
                    }

                    if (LorR == "R")
                    {
                        if (LorRnumber > 99)
                        {
                            password = password + Math.Abs(LorRnumber / 100 % 10);
                            LorRnumber = Math.Abs(LorRnumber % 100);
                        }
                        int Npoint = Dpoint + LorRnumber;
                        if (Npoint >= 100)
                        {
                            Dpoint = Math.Abs(Npoint) - 100;
                            if (Dpoint != 0) { password++; }
                        }
                        else
                        {
                            Dpoint = Npoint;
                        }
                    }

                    if (Dpoint == 0) { password++; }

                    //écrit où on est placé
                    Console.WriteLine($"Le nouveau point de départ est {Dpoint} avec {line}");

                    //Read the next line
                    line = sr.ReadLine();
                }

                //écrit le résultat
                Console.WriteLine($"Le nombre de passage par 0 est {password}");

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

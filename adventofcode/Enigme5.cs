using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    internal class Enigme5
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

                //Liste de l'emsemble des nombres qui peuvent être bon
                //List<string> lstZonesFresh = new List<string>();
                List<(long deb, long fin)> lstZonesFresh = new List<(long deb, long fin)>();

                //Liste de l'emsemble des nombres qui peuvent être bon
                List<long> lstTestFresh = new List<long>();

                //Récupère la liste de toutes les zones où les nombres qui peuvent être bon par ordre croissant
                //Continue to read until you reach end of first part
                while (line != "")
                {
                    string[] number = line.Split('-');
                    long NumberDebut = Int64.Parse(number[0]);
                    long NumberFin = Int64.Parse(number[1]);
                    lstZonesFresh.Add((NumberDebut, NumberFin));
                    line = sr.ReadLine();
                }

                //Récupère la liste de tous les nombres à tester
                //Read the next line
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    lstTestFresh.Add(Int64.Parse(line));
                    line = sr.ReadLine();
                }
                lstTestFresh.Sort();

                // on mélange toutes les plages de données pour en avoir le moins possible
                //tri de toutes les plages par rapport à leurs début et on vide la liste de zones pour avoir une nouvelle liste
                var LstTri = lstZonesFresh.OrderBy(r => r.deb).ToList();
                lstZonesFresh.Clear();

                long debAct = LstTri[0].deb;
                long finAct = LstTri[0].fin;

                for (int i = 1; i < LstTri.Count; i++)
                {
                    var (d, f) = LstTri[i];

                    //si les plages se chevauche, on fusionne les plages
                    if (d <= finAct + 1)
                    {
                        finAct = Math.Max(finAct, f);
                    }
                    //Sinon, on ajoute la plage actuelle dans la liste des plages
                    else
                    {
                        lstZonesFresh.Add((debAct, finAct));
                        debAct = d;
                        finAct = f;
                    }
                }
                lstZonesFresh.Add((debAct, finAct));

                //Partie 1
                //On regarde si chaque nombre est présent où dans les intervals
                //int memIdex = 0;
                //foreach (long TestFresh in lstTestFresh)
                //{
                //    for (int i = memIdex; i < lstZonesFresh.Count && TestFresh >= lstZonesFresh[i].deb; i++)
                //    {
                //        if (TestFresh <= lstZonesFresh[i].fin)
                //        {
                //            password++;
                //            break;
                //        }
                //        else { memIdex = i + 1; }
                //    }
                //}

                //Partie 2
                foreach (var zone in lstZonesFresh)
                    password = password + (zone.fin - zone.deb) + 1;

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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    internal class Enigme8
    {
        public void ResolutionEnigme()
        {
            String line;
            long password = 0;

            //Récupérer la liste de toutes les coordonnées
            List<long[]> lstCoordonnees = new List<long[]>();
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Users\\Mathieu\\Documents\\GitHub\\calendrier de l'event\\input.txt");

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    string[] tamponS = line.Split(',');
                    long[] tamponI = { 0, 0, 0 };
                    for (int i = 0; i < tamponS.Length; i++)
                        tamponI[i] = (Int64.Parse(tamponS[i]));
                    lstCoordonnees.Add(tamponI);
                    //Read the next line
                    line = sr.ReadLine();
                }

                //close the file
                sr.Close();
                //Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }



            //Liste du calcul de toutes les distances possibles entre chaque coordonnées
            List<(long distance, int boite1, int boite2)> lstDistances = new List<(long distance, int boite1, int boite2)>();
            for (int i = 0; i <= lstCoordonnees.Count - 1; i++)
            {
                for (int j = i + 1; j < lstCoordonnees.Count; j++)
                {
                    long calX = Math.Abs(lstCoordonnees[i][0] - lstCoordonnees[j][0]) * Math.Abs(lstCoordonnees[i][0] - lstCoordonnees[j][0]);
                    long calY = Math.Abs(lstCoordonnees[i][1] - lstCoordonnees[j][1]) * Math.Abs(lstCoordonnees[i][1] - lstCoordonnees[j][1]);
                    long calZ = Math.Abs(lstCoordonnees[i][2] - lstCoordonnees[j][2]) * Math.Abs(lstCoordonnees[i][2] - lstCoordonnees[j][2]);
                    long calculDistance = calX + calY + calZ;
                    lstDistances.Add((calculDistance, i, j));
                }
            }
            lstDistances.Sort();



            //classer les boîtes qui seront lié entre elles
            List<List<int>> listGroupeBoite = new List<List<int>>();
            int connections = 0;
            foreach (var distance in lstDistances)
            {
                bool contientB1 = false;
                bool contientB2 = false;
                bool fusion = false;
                int index = 0;
                int nGroupe = 0;
                foreach (var groupeBoite in listGroupeBoite)
                {
                    //Vérifie si les boites existes dans le groupe
                    //Si les 2 boites sont déjà dans le même groupe
                    if (groupeBoite.Contains(distance.boite1)) contientB1 = true;
                    if (groupeBoite.Contains(distance.boite2)) contientB2 = true;
                    if (contientB2 || contientB1) nGroupe++;
                    if (contientB2 && contientB1 && nGroupe == 1) break;

                    if (groupeBoite.Contains(distance.boite1))
                    {
                        if (contientB2)
                        {
                            groupeBoite.AddRange(listGroupeBoite[index]);
                            fusion = true;
                            break;
                        }
                        else
                            index = listGroupeBoite.IndexOf(groupeBoite);
                        contientB1 = true;
                    }
                    if (groupeBoite.Contains(distance.boite2))
                    {
                        if (contientB1)
                        {
                            groupeBoite.AddRange(listGroupeBoite[index]);
                            fusion = true;
                            break;
                        }
                        else
                            index = listGroupeBoite.IndexOf(groupeBoite);
                        contientB2 = true;
                    }
                }
                //Si il y a fusion de groupe, suppression du groupe en trop
                if (fusion)
                {
                    listGroupeBoite.RemoveAt(index);
                }
                //Si l'un existe dans un groupe mais pas l'autre, l'ajouté au groupe
                if (contientB1 && !contientB2)
                {
                    listGroupeBoite[index].Add(distance.boite2);
                    connections++;
                }
                if (!contientB1 && contientB2)
                {
                    listGroupeBoite[index].Add(distance.boite1);
                    connections++;
                }
                //Si les boîtes n'existe dans aucun groupe, créer un nouveau groupe
                if (!contientB1 && !contientB2)
                {
                    List<int> listBoite = new List<int>() { distance.boite1, distance.boite2 };
                    listGroupeBoite.Add(listBoite);
                    connections += 2;
                }

                //connections++;
                //if (connections == 1000)
                //break;

                //résultat partie 2
                if (connections == lstCoordonnees.Count && listGroupeBoite.Count == 1)
                {
                    password = lstCoordonnees[distance.boite1][0] * lstCoordonnees[distance.boite2][0];
                    break;
                }
            }




            //Calcul des trois plus gros groupes partie 1
            //int groupe1 = 0;
            //int groupe2 = 0;
            //int groupe3 = 0;
            //foreach (var groupeBoite in listGroupeBoite)
            //{
            //    if (groupeBoite.Count > groupe1)
            //    {
            //        if (groupe1 > groupe2)
            //        {
            //            if (groupe2 > groupe3)
            //            {
            //                groupe3 = groupe2;
            //            }
            //            groupe2 = groupe1;
            //        }
            //        groupe1 = groupeBoite.Count;
            //    }
            //    else if (groupeBoite.Count > groupe2)
            //    {
            //        if (groupe2 > groupe3)
            //        {
            //            groupe3 = groupe2;
            //        }
            //        groupe2 = groupeBoite.Count;
            //    }
            //    else if (groupeBoite.Count > groupe3)
            //    {
            //        groupe3 = groupeBoite.Count;
            //    }
            //}
            //password = groupe1 * groupe2 * groupe3;

            //écrit le résultat
            Console.WriteLine($"Le mot de passe est {password}");
        }
    }
}

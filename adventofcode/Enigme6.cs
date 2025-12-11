using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    internal class Enigme6
    {
        public void ResolutionEnigme()
        {
            String line;
            try
            {
                long password = 0;
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Users\\Mathieu\\Documents\\GitHub\\calendrier de l'event\\input.txt");

                //Liste des listes de chaque ligne du fichier
                //List<List<string>> lstList = new List<List<string>>();
                List<List<char>> lstList = new List<List<char>>();

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    //On liste chaque éléments dans une liste qui sera ajouté à la liste de liste
                    //partie 1
                    //List<string> lstLigne = new List<string>(line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                    List<char> lstLigne = new List<char>(line);
                    lstList.Add(lstLigne);

                    //Read the next line
                    line = sr.ReadLine();
                }

                //on calcul et additionne les résultats
                List<int> lstCalcul = new List<int>();
                bool addition = false;
                bool multiplication = false;
                for (int i = 0; i < lstList[0].Count; i++)
                {
                    //Calcul partie 1
                    //long résultatCalcul = 0;
                    //if (lstList[lstList.Count - 1][i] == "+") //Si on addition
                    //{
                    //    for (int j = 0; j < lstList.Count - 1; j++)
                    //        résultatCalcul += Int64.Parse(lstList[j][i]);
                    //}
                    //else if (lstList[lstList.Count - 1][i] == "*") //Si on multiplie
                    //{
                    //    résultatCalcul = 1;
                    //    for (int j = 0; j < lstList.Count - 1; j++)
                    //        résultatCalcul *= Int64.Parse(lstList[j][i]);
                    //}
                    //password += résultatCalcul;

                    //Calcul partie 2
                    //on regarde si tous les éléments sont vide
                    bool blank = true;
                    foreach (var c in lstList)
                        if (c[i] != ' ') blank = false;

                    //Si la colonne est vide, on fait le calcul demandé puis on réinitialise la liste et les variables pour le prochain calcul
                    if (blank)
                    {
                        password += CalculListe(lstCalcul, addition, multiplication);
                        addition = false;
                        multiplication = false;
                        lstCalcul.Clear();
                    }
                    //Sinon, on regarde le type d'opération à faire et on obtient l'un des nombres à calculer
                    else
                    {
                        if (lstList[lstList.Count - 1][i] == '+') addition = true;
                        if (lstList[lstList.Count - 1][i] == '*') multiplication = true;
                        string nb = null;
                        for (int j = 0;  j < lstList.Count - 1; j++)
                            //if (lstList[j][i] != ' ') nb = nb + Convert.ToString(lstList[j][i]);
                            nb = nb + Convert.ToString(lstList[j][i]);
                        lstCalcul.Add(Int32.Parse(nb));
                    }
                }

                //Calcul pour la dernière colonne
                password += CalculListe(lstCalcul, addition, multiplication);

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

        public long CalculListe (List<int> lstCalcul, bool addition = false, bool multiplication = false)
        {
            long résultatCalcul = 0;
            if (addition)
            {
                résultatCalcul = 0;
                foreach (int nb in lstCalcul)
                    résultatCalcul += nb;
            }
            if (multiplication)
            {
                résultatCalcul = 1;
                foreach (int nb in lstCalcul)
                    résultatCalcul *= nb;
            }
            return résultatCalcul;
        }
    }
}

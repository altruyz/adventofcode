using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    internal class Enigme4
    {
        public void ResolutionEnigme()
        {
            long passworda = 0;
            long passwordb = 1;
            String line;
            String newline = null;
            while (passworda != passwordb)
            {
                passwordb = passworda;
                try
                {
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader("C:\\Users\\Mathieu\\Documents\\GitHub\\calendrier de l'event\\input.txt");
                    StreamWriter sw = new StreamWriter("C:\\Users\\Mathieu\\Documents\\GitHub\\calendrier de l'event\\input_temp.txt");

                    //Read the first line of text
                    line = sr.ReadLine();

                    //enregistre la ligne à analyser
                    List<char> listRouleauAnalyse = line.ToList();
                    List<char> listRouleauPrecedent = null;
                    List<char> listRouleauSuivant = null;

                    //rouleau à analyser
                    char rouleau = Convert.ToChar("@");
                    //rouleau à retirer
                    char aVider = Convert.ToChar("x");
                    //espace vide
                    char vide = Convert.ToChar(".");
                    //Numéro de la ligne d'analyse
                    int NumLigneAnalyse = 1;

                    //Read the next line
                    line = sr.ReadLine();

                    //Continue to read until you reach end of file
                    while (line != null)
                    {
                        //enregistre la ligne suivante pour comparaison
                        listRouleauSuivant = line.ToList();

                        for (int i = 0; i < listRouleauAnalyse.Count(); i++)
                        {
                            //si on analyse un x, on le remplace par un point
                            if (listRouleauAnalyse[i] == aVider) { listRouleauAnalyse[i] = vide; }
                            //analyse du rouleau
                            if (listRouleauAnalyse[i] == rouleau)
                            {
                                //nombre de rouleau autour
                                int nbRouleau = 0;
                                //Cas de la première ligne
                                if (NumLigneAnalyse == 1)
                                {
                                    //Cas hors première et dernière colonne
                                    if (i != 0 && i != listRouleauAnalyse.Count() - 1)
                                    {
                                        if (listRouleauAnalyse[i - 1] == rouleau || listRouleauAnalyse[i - 1] == aVider) { nbRouleau++; }
                                        if (listRouleauAnalyse[i + 1] == rouleau || listRouleauAnalyse[i + 1] == aVider) { nbRouleau++; }
                                        if (listRouleauSuivant[i - 1] == rouleau || listRouleauSuivant[i - 1] == aVider) { nbRouleau++; }
                                        if (listRouleauSuivant[i] == rouleau || listRouleauSuivant[i] == aVider) { nbRouleau++; }
                                        if (listRouleauSuivant[i + 1] == rouleau || listRouleauSuivant[i + 1] == aVider) { nbRouleau++; }
                                    }
                                }
                                else
                                {
                                    //Cas de la première colonne
                                    if (i == 0)
                                    {
                                        if (listRouleauPrecedent[i] == rouleau || listRouleauPrecedent[i] == aVider) { nbRouleau++; }
                                        if (listRouleauPrecedent[i + 1] == rouleau || listRouleauPrecedent[i + 1] == aVider) { nbRouleau++; }
                                        if (listRouleauAnalyse[i + 1] == rouleau || listRouleauAnalyse[i + 1] == aVider) { nbRouleau++; }
                                        if (listRouleauSuivant[i] == rouleau || listRouleauSuivant[i] == aVider) { nbRouleau++; }
                                        if (listRouleauSuivant[i + 1] == rouleau || listRouleauSuivant[i + 1] == aVider) { nbRouleau++; }
                                    }
                                    //Cas de la dernière colonne
                                    else if (i == listRouleauAnalyse.Count() - 1)
                                    {
                                        if (listRouleauPrecedent[i - 1] == rouleau || listRouleauPrecedent[i - 1] == aVider) { nbRouleau++; }
                                        if (listRouleauPrecedent[i] == rouleau || listRouleauPrecedent[i] == aVider) { nbRouleau++; }
                                        if (listRouleauAnalyse[i - 1] == rouleau || listRouleauAnalyse[i - 1] == aVider) { nbRouleau++; }
                                        if (listRouleauSuivant[i - 1] == rouleau || listRouleauSuivant[i - 1] == aVider) { nbRouleau++; }
                                        if (listRouleauSuivant[i] == rouleau || listRouleauSuivant[i] == aVider) { nbRouleau++; }
                                    }
                                    else
                                    {
                                        if (listRouleauPrecedent[i - 1] == rouleau || listRouleauPrecedent[i - 1] == aVider) { nbRouleau++; }
                                        if (listRouleauPrecedent[i] == rouleau || listRouleauPrecedent[i] == aVider) { nbRouleau++; }
                                        if (listRouleauPrecedent[i + 1] == rouleau || listRouleauPrecedent[i + 1] == aVider) { nbRouleau++; }
                                        if (listRouleauAnalyse[i - 1] == rouleau || listRouleauAnalyse[i - 1] == aVider) { nbRouleau++; }
                                        if (listRouleauAnalyse[i + 1] == rouleau || listRouleauAnalyse[i + 1] == aVider) { nbRouleau++; }
                                        if (listRouleauSuivant[i - 1] == rouleau || listRouleauSuivant[i - 1] == aVider) { nbRouleau++; }
                                        if (listRouleauSuivant[i] == rouleau || listRouleauSuivant[i] == aVider) { nbRouleau++; }
                                        if (listRouleauSuivant[i + 1] == rouleau || listRouleauSuivant[i + 1] == aVider) { nbRouleau++; }
                                    }
                                }
                                if (nbRouleau < 4)
                                {
                                    listRouleauAnalyse[i] = aVider;
                                    passworda++;
                                }
                            }
                        }

                        //Remplace les x par des . dans la ligne précédente et écrit la ligne dans le fichier tampon
                        if (NumLigneAnalyse != 1)
                        {
                            for (int i = 0; i < listRouleauPrecedent.Count(); i++)
                            {
                                if (listRouleauPrecedent[i] == aVider) { listRouleauPrecedent[i] = vide; }
                                newline = newline + Convert.ToString(listRouleauPrecedent[i]);
                            }
                            sw.WriteLine(newline);
                            newline = null;
                        }

                        //enregistre la ligne d'analyse dans la ligne précédente
                        listRouleauPrecedent = listRouleauAnalyse;
                        NumLigneAnalyse++;
                        listRouleauAnalyse = listRouleauSuivant;
                        //Read the next line
                        line = sr.ReadLine();
                    }

                    for (int i = 0; i < listRouleauAnalyse.Count(); i++)
                    {
                        //si on analyse un x, on le remplace par un point
                        if (listRouleauAnalyse[i] == aVider) { listRouleauAnalyse[i] = vide; }
                        //analyse du rouleau
                        if (listRouleauAnalyse[i] == rouleau)
                        {
                            //nombre de rouleau autour
                            int nbRouleau = 0;
                            //Cas de la première et dernière ligne
                            if (i != 0 && i != listRouleauAnalyse.Count() - 1)
                            {
                                if (listRouleauPrecedent[i - 1] == rouleau || listRouleauPrecedent[i - 1] == aVider) { nbRouleau++; }
                                if (listRouleauPrecedent[i] == rouleau || listRouleauPrecedent[i] == aVider) { nbRouleau++; }
                                if (listRouleauPrecedent[i + 1] == rouleau || listRouleauPrecedent[i + 1] == aVider) { nbRouleau++; }
                                if (listRouleauAnalyse[i - 1] == rouleau || listRouleauAnalyse[i - 1] == aVider) { nbRouleau++; }
                                if (listRouleauAnalyse[i + 1] == rouleau || listRouleauAnalyse[i + 1] == aVider) { nbRouleau++; }
                            }
                            if (nbRouleau < 4)
                            {
                                listRouleauAnalyse[i] = aVider;
                                passworda++;
                            }
                        }
                    }

                    //Remplace les x par des . dans la ligne précédente et écrit la ligne dans le fichier tampon
                    for (int i = 0; i < listRouleauPrecedent.Count(); i++)
                    {
                        if (listRouleauPrecedent[i] == aVider) { listRouleauPrecedent[i] = vide; }
                        newline = newline + Convert.ToString(listRouleauPrecedent[i]);
                    }
                    sw.WriteLine(newline);
                    newline = null;

                    //Remplace les x par des . dans la ligne actuel et écrit la ligne dans le fichier tampon
                    for (int i = 0; i < listRouleauAnalyse.Count(); i++)
                    {
                        if (listRouleauAnalyse[i] == aVider) { listRouleauAnalyse[i] = vide; }
                        newline = newline + Convert.ToString(listRouleauAnalyse[i]);
                    }
                    sw.WriteLine(newline);
                    newline = null;

                    //close the file
                    sr.Close();
                    sw.Close();
                    //Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                //finally
                //{
                //    Console.WriteLine("Executing finally block.");
                //}

                //Console.WriteLine($"Le mot de passe est {passworda}");

                File.Delete("C:\\Users\\Mathieu\\Documents\\GitHub\\calendrier de l'event\\input.txt");
                File.Move("C:\\Users\\Mathieu\\Documents\\GitHub\\calendrier de l'event\\input_temp.txt", "C:\\Users\\Mathieu\\Documents\\GitHub\\calendrier de l'event\\input.txt");
            }
            //écrit le résultat
            Console.WriteLine($"Le mot de passe est {passworda}");
        }
    }
}

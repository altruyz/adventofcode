using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entrez le jour recherché");
            int jour = Int32.Parse(Console.ReadLine());

            switch (jour)
            {
                case 1:
                    Enigme1 enigme1 = new Enigme1();
                    enigme1.ResolutionEnigme();
                    break;
                case 2:
                    Enigme2 enigme2 = new Enigme2();
                    enigme2.ResolutionEnigme();
                    break;
            }
            
        }
    }
}

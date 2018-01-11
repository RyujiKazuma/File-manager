using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            char klavesa = options();
            string path = cesta();
            string option = chosenOpt(klavesa, path);

        }

        static char options()
        {
            Console.WriteLine("Vítej v programu xxx. Zvol si jednu z možností.");
            Console.WriteLine("1. zobrazit soubory"); //seznam souborů ve složce, naformátovaná tabulka > 
            Console.WriteLine("2. smazat soubory ve složce");     //možnosti zda všechy (pokud ano tak plná cesta), poud ne tak obsah
            Console.WriteLine("3. vytvoření složky");

            ConsoleKeyInfo moznost = Console.ReadKey();
            char option = moznost.KeyChar;

            return option;
        }

        static string cesta()
        {
            Console.WriteLine("Zadej cestu: ");
            string cestaD = Console.ReadLine();

            return cestaD;
        }

        static string chosenOpt(char option, string cesta)
        {
            if(option == '1')
            {
                Console.WriteLine("Zvolte si další možnost");
                Console.WriteLine("1. vypsat všechny soubory i s cestou");
                Console.WriteLine("2. vypsat pouze názvy souborů");
                ConsoleKeyInfo moznost = Console.ReadKey();
                char podOption = moznost.KeyChar;

                if(podOption == '1')
                {
                    string[] files = Directory.GetFiles(cesta);
                    foreach (string jmena in files)
                    {
                        Console.WriteLine(jmena);
                    }
                    Console.ReadLine();  
                }
                else if(podOption == '2')
                {

                    string[] files = Directory.GetFiles(cesta);

                    foreach (string jmena in files)
                    {
                        Console.WriteLine(Path.GetFileName(files));
                    }
                    Console.ReadLine();
                }
                else
                {


                }

            }
            else if(option == '2')
            {
                


            }
            else if(option == '3')
            {
                Console.WriteLine("Zadej název pro složku");
                string jmenoDir = Console.ReadLine();
                Directory.CreateDirectory(cesta + @"\" + jmenoDir);
            }
            else
            {
                Console.WriteLine("Zadal jsi neplatnou hodnotu");
                
            }

            string answer = "ok";
            return answer;


            
        }


    }

}


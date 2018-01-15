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
            Console.WriteLine("Welcome in File-manager. Please select an option.");
            Console.WriteLine("1. See the files");  //naformátovat tabulku
            Console.WriteLine("2. Delete all files in directory");    
            Console.WriteLine("3. Create directory");
                                
            ConsoleKeyInfo moznost = Console.ReadKey();
            char option = moznost.KeyChar;

            return option;
        }

        static string cesta()
        {
            Console.WriteLine("");
            Console.WriteLine("Write down path to dir.");
            string cestaD = Console.ReadLine();

            return cestaD;
        }

        static string chosenOpt(char option, string cesta)
        {
            if(option == '1')
            {
                Console.WriteLine("Choose another option");
                Console.WriteLine("1. show files with path");
                Console.WriteLine("2. show just name and type of files");
                ConsoleKeyInfo moznost = Console.ReadKey();
                char podOption = moznost.KeyChar;

                if(podOption == '1')
                { 
                    Console.WriteLine("");
                    string[] files = Directory.GetFiles(cesta);
                    foreach (string jmena in files)
                    {
                        Console.WriteLine(jmena);
                    }
                    Console.ReadLine();  
                }
                else if(podOption == '2')
                {
                    Console.WriteLine("");

                    string[] files = Directory.GetFiles(cesta);

                    foreach (string jmena in files)
                    {

                       Console.WriteLine(Path.GetFileName(jmena));
                    }
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("You have entered not valid value.");

                }

            }
            else if(option == '2')
            { 

                string[] files = Directory.GetFiles(cesta);
                foreach (string jmena in files)
                {
                    File.Delete(jmena);
                }
                Console.WriteLine("");
                Console.WriteLine("All Files in cesta was deleted");
                Console.ReadLine();

            }
            else if(option == '3')
            {
                Console.WriteLine("Name the dir");
                string jmenoDir = Console.ReadLine();
                Directory.CreateDirectory(cesta + @"\" + jmenoDir);
            }
            else
            {
                Console.WriteLine("You have entered unvalid value.");
                
            }

            string answer = "ok";
            return answer;


            
        }


    }

}


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
            int pocet = 0;
						int deletecount = 0;
            char klavesa = options();
            string path = cesta();
            string option = chosenOpt(klavesa, path, pocet, deletecount);
        }

        static char options()
        {
            Console.WriteLine("Welcome in File-manager. Please select an option.");
            Console.WriteLine("1. See the files");
            Console.WriteLine("2. Delete all files in directory");    
            Console.WriteLine("3. Create directory");
            Console.WriteLine("0. Exit");              
            ConsoleKeyInfo moznost = Console.ReadKey();
            char option = moznost.KeyChar;
            return option;
        }

        static string cesta()
        {
            Console.WriteLine();
            Console.WriteLine("Write down path to dir.");
            string cestaD = Console.ReadLine();
            bool exist = Directory.Exists(cestaD);
            if(exist)
            {
                return cestaD;
            }
            else
            {
                return cesta();
            }

        }

        static string chosenOpt(char option, string cesta, int counter, int deletecount)
        {
            
            if (option == '1')
            {
                Console.WriteLine("Choose another option");
                Console.WriteLine("1. Show full paths only");
                Console.WriteLine("2. Show summary list");
                Console.WriteLine("0. exit");
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
												FileInfo f = new FileInfo(jmena);     
												Console.WriteLine($"{Path.GetFileName(jmena),15}" +
															$"{Path.GetExtension(jmena),10}" +
															$"{f.Length,10}" +
															$"{File.GetCreationTime(jmena),10}");
										
											}
                    Console.ReadLine();
                }
                else if(podOption == '0')
                {
                    
                }
                else
                {
                    Console.WriteLine("You have entered not valid value.");
                    counter++;
                    if (counter >= 3)
                    {
                        Console.WriteLine("You've enterd invalid value at least 3 times. Hit enter to shutdown.");
                        Console.ReadLine();
                    }
                    else
                    {
                        return chosenOpt(option, cesta, counter, deletecount);
                    }
                }

            }
            else if(option == '2')
            { 

                string[] files = Directory.GetFiles(cesta);
								foreach (string paths in files)
								{
										deletecount++;
								}

								Console.WriteLine("Do you really want to delete " + deletecount + " files in" + cesta +" ?");
                Console.WriteLine("Y/N");
                ConsoleKeyInfo yesno = Console.ReadKey();
                char sure = yesno.KeyChar;
                if (sure == 'Y')
                {
                    foreach (string jmena in files)
                    {
                        File.Delete(jmena);
												Console.WriteLine(Path.GetFileName(jmena));
										}
                    Console.WriteLine();
                    Console.WriteLine("In " + cesta + " was all " + deletecount + " files deleted.");
                    Console.ReadLine();
                }
                else if(sure == 'y')
                {
                    foreach (string jmena in files)
                    {
                        File.Delete(jmena);
												Console.WriteLine(Path.GetFileName(jmena));
										}
                    Console.WriteLine();
                    Console.WriteLine("In " + cesta + " was all " + deletecount + " files deleted.");
                    Console.ReadLine();

                }
                else if(sure == 'n')
                    {
                    Console.WriteLine("Files won't be deleted. Hit enter to exit.");
                    Console.ReadLine();
                }
                else if(sure =='N')
                {
                    Console.WriteLine("Files won't be deleted. Hit enter to exit.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("You have entered invalid value");
                    Console.ReadLine();
                    counter++;
                    if (counter >= 3)
                    {
                        Console.WriteLine("You've enterd invalid value at least 3 times. Hit enter to exit.");
                        Console.ReadLine();
                    }
                    else
                    {
                        return chosenOpt(option, cesta, counter, deletecount);
                    }
                }

            }
            else if(option == '3')
            {
                Console.WriteLine("Name the dir.");
                string jmenoDir = Console.ReadLine();
				
                Directory.CreateDirectory(cesta + @"\" + jmenoDir);

            }
            else if(option == '0')
            {
               
            }
            else
            {
                Console.WriteLine("You have entered invalid value.");
                counter++;
                if (counter >= 3)
                {
                    Console.WriteLine("You've enterd invalid value at least 3 times. Hit enter to exit.");
                    Console.ReadLine();
                }
                else
                {
                    return chosenOpt(option,cesta,counter,deletecount);
                }
            }

            string answer = "ok";
            return answer;


            
        }


    }

}


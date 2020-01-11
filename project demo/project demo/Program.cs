using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project_demo
{
    class Program
    {
        
        static void Main(string[] args)
        {
        Start:
           
            Console.Clear();
            Console.WriteLine("Enter User ID: ");
            string userid = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string pass = PassAsterisk();
            Console.ReadLine();
            admin o = new admin();
            string i = o.login(userid, pass);

            if (i == "yes")
            {
                Console.WriteLine("Successfull");
                Home obj1 = new Home();
                obj1.home();

            }
          
            
            int a;
                for( a=0;a<=2;a++)
                {
                   
                    Console.WriteLine("Incorrect User ID or Password");
                    Console.WriteLine("Failed. You have two more attempts\n");
                    Console.WriteLine("Press any key to continue...");
                    Console.WriteLine("{0}",a);
                    Console.ReadKey();
                    goto Start;
                }
                Environment.Exit(-1);
            
        }

        public static string PassAsterisk()
        {
            string pass = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    pass += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(pass))
                    {
                        // remove one character from the list of password characters
                        pass = pass.Substring(0, pass.Length - 1);
                        // get the location of the cursor
                        int pos = Console.CursorLeft;
                        // move the cursor to the left by one character
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        // replace it with space
                        Console.Write(" ");
                        // move the cursor to the left by one character again
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }
            // add a new line because user pressed enter at the end of their password
            return pass;
        }
    }
}

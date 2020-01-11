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
            Console.WriteLine("Enter User ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Password: ");
            string pass = Console.ReadLine();
            admin o = new admin();
            int i = o.login(id, pass);

            if (i == 1)
            {
                Console.WriteLine("Successfull");
                Home obj1 = new Home();
                obj1.home();

            }
            else
            {
                Console.WriteLine("Failed");

            }
        }
    }
}

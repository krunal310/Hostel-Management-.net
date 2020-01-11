using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project_demo
{

    class login
    {
        public static void Login()
        {
            Console.WriteLine("Enter User ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Password: ");
            string pass = Console.ReadLine();
            student o = new student();
            int i = o.login(id, pass);

            if (i == 1)
            {
                Console.WriteLine("Successfull");

            }
            else
            {
                Console.WriteLine("Failed");

            }
        }
    }
}

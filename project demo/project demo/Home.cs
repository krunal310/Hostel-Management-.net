using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project_demo
{
    public class Home
    {
        public void home()
        {
            Console.Clear();
            char ch;
            Console.WriteLine("Welcome to ADMIN homepage\n\n");
            Console.WriteLine("a. Student \nb. Rooms \nc. Employees");
            Console.WriteLine("Select Option : ");
            ch = Convert.ToChar(Console.ReadLine());
            switch (Char.ToLower(ch))
            {
                case 'a':
                    Console.WriteLine("Student");
                    Students o = new Students();
                    o.students();
                    break;
                case 'b':
                    Console.WriteLine("Rooms");
                    Rooms o1 = new Rooms();
                    o1.rooms();
                    break;
                case 'c':
                    Console.WriteLine("Employees");
                    Employee o2 = new Employee();
                    o2.employee();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }

        }

    }
     
}


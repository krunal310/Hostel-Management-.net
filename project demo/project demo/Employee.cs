using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace project_demo
{
    class Employee
    {

        int eid, phone;
        string name, email,Department,salary;

        public void employee()
        {

            Console.Clear();
            char ch;
            Console.WriteLine("Welcome to Employee Database\n\n");
            Console.WriteLine("a. Register Employee \nb. View Employee Details \nc. Delete Employee");
            Console.WriteLine("Select Option : ");
            ch = Convert.ToChar(Console.ReadLine());

            switch (Char.ToLower(ch))
            {
                case 'a':
                    Console.WriteLine("Register Employee");
                    Employee o = new Employee();
                    o.registerEmployee();
                    break;
                case 'b':
                    Console.WriteLine("View Employee Details");
                    Employee o1 = new Employee();
                    o1.viewEmployee();
                    break;
                case 'c':
                    Console.WriteLine("Delete Employee");
                    Employee o2 = new Employee();
                    o2.removeEmployee();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }

        }
        public void registerEmployee()
        {

            Console.WriteLine("Enter Employee eid :");
            eid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Employee name : ");
            name = Console.ReadLine();
            Console.WriteLine("Enter Employee email-id :");
            email = Console.ReadLine();
            Console.WriteLine("Enter Employee mobile no :");
            phone = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Department : ");
            Department = Console.ReadLine();
            Console.WriteLine("Enter salary : ");
            salary = Console.ReadLine();


            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kruna\source\repos\project demo\project demo\Database1.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Employee(eid,name,email,phone,Department,salary) VALUES(@eid,@name, @email, @phone, @Department, @salary)", con);
            cmd.Parameters.AddWithValue("@eid", eid);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@Department", Department);
            cmd.Parameters.AddWithValue("@salary", salary);


            cmd.ExecuteNonQuery();
            Console.WriteLine("\nData Inserted ");
            con.Close();

        }
        public void removeEmployee()
        {
            Console.WriteLine("Enter Employee eid");
            eid = Convert.ToInt16(Console.ReadLine());
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kruna\source\repos\project demo\project demo\Database1.mdf;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Employee where eid=@eid", con);
                cmd.Parameters.AddWithValue("@eid", eid);
                cmd.ExecuteNonQuery();
                Console.WriteLine("\nData Deleted! ");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Generated. Details: " + e.ToString());
            }
            finally
            {
                con.Close();
                Console.ReadKey();

            }

        }

        public void viewEmployee()
        {
            Console.Clear();
            Console.WriteLine("Enter Employee eid : ");
            eid = Convert.ToInt16(Console.ReadLine());
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kruna\source\repos\project demo\project demo\Database1.mdf;Integrated Security=True");
            con.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Employee WHERE eid = @eid", con);
            command.Parameters.Add(new SqlParameter("@eid", eid));

            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    Console.WriteLine(reader["eid"].ToString());
                    Console.WriteLine(reader["name"].ToString());
                    Console.WriteLine(reader["email"].ToString());
                    Console.WriteLine(reader["phone"].ToString());
                    Console.WriteLine(reader["salary"].ToString());
                    Console.WriteLine(reader["Department"].ToString());
                }
            }
            Console.WriteLine("\nData displayed! ");
            Console.ReadLine();
            Console.Clear();






        }


    }
}

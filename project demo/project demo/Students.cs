using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace project_demo
{
    class Students
    {
        int id,phone, room;
        string name, email,course;

        public void students()
        {

            Console.Clear();
            char ch;
            Console.WriteLine("Welcome to Student Database\n\n");
            Console.WriteLine("a. Register Student \nb. View Student Details \nc. Delete Student");
            Console.WriteLine("Select Option : ");
            ch = Convert.ToChar(Console.ReadLine());

            switch (Char.ToLower(ch))
            {
                case 'a':
                    Console.WriteLine("Register Student");
                    Students o = new Students();
                    o.registerStudent();
                    break;
                case 'b':
                    Console.WriteLine("View Student Details");
                    Students o1 = new Students();
                    o1.viewStudent();
                    break;
                case 'c':
                    Console.WriteLine("Delete Student");
                    Students o2 = new Students();
                    o2.removeStudent();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }

        }
            public void registerStudent()
            {
               
                Console.WriteLine("Enter student name :");
                name = Console.ReadLine();
                Console.WriteLine("Enter student email-id :");
                email = Console.ReadLine();
                Console.WriteLine("Enter student mobile no :");
                phone = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Room no. : ");
                room = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Course : ");
                course = Console.ReadLine();

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kruna\source\repos\project demo\project demo\Database1.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Student(name,email,phone,room,course) VALUES(@name, @email, @phone, @room, @course)",con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@room", room);
            cmd.Parameters.AddWithValue("@course", course);

            
            cmd.ExecuteNonQuery();
            Console.WriteLine("\nData Inserted ");
            con.Close();

        }
        public void removeStudent()
            {
                Console.WriteLine("Enter student id");
                id = Convert.ToInt16(Console.ReadLine());
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kruna\source\repos\project demo\project demo\Database1.mdf;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Student where id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
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

        public void viewStudent()
        {
            Console.Clear();
            Console.WriteLine("Enter student id : ");
            id = Convert.ToInt16(Console.ReadLine());
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kruna\source\repos\project demo\project demo\Database1.mdf;Integrated Security=True");
            con.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Student WHERE id = @id", con);
            command.Parameters.Add(new SqlParameter("@id", id));

            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    Console.WriteLine("ID : "+reader["id"].ToString());
                    Console.WriteLine(reader["name"].ToString());
                    Console.WriteLine(reader["email"].ToString());
                    Console.WriteLine(reader["phone"].ToString());
                    Console.WriteLine(reader["room"].ToString());
                    Console.WriteLine(reader["course"].ToString());
                }
            }
            Console.WriteLine("\nData displayed! ");
            Console.ReadLine();
            Console.Clear();

            




        }

    }
}


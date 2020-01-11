using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace project_demo
{
    class Rooms
    {


        int id, capacity;
        string roomno,type,wing;

        public void rooms()
        {

            Console.Clear();
            char ch;
            Console.WriteLine("Welcome to Student Database\n\n");
            Console.WriteLine("a. Register Room \nb. View Room Details \nc. Delete Room");
            Console.WriteLine("Select Option : ");
            ch = Convert.ToChar(Console.ReadLine());

            switch (Char.ToLower(ch))
            {
                case 'a':
                    Console.WriteLine("Register Room");
                    Rooms o = new Rooms();
                    o.registerroom();
                    break;
                case 'b':
                    Console.WriteLine("View Room Details");
                    Rooms o1 = new Rooms();
                    o1.viewroom();
                    break;
                case 'c':
                    Console.WriteLine("Delete Room");
                    Rooms o2 = new Rooms();
                    o2.removeroom();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }

        }
        public void registerroom()
        {

            Console.WriteLine("Enter id :");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter room no  :");
            roomno = Console.ReadLine();
            Console.WriteLine("Enter room capacity :");
            capacity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter room type : ");
            type = Console.ReadLine();
            Console.WriteLine("Enter wing : ");
            wing = Console.ReadLine();

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kruna\source\repos\project demo\project demo\Database1.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Room(id,roomno,capacity,type,wing) VALUES(@id,@roomno,@capacity,@type,@wing)", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@roomno", roomno);
            cmd.Parameters.AddWithValue("@capacity", capacity);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@wing", wing);


            cmd.ExecuteNonQuery();
            Console.WriteLine("\nData Inserted ");
            con.Close();

        }
        public void removeroom()
        {
            Console.WriteLine("Enter room id");
            id = Convert.ToInt16(Console.ReadLine());
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kruna\source\repos\project demo\project demo\Database1.mdf;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Room where id=@id", con);
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

        public void viewroom()
        {
            Console.Clear();
            Console.WriteLine("Enter room id : ");
            id = Convert.ToInt16(Console.ReadLine());
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kruna\source\repos\project demo\project demo\Database1.mdf;Integrated Security=True");
            con.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Room WHERE id = @id", con);
            command.Parameters.Add(new SqlParameter("@id", id));

            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    Console.WriteLine(reader["id"].ToString());
                    Console.WriteLine(reader["roomno"].ToString());
                    Console.WriteLine(reader["capacity"].ToString());
                    Console.WriteLine(reader["type"].ToString());
                    Console.WriteLine(reader["wing"].ToString());
                }
            }
            Console.WriteLine("\nData displayed! ");
            Console.ReadLine();
            Console.Clear();






        }


    }
}

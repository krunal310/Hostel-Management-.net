﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace project_demo
{
    abstract class People
    {
        protected string p_name;
        protected string p_pass;
        protected double p_contact;
        protected string p_city;
        protected string p_email;

        public abstract int login(int id, string pass);

       

    }


    sealed class admin : People
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kruna\source\repos\project demo\project demo\Database1.mdf;Integrated Security=True");
        int s_enroll;
        public int Senroll
        {
            get { return s_enroll; }
            set { s_enroll = value; }

        }
        public string Spass
        {
            get { return p_pass; }
            set { p_pass = value; }

        }


        public override int login(int id, string pass)
        {

            SqlCommand cmd = new SqlCommand("select * from Auth where Id=@id and pass=@pass", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@pass", pass);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }
    }
}

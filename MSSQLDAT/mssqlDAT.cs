using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient; //SqlObjects
using System.Data; //Datatable

using System.Configuration;
 
namespace SIMS
{
    namespace DataAccess
    {
	//"public" so it can be used as a .dll file
        public static class DAT
        {
            public static string ConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;

            //Test SQL Connection
            public static bool TestConnection()
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    return true;
                }
                else 
                {
                    con.Close();
                    return false;
                }
            }

            //use for UPDATE, DELETE
            public static void Execute(string SqlStatement)
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();

                SqlCommand com = new SqlCommand(SqlStatement, con);

                com.ExecuteNonQuery();
                con.Close(); //dagdag
            }
            //use this for SELECT statements
            public static DataTable GetData(string SelectStatement)
            {
                SqlDataAdapter da = new SqlDataAdapter(SelectStatement, ConnectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;  
            }
            //for select statements using datareader
            public static SqlDataReader ExecuteReader(string SelectStatement)
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand com = new SqlCommand(SelectStatement, con);
                SqlDataReader dr = com.ExecuteReader();
                return dr;
               
            }

            //use for getting a single integer data
            public static int GetID(string SelectStatement)
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand com = new SqlCommand(SelectStatement, con);
                int id = Convert.ToInt32(com.ExecuteScalar()); 
                con.Close();
                return id;
            }
            //use for getting a single float data
            public static float GetFloat(string SelectStatement)
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand com = new SqlCommand(SelectStatement, con);
                float id = Convert.ToInt32(com.ExecuteScalar());
                con.Close();
                return id;
            }
        }
    }
}

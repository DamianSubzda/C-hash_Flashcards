using System;
using System.Data.SqlClient;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Projekt_fiszki
{
    public class DataBaseConnector
    {

        public static string token = "Data Source=DESKTOP-GH9TGES\\SQLEXPRESS;Initial Catalog=Flashcard;Integrated Security=True";
        //Data Source=DESKTOP-GH9TGES\\SQLEXPRESS;Initial Catalog=Flashcard;Integrated Security=True <-Mój
        //Data Source=DESKTOP-0BAKSVR\\SQLEXPRESS;Initial Catalog=Flashcard;Integrated Security=True <-Twój
        public List<String> getRecord(int ID)
        {
            List<String> elements = new List<String>();
            SqlConnection con = new SqlConnection(token);
            SqlCommand command = new SqlCommand($"select * from DataFlashcard where ID = {ID};", con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();

            elements.Add((reader.GetInt32(0)).ToString());
            int i = 1;
            while (i < 5)
            {
                elements.Add(reader.GetString(i));
                i++;
            }

            reader.Close();
            con.Close();

            return elements;
        }
        static void HasRows(SqlConnection con)
        {
            using (con)
            {
                SqlCommand command = new SqlCommand("SELECT ID, Polish FROM DataFlashcard;", con);
                con.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}\t{1}", reader.GetInt32(0),
                            reader.GetString(1));
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
            }
        }
        public int NumberOfRows()
        {
            SqlConnection con = new SqlConnection(token);
            int n = 0;
            using (con)
            {

                SqlCommand command = new SqlCommand("SELECT * FROM DataFlashcard;", con);
                con.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        n += 1;
                    }
                }
                else
                {
                    n = 0;
                }
                reader.Close();
            }
            return n;
        }

    }
}
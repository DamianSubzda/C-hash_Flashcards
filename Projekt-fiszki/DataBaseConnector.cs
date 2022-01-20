using System;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;


public class DataBaseConnector
{

    public static string token = "Data Source=DESKTOP-GH9TGES\\SQLEXPRESS;Initial Catalog=Flashcard;Integrated Security=True";
    //Data Source=DESKTOP-GH9TGES\SQLEXPRESS;Initial Catalog=Flashcard;Integrated Security=True <-Mój
    //Data Source=DESKTOP-0BAKSVR\\SQLEXPRESS;Initial Catalog=Flashcard;Integrated Security=True <-Twój
    

    public DataBaseConnector()
	{
	}


    public List<String> Connection(int ID)
    {
        List<String> elements = new List<String>();
        SqlConnection con = new SqlConnection(token);
        SqlCommand command = new SqlCommand($"select * from DataFlashcard where ID = {ID};", con);
        con.Open();
        SqlDataReader reader = command.ExecuteReader();
        reader.Read();

        elements.Add((reader.GetInt32(0)).ToString());
        int i = 1;
        while (i<5)
        {
            elements.Add(reader.GetString(i));
            i++;
        }

        reader.Close();
        con.Close();

        return elements;
        }

/*        public async Task<string> Connection2Async(int id)
    {
    public string Connection()
        {
        Console.WriteLine("asdasd");
        String a = "a";
            SqlConnection con = new SqlConnection(token);
            SqlCommand command = new SqlCommand(
                  "SELECT ID, Polish FROM DataFlashcard;",
                  con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                a= "{0}\t{1}" + (reader.GetInt32(0)).ToString() + "  " +
                        reader.GetString(1);
            }
        reader.Close();
        con.Close();
        return a;
        }

/*        public async Task<string> Connection2Async(int id)
    {
>>>>>>> 0721b40079dc6d8ca0f20ba6c5bf46b008d595b9
        Console.WriteLine("asdasd");
        String a = "a";
        String b = "b";
        String c = "c";

        using (SqlConnection conn = new SqlConnection(token))
        {
            conn.Open();

            string sql = @" SELECT ID, Polish FROM Images where id = @id";

            using (SqlCommand comm = new SqlCommand(sql, conn))
            {
                comm.Parameters.AddWithValue("@id", id);

                using (var reader = await comm.ExecuteReaderAsync())
                {
                    if (!reader.Read())
                        throw new Exception("Something is very wrong");

                    String ordId = (reader.GetOrdinal("ID")).ToString();
                    String ordPolish = (reader.GetOrdinal("Polish")).ToString();

                    a = reader.GetString(ordId);
                    b = reader.GetString(ordPolish);
                    c = a + " " + b;
                    
                }
            }
            conn.Close();
            return c;
        }
    }*/

    static void HasRows(SqlConnection con)
    {
        using (con)
        {
            SqlCommand command = new SqlCommand(
              "SELECT ID, Polish FROM DataFlashcard;",
              con);
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
<<<<<<< HEAD

=======
>>>>>>> 0721b40079dc6d8ca0f20ba6c5bf46b008d595b9
        }
    }

    /*    public static void MyFunction(string Id, string Name)
        {
            Console.Write(Name);
        }
        public void GetRow()
        {
            SqlConnection conn = new SqlConnection(token);
            SqlCommand cmd = new SqlCommand("SELECT * FROM TABLE", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                MyFunction(dr["Id"].ToString(), dr["Name"].ToString());
            }



            Console.Read();

        }*/

    public void GetRecordFromDB()
	{

	}

}

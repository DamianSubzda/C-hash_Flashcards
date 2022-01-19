using System;
using System.Data.SqlClient;

public class DataBaseConnector
{

	public static string token = "Data Source=DESKTOP-GH9TGES\\SQLEXPRESS;Initial Catalog=Flashcard;Integrated Security=True";
	SqlConnection con = new SqlConnection(token);

	public DataBaseConnector()
	{
		
	}

	public void Connection()
    {
		con.Open();

		if(con.State == System.Data.ConnectionState.Open)
        {
			Console.WriteLine("It works");
        }
        else
        {
			Console.WriteLine("nie nie dziala");
        }

		con.Close();
	}

	public void GetRecordFromDB()
	{

	}

}

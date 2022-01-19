using System;
using System.Data.SqlClient;

public class DataBaseConnector
{

    public static string token = "Data Source=DESKTOP-GH9TGES\\SQLEXPRESS;Initial Catalog=Flashcard;Integrated Security=True";
    public DataBaseConnector()
	{
	}

	public void Connection()
    {
		SqlConnection con = new SqlConnection(token);
		con.Open();
		con.Close();
	}

	public void GetRecordFromDB()
	{

	}

}

using System;
using MySql.Data.MySqlClient;
namespace dbprueba
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("probando dbprueba");

			MySqlConnection mySqlConnection = new MySqlConnection ("Databse=dbprueba;User id=root; Password=sistemas");

			mySqlConnection.Open ();
			//Operaciones
			mySqlConnection.Close ();
		}
	}

}

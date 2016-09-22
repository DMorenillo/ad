using System;
using System.Data;
using MySql.Data.MySqlClient;
namespace dbprueba
{
	class MainClass
	{
		public static void Main (string[] args)
		{


			IDbConnection dbConnection = new MySqlConnection ("Database=dbprueba:User id=root:Password=sistemas");
			IDbCommand dbCommand = dbConnection.CreateCommand ();
			IDbDataParameter dbDataParameter = dbCommand.CreateParameter ();
			IDbDataParameter dbDataParameter2 = dbCommand.CreateParameter ();
			dbConnection.Open ();

			IDataReader dataReader;
			string cat;
		do {
			Console.WriteLine ("Elige la opcion que desea realizar:");
			Console.WriteLine ("1 Nuevo");
			Console.WriteLine ("2 Editar");
			Console.WriteLine ("3 Eliminar");
			Console.WriteLine ("4 Listar todos");
			Console.WriteLine ("0 Salir");
			int opcion = Console.Read ();

			switch (opcion) {
			case '1':

				dbCommand.CommandText = "insert into categoria (nombre) values (@nombre)";
			
				dbDataParameter.ParameterName = "nombre";
				Console.WriteLine ("Introduce una categoria");
				dbDataParameter.Value = "categoria 4";
				dbCommand.Parameters.Add (dbDataParameter);
				dbCommand.ExecuteNonQuery ();
				break;
			case '2':
				dbCommand.CommandText = "select * from categoria";
				while (dataReader.Read())
				{
					// Procesar 
					int id = dataReader.GetInt32 (0);
					string nombre = dataReader.GetString (1);
					Console.WriteLine ("ID" + id + " " + "nombre" + nombre);
				}
				dataReader.Close ();
				Console.WriteLine ("Introduce una categoria");
				String catmod = Console.ReadLine ();
				Console.WriteLine ("Introduce una ID");
				String idmod = Console.ReadLine ();
				int idint = int.Parse (idmod);
				dbCommand.CommandText = "update categoria set nombre = (@nombrenuevo) where id = (@id)";
				dbDataParameter.ParameterName = "nombrenuevo";
				dbDataParameter.Value = catmod;
				dbDataParameter2.ParameterName = "id";
				dbDataParameter2.Value = idint;
				dbCommand.Parameters.Add (dbDataParameter);
				dbCommand.Parameters.Add (dbDataParameter2);
				dbCommand.ExecuteNonQuery;
				break;
			case '3':
			

				break;
			case '4':

				dbCommand.CommandText = "select * from categoria";
				while (dataReader.Read ())
					
				{
					// Procesar 
					int id = dataReader.GetInt32 (0);
					string nombre = dataReader.GetString (1);
					Console.WriteLine ("ID" + id + " " + "nombre" + nombre);
				}
				dataReader.Close ();
				break;
			case '0':
				dbConnection.Close ();
				break;
				};


			} while(dbConnection=!null);
		}
	}
}

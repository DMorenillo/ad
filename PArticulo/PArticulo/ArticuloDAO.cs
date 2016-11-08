using System;
using System.Collections.Generic;
using System.Data;

namespace PArticulo
{
	public class ArticuloDAO
	{
		public ArticuloDAO ()
		{
		}
		public List<Articulo> GetList(){
			List<Articulo>list = new List<Articulo>();
			//TODO rellenar desde la tabla articulo

			string selectSql = "select * from articulo";
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = selectSql;
			IDataReader dataReader = dbCommand.ExecuteReader ();
			while (dataReader.Read()) {
				long id = (long) dataReader ["id"];
				string nombre = (string)  dataReader ["nombre"];
				decimal? precio = dataReader ["precio"] is DBNull ? null : (decimal?) dataReader ["precio"];
				long? categoria = dataReader ["categoria"] is DBNull ? null : (long?)dataReader ["categoria"];
				Articulo articulo = new Articulo(id, nombre, precio, categoria);
				list.Add (articulo);
			}
			dataReader.Close ();
		}
	}
}


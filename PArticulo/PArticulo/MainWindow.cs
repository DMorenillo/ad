using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

using Org.InstitutoSerpis.Ad;
using PArticulo;


public partial class MainWindow: Gtk.Window
{	
	private IDbConnection dbConnection;
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		dbConnection = new MySqlConnection (
			"Database=dbprueba:User id=root:Password=sistemas"
			);

		refreshAction.Activated += delegate {
			fill();
		};
		newAction.Activated+= delegate {
			new ArticuloView();
		};

	}
	private void fill() {
		dbConnection.Open ();

		List<Articulo>list = new List<Articulo>();
		//TODO rellenar desde la tabla articulo

		string selectSql = "select * from articulo";
		IDbCommand dbCommand = dbConnection.CreateCommand ();
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
		editAction.Sensitive = false;

		treeview.Selection.Changed += delegate {
			bool selected = treeview.Selection.CountSelectedRows()> 0;
			editAction.Sensitive = selected;
			deleteAction.Sensitive = selected;
			//Console.WriteLine("treeView.Selection.Changed selected ={0}",selected);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		dbConnection.Close ();
		Application.Quit ();
		a.RetVal = true;
		}
}


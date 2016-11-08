using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

using Org.InstitutoSerpis.Ad;
using PArticulo;


public partial class MainWindow: Gtk.Window
{	

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		App.Instance.DbConnection = new MySqlConnection (
			"Database=dbprueba:User id=root:Password=sistemas"
			);
		App.Instance.DbConnection.Open();
		fill ();

		};
		newAction.Activated+= delegate {
			new ArticuloView();
		};

	}
	private void fill() {
		

		
		editAction.Sensitive = false;

		treeview.Selection.Changed += delegate {
			bool selected = treeview.Selection.CountSelectedRows()> 0;
			editAction.Sensitive = selected;
			deleteAction.Sensitive = selected;
			//Console.WriteLine("treeView.Selection.Changed selected ={0}",selected);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		App.Instance.DbConnection.Close ();
		Application.Quit ();
		a.RetVal = true;
		}
}


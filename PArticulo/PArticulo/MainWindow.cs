using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;

using Org.InstitutoSerpis.Ad;
using PArticulo;

public partial class MainWindow: Gtk.Window
{	
	private IEntityDao entityDao;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		App.Instance.DbConnection = new MySqlConnection (
			"Database=dbprueba;User Id=root;Password=sistemas"
		);
		App.Instance.DbConnection.Open ();
//		IDbCommand.dbCommand = App.Instance.DbConnection.CreateCommand ();
//		dbCommand.CommandText = "update articulo set precio = 0 where precio is null";
//		db.Command.ExecuteNonQuery ();

		fill ();

		treeView.Selection.Changed += delegate {
			bool selected = treeView.Selection.CountSelectedRows() > 0;
			editAction.Sensitive = selected;
			deleteAction.Sensitive = selected;
		};

		newAction.Activated += delegate {
			Articulo articulo = new Articulo();
			articulo.Precio =0; // hasta que permita el null
			new ArticuloView(articulo);
		};
		editAction.Activated += delegate {
			// Si el metodo load NO fuera estatico se resolveria con una instancia
			// Articulo articulo = articuloDao.Load(TreeViewHelper.GetId(treeView);
			Articulo articulo = ArticuloDao.Load(TreeViewHelper.GetId(treeView));
			new ArticuloView(articulo);
	};

		deleteAction.Activated += delegate {
			if (WindowHelper.Confirm(this, "¿Quieres eliminarrrr el registro?"))
				ArticuloDao.Delete(TreeViewHelper.GetId(treeView));
		};


		refreshAction.Activated += delegate {
			fill();
		};


	}
	public IEntityDao EntityDao {
		set { entityDao = value;}
	}

	private void fill() {
		editAction.Sensitive = false;
		deleteAction.Sensitive = false;
		//IList list = ArticuloDao.GetList ();
		IList list = EntityDao.GetList<Articulo> ();
		TreeViewHelper.Fill (treeView, list);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		App.Instance.DbConnection.Close ();
		Application.Quit ();
		a.RetVal = true;
	}
}

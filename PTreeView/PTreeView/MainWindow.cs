using System;
using Gtk;
using Org.InstitutoSerpis.Ad;
using System.Collections.Generic;
using System.Collections;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		IList list= new List<Articulo> ();
		//Articulo articulo = new Articulo ();
		//articulo.Id = 1L;
		//articulo.Nombre = "articulo 1";
		//articulo.Precio = 1.5m;
//		list.Add (new Articulo (1L, " articulo 1", 1.5m));
//		list.Add (new Articulo (1L, " articulo 2", 2.5m));
//		list.Add (new Articulo (1L, " articulo 3", 3.5m));
		list.Add (new Categoria (1L, " categoria 1", 1.5m));
		list.Add (new Categoria (1L, " categoria 2", 2.5m));
		list.Add (new Categoria (1L, " categoria 3", 3.5m));

		//string[] columnNames = { "id", "nombre", "precio" };

		TreeViewHelper.Fill (treeView, list);


		TreeViewHelper.AppendColumns(treeView, list);


//		ListStore listStore = new ListStore (typeof(long), typeof(string),typeof(decimal));
//		treeView.Model = listStore;
//		listStore.AppendValues (1L, "categoria 1",1.5m);
//		listStore.AppendValues (2L, "categoria 2",2.5m);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
public class Categoria {
	public long Id { get; set;}
	public string Nombre { get; set;}
}
public class Articulo{
			public Articulo (long id, string nombre, decimal precio){
				id = id;
				nombre = nombre;
				precio = precio;
			}

	public long Id { get; set;}
	public string Nombre { get; set;}
	public decimal Precio { get; set;}
}
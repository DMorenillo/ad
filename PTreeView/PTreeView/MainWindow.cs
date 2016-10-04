using System;
using Gtk;
using Org.InstitutoSerpis.Ad;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		string[] columnNames = { "id", "nombre", "precio" };
		TreeViewHelper.AppendColumns(treeView, columnNames);


		ListStore listStore = new ListStore (typeof(long), typeof(string),typeof(decimal));
		treeView.Model = listStore;
		listStore.AppendValues (1L, "categoria 1",1.5m);
		listStore.AppendValues (2L, "categoria 2",2.5m);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}

using System;
using Gtk;
using System.Collections.Generic;

namespace PArticulo
{
	public partial class ArticuloView : Gtk.Window
	{
		public ArticuloView () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			spinButtonPrecio.Value = 0;
			saveAction.Sensitive = false;

			List<Categoria> list = new List<Categoria> ();
			list.Add (new Categoria (1L, "categproa1"));
			list.Add (new Categoria (2L, "categproa2"));
			ListStore liststore = new ListStore (typeof(object));
			foreach (object item in list)
				liststore.AppendValues (item);

			comboBoxCategoria.PackStart
			comboBoxCategoria.Model = liststore;

			entryNombre.Changed+= delegate {
				string value = entryNombre.Text.Trim;
				saveAction.Sensitive = !value.Equals("");
		};
			saveAction.Activated += delegate {
				Console.WriteLine("saveAction.Activated");
		};
		}
	}
	public class Categoria {
		public Categoria (long id, string nombre, decimal? precio, long? categoria) {
			Id = id;
			Nombre = nombre;
		}

		public long Id { get; set; }
		public string Nombre { get; set; }
	}
}


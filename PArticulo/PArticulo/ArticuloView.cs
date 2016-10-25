using System;
using Gtk;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;

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
			list.Add (new Categoria (1L, "categoria1"));
			list.Add (new Categoria (2L, "categoria2"));
			ComboBoxHelper.Fill (comboBoxCategoria, list, "Nombre");
		}

	public class Categoria {
		public Categoria (long id, string nombre) {
			Id = id;
			Nombre = nombre;
		}

		public long Id { get; set; }
		public string Nombre { get; set; }
	}
}


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
			list.Add (new Categoria (1L, "categoria1"));
			list.Add (new Categoria (2L, "categoria2"));
			ListStore liststore = new ListStore (typeof(object));
			foreach (object item in list)
				liststore.AppendValues (item);
			CellRendererText cellRendererText = new CellRendererText ();
			comboBoxCategoria.PackStart (CellRendererText, false);
				comboBoxCategoria.SetCellDataFunc(cellRendererText, 
				                                  delegate (CellLayout cell_layout,CellRenderer cell, TreeModel tree_model, TreeIter iter){
				Categoria categoria = (Categoria)tree_model.GetValue(iter,0);
				cellRendererText.Text = categoria.Nombre;
				});
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
		public Categoria (long id, string nombre) {
			Id = id;
			Nombre = nombre;
		}

		public long Id { get; set; }
		public string Nombre { get; set; }
	}
}


using System;
using Gtk;
using System.Collections;
using System.Reflection;
using Org.InstitutoSerpis.Ad;

namespace Org.institutoSerpis.Ad
{
	public class ComboBoxHelper
	{
		public static void Fill (ComboBox comboBox, IList list, string propertyName){
			Type listType = list.GetType ();
			Type[] elementType = listType.GetGenericArguments ();
			PropertyInfo propertyInfo = elementType.GetProperty(propertyName);
			ListStore liststore = new ListStore (typeof(object));
			foreach (object item in list)
				liststore.AppendValues (item);
			CellRendererText cellRendererText = new CellRendererText ();
			comboBox.PackStart (CellRendererText, false);
			comboBox.SetCellDataFunc(cellRendererText, 
			                         delegate (CellLayout cell_layout,CellRenderer cell, TreeModel tree_model, TreeIter iter){
				//				Categoria categoria = (Categoria)tree_model.GetValue(iter,0);
				//				cellRendererText.Text = categoria.Nombre;
				object item = tree_model.GetValue(iter,0);
				object value = propertyInfo.GetValue(item , null);
				cellRendererText.Text = value.ToString; 
			});
		}
	}
}


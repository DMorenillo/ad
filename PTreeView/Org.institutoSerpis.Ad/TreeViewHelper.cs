using Gtk;
using System;


namespace Org.InstitutoSerpis.Ad
{
	public class TreeViewHelper
	{
		public static void AppendColumns(TreeView treeView, string [] columnNames){
			int index=0;
			foreach(string columnName in columnNames){
				int column = index++;
				treeView.AppendColumn (columnName, new CellRendererText (),
				    delegate(TreeViewColumn tree_column, CellRenderer cell, TreeModel tree_model, TreeIter iter){
						CellRendererText cellRendererText =(CellRendererText)cell;
						object value= tree_model.GetValue(iter, column);
						cellRendererText.Text= value.ToString();
						Console.WriteLine("index=(0) column=(1)", index, column);
				}
				);
			}
		}
	}
}


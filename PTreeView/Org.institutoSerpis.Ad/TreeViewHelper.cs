using Gtk;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;


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
		public static void AppendColumns (TreeView treeView, Type type){
			PropertyInfo[] propertyInfos = type.GetProperties();
			List<string> propertyNames = new List <string>();
			foreach (PropertyInfo propertyInfo in propertyInfos)
				propertyNames.Add (propertyInfo.Name);
			AppendColumns (treeView, propertyNames.ToArray());
		}

		private static void appendColumns (TreeView treeView, IList list){
			if (treeView.Columns !=0)
			Type listType = list.GetType ();
			//Console.WriteLine ("listType={0}", listType);
			Type[] elementType = listType.GetGenericArguments ();
			//Console.WriteLine ("elementType={0}", genericArgument);
			PropertyInfo[] propertyInfos = elementType.GetProperties ();
			int columnIndex = 0;
			foreach (PropertyInfo propertyInfo in propertyInfos) {
				string columnName = propertyInfo.Name;
				treeView.AppendColumn (columnName, new CellRendererText (),
				                       delegate(TreeViewColumn tree_column, CellRenderer cell, TreeModel tree_model, TreeIter iter) {
					object Item = tree_model.GetValue (iter, 0);
					object value = propertyInfo.GetValue (Item, null);
					Console.WriteLine ("item.GetType()={0}", Item.GetType ());
					CellRendererText CellRendererText = (CellRendererText)cell;
					CellRendererText.Text = value == null ? "": value.ToString();
				}
				);
			}
		}
		private static void appendValues (TreeView treeView, IList list){
			ListStore listStore = new ListStore(typeof(long));
			treeView.Model= listStore;
			foreach(object item in list)
				listStore.AppendValues(item);
		}

		public static void Fill(TreeView treeView, IList list){
			appendColumns (treeView, list);
			appendValues (treeView, list);
			// Aqui añadimos Datos

		}
	}

	
	}
}


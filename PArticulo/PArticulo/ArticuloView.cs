using System;
using Gtk;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.Data;
using Org.InstitutoSerpis.Ad;
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
			saveAction.Activated += delegate{
				Console.WriteLine("saveAction.Activated");
				string nombre = entryNombre.Text;
				decimal precio  =(decimal) spinButtonPrecio.Value;
				TreeIter treeIter;
				comboBoxCategoria.GetActiveIter(out treeIter);
				object item = comboBoxCategoria.Model.GetValue(treeIter,0);
				object categoria = ComboBoxHelper.GetId(comboBoxCategoria);
				Console.WriteLine("Value='{0}'",categoria);
				                                           

				string insertSql = "insert into articulo (nombre, precio , categoria)"+
					"values (@nombre, @precio, @categoria)" ;
//				string insertSql = "insert into aticulo (nombre) values (@nombre, @precio)";
				IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
				dbCommand.CommandText = insertSql;
				DbCommandHelper.AddParameter(dbCommand, "nombre", nombre);
				DbCommandHelper.AddParameter(dbCommand, "precio", precio);
				DbCommandHelper.AddParameter(dbCommand, "categoria", categoria);

				dbCommand.ExecuteNonQuery();
			};

			entryNombre.Changed+= delegate {
				string content = entryNombre.Text.Trim();
				saveAction.Sensitive = content != string.Empty;
		};


	}
		private void fill(){
			List<Categoria> list = new List<Categoria> ();
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			string selectSql = "select * from categoria order by nombre";
			dbCommand.CommandText = selectSql ;
			IDataReader.dataReader = dbCommand.ExecuteReader ();
			while (DataTableReader.Read()){
				long id = (long)DataTableReader ["id"];
				string nombre = (string)DataTableReader ["nombre"];
				Categoria categoria = new Categoria (id, nombre);
				list.Add (Categoria);
			}
			DataTableReader.Close();
		}

	
}


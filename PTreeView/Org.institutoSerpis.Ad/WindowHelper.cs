using System;
using Gtk;

namespace Org.institutoSerpis.Ad
{
	public class WindowHelper
	{
		public static bool Confirm (Window parent, string message)
		{
			MessageDialog messageDialog = new MessageDialog(
				parent,
				DialogFlags.Modal,
				MessageType.Question,
				ButtonsType.YesNo,
				"¿Quieres eliminar el registro?"
				);
			ResponseType response = (ResponseType)messageDialog.Run();
			messageDialog.Destroy();
			return response == ResponseType.Yes;

		}
	}
}


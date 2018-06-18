using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteTree
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NoteOverview : ResourceDictionary
	{
        public EventHandler OnNoteSelection { get; set; }
        public void OnButton (object sender, EventArgs e)
        {
            OnNoteSelection(sender, e);
        }

		public NoteOverview ()
		{
			InitializeComponent ();
		}
	}
}
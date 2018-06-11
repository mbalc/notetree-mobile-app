using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteTree.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPage : ContentPage
	{
        private Note data;
		public DetailPage (Note note)
		{
			InitializeComponent ();
            data = note;

            BindingContext = data;
		}
        public void OnEdit()
        {
            System.Diagnostics.Debug.Print("editin");
            DisplayAlert ("Edit", "Note editing is not supported yet", "OK");
            // TODO new page
        }
        public void OnDelete()
        {
            System.Diagnostics.Debug.Print("deletin");
            DisplayAlert ("Delete", "Note deletion is not supported yet", "OK");
            // TODO prompt
            // TODO remove db entry
            // TODO redirect to ListPage
            // TODO reassure ListPages are up-to-date
        }
	}
}
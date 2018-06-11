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
        public Note Note { get; set; }

		public DetailPage (Note note)
		{
			InitializeComponent ();
            Note = note;

            BindingContext = this;
		}
        public void OnEdit()
        {
            System.Diagnostics.Debug.Print("editin {0}", Note.Content);
            Navigation.PushAsync(new EditPage(Note));
            // TODO new page
        }
        async public void OnDelete()
        {
            Boolean result = await DisplayAlert ("Delete",
                "Are you sure you want to delete this note?",
                "Yes", "No"
            ); // TODO support for children - add notice what will happen

            if (result)
            {
                await App.Database.DeleteItemAsync(Note);
                await Navigation.PopAsync();
            }

            // TODO? move to edit page
        }
	}
}
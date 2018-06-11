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
	public partial class EditPage : ContentPage
	{
        public Note oldNote;
        public Note NewEntry { get; set; }
		public EditPage (Note note)
		{
			InitializeComponent ();

            if (note == null) // creating a new note
            {
                NewEntry = new Note();
                Title = "New Note";
            }
            else // editing a note
            {
                NewEntry = (Note)note.Clone();
                Title = "Edit Note";
            }
            BindingContext = this;
		}
		public EditPage () : this(null) { }
        public void OnCommit()
        {
            App.Database.SaveItemAsync(NewEntry);
            Navigation.PopAsync();
        }
	}
}
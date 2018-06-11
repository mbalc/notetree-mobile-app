using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteTree.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        private Note _note;
        public Note Note { get => _note; set { _note = value; base.OnPropertyChanged("Note"); } }

        public bool IsRefreshing { get; set; } // may become useful in future when syncing to external service

		public DetailPage (Note note)
		{
			InitializeComponent ();
            Note = note;

            BindingContext = this;
		}
        async public void RefreshEntry()
        {
            IsRefreshing = true;
            Note = await App.Database.GetItemAsync(Note.ID);
            IsRefreshing = false;
        }
        public void OnEdit()
        {
            System.Diagnostics.Debug.Print("editin {0}", Note.Content);
            Navigation.PushAsync(new EditPage(Note));
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            RefreshEntry();
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
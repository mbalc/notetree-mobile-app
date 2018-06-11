using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NoteTree
{
	public partial class ListPage : ContentPage
	{
        private ObservableCollection<Note> items;
		public ListPage()
		{
			InitializeComponent();

            FullUpdateEntryData();
		}

        async void FullUpdateEntryData()
        {
            List <Note> notes = await App.Database.GetItemsAsync();
            items = new ObservableCollection<Note>(notes);
            NoteListing.ItemsSource = items;
        }

        public void OnDetails(object sender, EventArgs e)
        {
            Note note = (Note)((Button)sender).BindingContext;
            Navigation.PushAsync(new NoteTree.Pages.DetailPage(note));
        }

        override protected void OnAppearing()
        {
            base.OnAppearing();
            System.Diagnostics.Debug.Print("reappearing");
            FullUpdateEntryData();  // TODO improve performance - do this only when there were changes made to DB
        }

        public void OnAddEntry(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pages.EditPage());

            //items.Insert(0, newEntry);
        }
	}
}

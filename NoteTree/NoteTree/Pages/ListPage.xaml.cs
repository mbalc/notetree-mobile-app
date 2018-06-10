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

            InitEntryData();
		}

        async void InitEntryData()
        {
            List <Note> notes = await App.Database.GetItemsAsync();
            items = new ObservableCollection<Note>(notes);
            NoteListing.ItemsSource = items;
        }

        public EventHandler getOnEntryDelete(Note entry, ViewCell cell)
        {
            return (object sender, EventArgs args) =>
            {
                Debug.WriteLine(entry);
                App.Database.DeleteItemAsync(entry);
                items.Remove(entry);
            };
        }

        public void OnAddEntry(object sender, EventArgs e)
        {
            Note newEntry = new Note();
            App.Database.SaveItemAsync(newEntry);
            //await Navigation.PushAsync (new Page1 ());

            items.Insert(0, newEntry);
        }
	}
}

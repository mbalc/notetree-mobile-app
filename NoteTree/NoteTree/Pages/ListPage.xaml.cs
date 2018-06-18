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
    // TODO add multiselect for deletion
	public partial class ListPage : ContentPage
	{
        private ObservableCollection<Note> items;
		public ListPage()
		{
			InitializeComponent();
            NoteListing.RefreshCommand = OnRefresh;

            FullUpdateEntryData();
		}

        async void FullUpdateEntryData()
        {
            NoteListing.IsRefreshing = true;

            List <Note> notes = await App.Database.GetItemsAsync();
            items = new ObservableCollection<Note>(notes);
            NoteListing.ItemsSource = items;

            NoteListing.IsRefreshing = false;
        }

        public void OnDetails(object sender, EventArgs e)
        {
            Note note = (Note)((Button)sender).BindingContext;
            Navigation.PushAsync(new NoteTree.Pages.DetailPage(note));
        }
        public ICommand OnRefresh
        {
            get {
                return new Command(() =>
                {
                    FullUpdateEntryData();
                });
            }
        }
        override protected void OnAppearing()
        {
            base.OnAppearing();

            FullUpdateEntryData();  // TODO improve performance - do this only when there were changes made to DB
        }
        public void OnAddEntry(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pages.DetailPage());

            //items.Insert(0, newEntry);
        }
	}
}

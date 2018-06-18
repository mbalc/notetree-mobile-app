using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace NoteTree
{
    // TODO add multiselect for deletion
	public abstract partial class ListPage : ContentPage
	{
        public EventHandler OnAction;
        public string ActionName;
        private ObservableCollection<Note> items;
        int RootID;
		public ListPage(int root)
		{
			InitializeComponent();
            NoteListing.RefreshCommand = OnRefresh;
            RootID = root;
            FullUpdateEntryData();
            NoteListing.ItemSelected += (sender, e) => {
                ((ListView)sender).SelectedItem = null;
            };
            NoteListing.ItemTapped += (sender, e) => {
                Note note = e.Item as Note;
                ViewChildren(note);
            };

		}
		public ListPage() : this(0) { }
        async void FullUpdateEntryData()
        {
            NoteListing.IsRefreshing = true;

            var notes = ( await App.Database.GetItemsAsync() ).Where(note => note.ParentID == RootID);
            items = new ObservableCollection<Note>(notes);
            NoteListing.ItemsSource = items;
            NoteListing.IsRefreshing = false;
        }
        protected abstract void ViewChildren(Note note);
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

            NoteOverview.SetText(ActionName);
            NoteOverview.Action = OnAction;
            FullUpdateEntryData();  // TODO improve performance - do this only when there were changes made to DB
        }
	}
}

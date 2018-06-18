﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace NoteTree
{
    // TODO add multiselect for deletion
	public partial class ListPage : ContentPage
	{
        public EventHandler OnAction;
        public string ActionName;
        private ObservableCollection<Note> items;
        Note NoteRoot;
		public ListPage(Note root)
		{
			InitializeComponent();
            NoteListing.RefreshCommand = OnRefresh;

            NoteRoot = root;
            FullUpdateEntryData();
		}
		public ListPage() : this(null) { }
        async void FullUpdateEntryData()
        {
            NoteListing.IsRefreshing = true;

            var notes = ( await App.Database.GetItemsAsync() ).Where(note => note.Parent == NoteRoot);
            items = new ObservableCollection<Note>(notes);
            NoteListing.ItemsSource = items;

            NoteListing.IsRefreshing = false;
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

            NoteOverview.SetText(ActionName);
            NoteOverview.OnNoteSelection = OnAction;
            FullUpdateEntryData();  // TODO improve performance - do this only when there were changes made to DB
        }
	}
}

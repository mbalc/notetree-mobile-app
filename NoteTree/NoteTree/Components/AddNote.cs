using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NoteTree.Components
{
    class AddNote : ToolbarItem
    {
        public AddNote()
        {
            Text = "Add";
            Clicked += OnAddEntry;
        }
        public void OnAddEntry(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new Pages.NewNote() { Title = "New Note" });
        }
    }
}

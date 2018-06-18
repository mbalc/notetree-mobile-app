using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NoteTree.Components
{
    class AddNote : ToolbarItem
    {
        int ParentID;
        public AddNote(int ParentID)
        {
            Text = "Add";
            Clicked += OnAddEntry;
            this.ParentID = ParentID;
        }
        public void OnAddEntry(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new Pages.NewNote(ParentID) { Title = "New Note" });
        }
    }
}

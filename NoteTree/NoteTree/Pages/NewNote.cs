using System;
using System.Collections.Generic;
using System.Text;

namespace NoteTree.Pages
{
    class NewNote : DetailPage
    {
        public NewNote(int ParentID) : base(new Note() { ParentID = ParentID }) {
            App.Database.SaveItemAsync(Note);
        }
        public NewNote() : this(0) { }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Editor.Focus();
        }
    }
}

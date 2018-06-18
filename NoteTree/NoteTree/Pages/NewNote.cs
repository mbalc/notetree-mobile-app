using System;
using System.Collections.Generic;
using System.Text;

namespace NoteTree.Pages
{
    class NewNote : DetailPage
    {
        public NewNote() : base(new Note()) {
            App.Database.SaveItemAsync(Note);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Editor.Focus();
        }
    }
}

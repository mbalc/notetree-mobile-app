using System;
using System.Collections.Generic;
using System.Text;

namespace NoteTree.Pages
{
    class NewNote : DetailPage
    {
        public NewNote() : base(new Note()) { }
        override public void RefreshEntry() { }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Editor.Focus();
        }
    }
}

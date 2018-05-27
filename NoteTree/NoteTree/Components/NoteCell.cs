using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NoteTree.Components
{
    public class NoteCell : ViewCell
    {
        public delegate void handleClick();
        private Button button;
        public NoteCell (Note entry)
        {
            button = new Button { Text = entry.Content };
            View = button;
        }
        public NoteCell (Note entry, EventHandler handler) : this(entry)
        {
            addHandler(handler);
        }

        public void addHandler(EventHandler handler)
        {
            button.Clicked += handler;
        }
    }
}

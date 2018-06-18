using System;
using Xamarin.Forms;

namespace NoteTree.Pages
{
    class ViewNotes : ListPage
    {
        public ViewNotes(Note Parent) : base(Parent == null ? 0 : Parent.ID)
        {
            Title = Parent == null ? "Main Notes" : "Children of " + Parent.Content;
            OnAction = getShowDetails(Parent);
            ToolbarItems.Add(new Components.AddNote(Parent == null ? 0 : Parent.ID));
            ActionName = "View";
        }
        public ViewNotes() : this(null) {}
        override protected void ViewChildren (Note note)
        {
            App.Current.MainPage.Navigation.PushAsync(new Pages.ViewNotes(note));
        }
        private EventHandler getShowDetails(Note Parent)
        {
            return (sender, e) =>
            {
                Note note = (Note)((Button)sender).BindingContext;
                App.Current.MainPage.Navigation.PushAsync(new Pages.EditNote(note) { Note=note, Title = "Note Details" });
            };
        }
    }
}

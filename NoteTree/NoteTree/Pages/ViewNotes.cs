using System;
using Xamarin.Forms;

namespace NoteTree.Pages
{
    class ViewNotes : ListPage
    {
        public ViewNotes(Note Parent) : base(Parent)
        {
            Title = Parent == null ? "Main Notes" : "Children of " + Parent.Content;
            OnAction = getShowDetails(Parent);
            ToolbarItems.Add(new Components.AddNote());
            ActionName ="View";
        }
        public ViewNotes() : this(null) {}
        private EventHandler getShowDetails(Note Parent)
        {
            return (sender, e) =>
            {
                Note note = (Note)((Button)sender).BindingContext;
                App.Current.MainPage.Navigation.PushAsync(new Pages.EditNote(note) { Title = "Note Details" });
            };
        }
    }
}

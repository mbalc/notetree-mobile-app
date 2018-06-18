using System;
using Xamarin.Forms;

namespace NoteTree.Pages
{
    class ChooseParent : ListPage
    {
        public ChooseParent(int ParentID) : base(ParentID)
        {
            Title = "Choose Parent Note";
            OnAction = MakeChoice;
            ToolbarItems.Add(new Components.AddNote(ParentID));
            ActionName = "Choose";
        }
        override protected void ViewChildren (Note note)
        {
            App.Current.MainPage.Navigation.PushAsync(new Pages.ChooseParent(note.ID));
        }
        private EventHandler MakeChoice = async (sender, e) =>
        {
            Note chosen = (Note)((Button)sender).BindingContext;
            var nav = App.Current.MainPage.Navigation;
            var stack = nav.NavigationStack;
            while (stack[stack.Count - 2].GetType() == typeof(ChooseParent))
            {
                await App.Current.MainPage.Navigation.PopAsync();
            }  // next pop will show detailpage and trigger a refresh
            var details = stack[stack.Count - 2] as DetailPage;
            Note edited = details.Note;
            edited.ParentID = chosen.ID;
            await App.Database.SaveItemAsync(edited);
            var output = await App.Database.GetItemAsync(edited.ID);
            await App.Current.MainPage.Navigation.PopAsync();
        };
        public ChooseParent() : this(0) {}
    }
}

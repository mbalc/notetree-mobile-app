using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteTree
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        enum Mode { New, Edit };
        Mode mode;
        private Note _note;
        public Note Note { get => _note; set { _note = value; base.OnPropertyChanged("Note"); } }
        public ViewCell ParentContent;

        public bool IsRefreshing { get; set; } // may become useful in future when syncing to external service
        public DetailPage(Note note)
        {
            InitializeComponent();

            if (note == null) // creating a new note
            {
                Note = new Note();
                System.Diagnostics.Debug.Print("tutaj test" + Mode.New);
                System.Diagnostics.Debug.Print("tutaj test" + Note.ID);
                mode = Mode.New;
            }
            else // editing a note
            {
                Note = (Note)note.Clone();
                mode = Mode.Edit;
            }
            Title = mode + " Note";
            InitParentOverview();

            BindingContext = this;
		}
        private void InitParentOverview()
        {
            NoteOverview resource = new NoteOverview();
            resource.SetText("Set Parent");
            DataTemplate NoteOverviewTemplate = resource["NoteOverviewTemplate"] as DataTemplate;
            ParentContent = NoteOverviewTemplate.CreateContent() as ViewCell;
            ParentOverview.BindingContext = Note.Parent != null ? Note.Parent : new Note { Content = "Parent not set" };
            ParentOverview.Content = ParentContent.View;
        }
        public DetailPage() : this(null) {}
        async public void RefreshEntry()
        {
            if (mode == Mode.Edit) {
                IsRefreshing = true;
                Note = await App.Database.GetItemAsync(Note.ID);
                IsRefreshing = false;
            }
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (Note != null) { // if Note was not deleted
                App.Database.SaveItemAsync(Note);
            }
            Navigation.PopAsync();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (mode == Mode.New) ContentEditor.Focus();
            RefreshEntry();
        }
        async public void OnDelete()
        {
            Boolean result = await DisplayAlert ("Delete",
                "Are you sure you want to delete this note?",
                "Yes", "No"
            ); // TODO support for children - add notice what will happen

            if (result)
            {
                await App.Database.DeleteItemAsync(Note);
                Note = null;  // preventing OnDisappearing Note resave
                await Navigation.PopAsync();
            }
            // TODO? move to edit page
        }
	}
}

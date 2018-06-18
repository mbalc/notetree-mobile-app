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
        protected Editor Editor { get; }
        public Note Note { get => _note; set { _note = value; base.OnPropertyChanged("Note"); } }
        public ViewCell ParentContent;

        public bool IsRefreshing { get; set; } // may become useful in future when syncing to external service
        public DetailPage(Note note)
        {
            InitializeComponent();
            Note = note;
            BindingContext = this;
            InitParentOverview();
            Editor = ContentEditor;  // expose its method to inheriting classes
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
        virtual async public void RefreshEntry()
        {
            IsRefreshing = true;
            Note = await App.Database.GetItemAsync(Note.ID);
            IsRefreshing = false;
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

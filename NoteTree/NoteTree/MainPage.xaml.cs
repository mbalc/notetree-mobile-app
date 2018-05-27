using NoteTree.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NoteTree
{
	public partial class MainPage : ContentPage
	{
        private TableSection entries;

		public MainPage()
		{
			InitializeComponent();

            entries = this.FindByName<TableSection>("moje");
            InitEntryData();
		}


        async void InitEntryData()
        {
            entries.Clear();
            List<Note> getEntryData = await App.Database.GetItemsAsync();

            foreach (var entry in getEntryData)
            {
                entries.Add(getSelfDestructiveNoteCell(entry));
            }
        }

        public EventHandler getOnEntryDelete(Note entry, ViewCell cell)
        {
            return (object sender, EventArgs args) =>
            {
                Debug.WriteLine(entry);
                App.Database.DeleteItemAsync(entry);
                entries.Remove(cell);
            };
        }

        private NoteCell getSelfDestructiveNoteCell(Note entry)
        {
            var c = new NoteCell(entry);
            c.addHandler(getOnEntryDelete(entry, c));
            return c;
        }

        public void OnAddEntry(object sender, EventArgs e)
        {
            Note newEntry = new Note();
            App.Database.SaveItemAsync(newEntry);

            entries.Add(getSelfDestructiveNoteCell(newEntry));
        }
	}
}

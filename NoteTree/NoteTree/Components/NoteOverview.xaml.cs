using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteTree
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteOverview : ResourceDictionary
    {
        public EventHandler Action { get; set; }
        public string ActionTitle = "View";
        public void OnButtonClick (object sender, EventArgs e)
        {
            Action(sender, e);
        }

        public NoteOverview() : this(null) {}
        public NoteOverview(string ActionTitle)
        {
            InitializeComponent();
            if (ActionTitle != null) SetText(ActionTitle);
		}

        public void SetText(string text)
        {
            DataTemplate template = this["NoteOverviewTemplate"] as DataTemplate;
            this["ActionTitle"] = text;
        }
	}
}
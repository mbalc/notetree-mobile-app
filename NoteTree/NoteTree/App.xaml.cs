using Xamarin.Forms;

namespace NoteTree
{

    public partial class App : Application
	{
        static Database _database;
		public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new ListPage()); // TODO MasterDetailPage with link to settings, about, help and exit
		}
        public static Database Database
        {
          get
          {
            if (_database == null)
            {
              _database = new Database(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
            }
            return _database;
          }
        }

		protected override void OnStart ()
		{
            // Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

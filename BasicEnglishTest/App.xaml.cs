using SQLite;
using Xamarin.Forms;

namespace BasicEnglishTest
{
	public partial class App : Application
	{
		public const string DBName = "data.db";
		public static SQLiteConnection sqlConn;
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new BasicEnglishTestPage());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

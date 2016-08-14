using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SQLite;
using Xamarin.Forms;

namespace BasicEnglishTest
{
	public partial class App : Application
	{
		public const string DBName = "data.db";
		private static SQLiteConnection _sqlConn;
		public static SQLiteConnection SqlConn{
			get{
				if(_sqlConn == null)
					_sqlConn = DependencyService.Get<IPlatform>().GetConnection(App.DBName);
				return _sqlConn;
			}
		}

		public static IEnumerator<ELesson> Lesson;
		public App()
		{
			_sqlConn = DependencyService.Get<IPlatform>().GetConnection(App.DBName);
			InitializeComponent();
			MainPage = new NavigationPage(new BasicEnglishTestPage());
		}

		public static IEnumerable<ELesson> GetLessons()
		{
			return (from i in SqlConn.Table<ELesson>() select i).ToList();
		}

		public static IEnumerable<EQuestion> GetQuestion(int idLesson)
		{
			var questions = (from q in SqlConn.Table<EQuestion>() where q.LessonId == idLesson select q	 ).ToList();
			foreach (EQuestion q in questions)
			{
				q.Answers = (from a in SqlConn.Table<EAnswer>() where a.QuestionId.Equals(q.Id) select a).ToList();
			}
			return questions;
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

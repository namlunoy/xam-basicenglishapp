using System.Diagnostics;
using Xamarin.Forms;
using System.Reflection;
using System.IO;
using System;

namespace BasicEnglishTest
{
	public partial class BasicEnglishTestPage : ContentPage
	{
		public static int UserOption = 0;

		public BasicEnglishTestPage()
		{
			Debug.WriteLine("BasicEnglishTestPage");
			InitializeComponent();


			//var q = App.SqlConn.Query<ELesson>("select * from Lesson");
			var q = App.SqlConn.Table<ELesson>();
			foreach (var item in q)
			{
				Debug.WriteLine(item.Title);
			}

		}

		async void OnClick(object sender, System.EventArgs e)
		{
			Button bt = (Button)sender;
			UserOption = bt.Text.Equals("Lý Thuyết") ? 0 : 1;

			await Navigation.PushAsync(new ListLesson());

	
		}
	}
}

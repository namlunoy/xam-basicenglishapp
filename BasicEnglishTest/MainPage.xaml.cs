using System.Diagnostics;
using Xamarin.Forms;
using System.Reflection;
using System.IO;
using System;

namespace BasicEnglishTest
{
	public partial class MainPage : ContentPage
	{
		public static UserOptions UserOption =  UserOptions.LEARN;

		public MainPage()
		{
			Debug.WriteLine("BasicEnglishTestPage");
			InitializeComponent();
		}

		async void OnClick(object sender, System.EventArgs e)
		{
			Button bt = (Button)sender;
			UserOption = bt.Text.Equals("Lý Thuyết") ? UserOptions.LEARN : UserOptions.PRACTICE;

			await Navigation.PushAsync(new ListLessonPage());
		}
	}
}

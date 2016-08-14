using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BasicEnglishTest
{
	public partial class LearnPage : ContentPage
	{
		public LearnPage()
		{
			InitializeComponent();
			Title = ListLessonPage.selectedLesson.Title;

			HtmlWebViewSource htmlSource = new HtmlWebViewSource();
			htmlSource.Html = ListLessonPage.selectedLesson.Content;
			myWebView.Source = htmlSource;
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new PracticePage());
		}
	}
}

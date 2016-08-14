using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace BasicEnglishTest
{
	public partial class ListLessonPage : ContentPage
	{
		public ObservableCollection<ELesson> lessons;
		public static ELesson selectedLesson;
		public ListLessonPage()
		{
			InitializeComponent();
			lessons = new ObservableCollection<ELesson>();
			var results = App.GetLessons();
			foreach (var item in results)
			{
				lessons.Add(item);
			}

			lvLesson.ItemsSource = lessons;
		}

		async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
			selectedLesson = e.SelectedItem as ELesson;
			Debug.WriteLine(">> " + selectedLesson.Title);
			if (MainPage.UserOption == UserOptions.LEARN)
			{
				await Navigation.PushAsync(new LearnPage());
			}
			else {
				await Navigation.PushAsync(new PracticePage());
			}
		}
	}
}

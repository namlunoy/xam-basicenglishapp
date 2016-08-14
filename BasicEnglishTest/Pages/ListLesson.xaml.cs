using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BasicEnglishTest
{
	public partial class ListLessonPage : ContentPage
	{
		public ObservableCollection<ELesson> lessons;
		public static ELesson selectedLesson;
		private IEnumerable<ELesson> results;
		public ListLessonPage()
		{
			InitializeComponent();
			lessons = new ObservableCollection<ELesson>();
			lvLesson.ItemsSource = lessons;


			this.Appearing += Handle_Appearing;
		}

		async void Handle_Appearing(object sender, EventArgs e)
		{
			if (lessons.Count == 0)
			{
				results = App.GetLessons();
				foreach (var item in results)
				{
					lessons.Add(item);
					await Task.Delay(100);
				}
			}
		}

		async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
			if (e != null && e.SelectedItem != null)
			{
				selectedLesson = e.SelectedItem as ELesson;
				if (selectedLesson != null)
				{
					if (MainPage.UserOption == UserOptions.LEARN)
					{
						await Navigation.PushAsync(new LearnPage(selectedLesson));
					}
					else {
						await Navigation.PushAsync(new PracticePage(selectedLesson));
					}
				}
				lvLesson.SelectedItem = null;
			}
		}
	}
}

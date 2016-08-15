using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BasicEnglishTest
{
	public partial class PracticePage : CarouselPage
	{
		public ELesson Lesson{get;set;}
		public ObservableCollection<EQuestion> Questions;
		private int Counter = 0;

		public PracticePage(ELesson lesson)
		{
			InitializeComponent();
			this.Lesson = lesson;
			this.BindingContext = Lesson;
			//this.InputTransparent = true;

			Questions = new ObservableCollection<EQuestion>();
			var questions = App.GetQuestion(this.Lesson.Id);

			int index = 0;
			foreach (var item in questions)
			{
				index++;
				item.Index = index;
				Questions.Add(item);
				var view = new QuestionView(item);
				this.Children.Add(view);
				view.OnAnswerSelected += View_OnAnswerSelected;
			}

		}

		async void View_OnAnswerSelected(BasicEnglishTest.EAnswer selectedAnswer)
		{
			int currentIndex = this.Children.IndexOf(this.CurrentPage);
			if (currentIndex + 1 < this.Children.Count)
			{
				// Next Question
				if (selectedAnswer.IsCorrect)
				{
					Counter++;
					await Task.Delay(300);
					this.CurrentPage = this.Children[currentIndex + 1];
				}
				else {
					// Hint
					if (App.IsProVerson)
					{
						if (selectedAnswer.Hint.Trim().Length > 2)
						{
							await DisplayAlert("Wrong!", selectedAnswer.Hint, "OK");
						}
						else
						{
							await Task.Delay(300);
						}
						this.CurrentPage = this.Children[currentIndex + 1];
					}
					else {
						// MISS
					}
				}
			}
			else {
				// Finish
				this.Lesson.Number = Counter;
				App.UpdateLesson(this.Lesson);

				await DisplayAlert("Finish!", string.Format("Your result: {0}/{1}",Counter,this.Questions.Count), "OK");
				await Navigation.PopAsync();
			}
		}


		void Handle_CurrentPageChanged(object sender, System.EventArgs e)
		{
			Debug.WriteLine("Handle_CurrentPageChanged");
		}

	
	}
}

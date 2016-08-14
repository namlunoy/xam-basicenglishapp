using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace BasicEnglishTest
{
	public partial class PracticePage : CarouselPage
	{
		public ELesson Lesson{get;set;}
		public ObservableCollection<EQuestion> Questions;
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

		void View_OnAnswerSelected(BasicEnglishTest.EAnswer obj)
		{
			int currentIndex = this.Children.IndexOf(this.CurrentPage);
			if (currentIndex + 1 < this.Children.Count)
			{
				// Next Question
				this.CurrentPage = this.Children[currentIndex + 1];
			}
			else {
				// Finish
			}
		}


		void Handle_CurrentPageChanged(object sender, System.EventArgs e)
		{
			Debug.WriteLine("Handle_CurrentPageChanged");
			//if (isSelected)
			//{
			//	isSelected = false;
			//}
			//else {
			//	int currentIndex = this.Children.IndexOf(this.CurrentPage);
			//	if (currentIndex + 1 < this.Children.Count)
			//	{
			//		isSelected = true;
			//		this.CurrentPage = this.Children[currentIndex + 1];
			//	}
			//}
		}

	
	}
}

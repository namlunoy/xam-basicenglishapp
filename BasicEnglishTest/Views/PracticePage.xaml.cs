using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

			Questions = new ObservableCollection<EQuestion>();
			var questions = App.GetQuestion(this.Lesson.Id);

			int index = 0;
			foreach (var item in questions)
			{
				index++;
				item.Index = index;
				Questions.Add(item);

				this.Children.Add(new QuestionView(item));
			}

		}
	}
}

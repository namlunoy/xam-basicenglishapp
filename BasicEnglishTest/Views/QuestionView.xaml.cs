using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BasicEnglishTest
{
	public partial class QuestionView : ContentPage
	{
		public event Action<EAnswer> OnAnswerSelected;
		public EQuestion Question{get;set;}

		public QuestionView()
		{
			InitializeComponent();
		}
		public QuestionView(EQuestion question)
		{
			InitializeComponent();
			this.Question = question;
			this.BindingContext = this.Question;

			foreach (var a in this.Question.Answers)
			{
				var view = new AnswerView(a);
				lvAnswers.Children.Add(view);
				view.OnAnswerSelected += View_OnAnswerSelected;
			}
		}

		void View_OnAnswerSelected(BasicEnglishTest.EAnswer obj)
		{
			foreach (var item in lvAnswers.Children)
			{
				item.IsEnabled = false;
			}
			if (OnAnswerSelected != null)
				OnAnswerSelected(obj);
		}
	}
}

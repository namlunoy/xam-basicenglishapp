using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BasicEnglishTest
{
	public partial class QuestionView : ContentPage
	{
		public event Action<EAnswer> OnAnswerSelected;
		public EQuestion Question{get;set;}
	

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
			foreach (AnswerView item in lvAnswers.Children)
			{
				item.Disable();
			}
			if (OnAnswerSelected != null)
				OnAnswerSelected(obj);
		}

		void Handle_ClickedHint(object sender, System.EventArgs e)
		{
			if (App.IsProVerson)
			{
				DisplayAlert("Hint", this.Question.Explanation, "OK");
			}
			else {
				// MISS
			}
		}
	}
}

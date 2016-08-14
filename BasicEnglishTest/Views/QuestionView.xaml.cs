using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BasicEnglishTest
{
	public partial class QuestionView : ContentPage
	{
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
				lvAnswers.Children.Add(new AnswerView(a));
			}
		}
	}
}

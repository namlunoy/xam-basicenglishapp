using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BasicEnglishTest
{
	public partial class AnswerView : ContentView
	{
		public EAnswer Answer{get;set;}
		public AnswerView(EAnswer answer)
		{
			InitializeComponent();
			this.Answer = answer;
			this.BindingContext = this.Answer;
		}
	}
}

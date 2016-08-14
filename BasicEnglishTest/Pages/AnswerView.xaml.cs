using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BasicEnglishTest
{
	public partial class AnswerView : ContentView
	{
		public EAnswer Answer{get;set;}
		public event Action<EAnswer> OnAnswerSelected;
		public static Color WRONG_COLOR = new Color(1, 0, 0);
		public static Color TRUE_COLOR = new Color(0, 1, 0);

		public AnswerView(EAnswer answer)
		{
			InitializeComponent();
			this.Answer = answer;
			this.BindingContext = this.Answer;
		}

		void Handle_Clicked(object sender, System.EventArgs e)
		{
			Debug.WriteLine("xxx");
			button.BackgroundColor = this.Answer.IsCorrect ? TRUE_COLOR : WRONG_COLOR;


			if (OnAnswerSelected != null)
				OnAnswerSelected(this.Answer);
		}

		public void Disable()
		{
			button.IsEnabled = false;
		}
	}
}

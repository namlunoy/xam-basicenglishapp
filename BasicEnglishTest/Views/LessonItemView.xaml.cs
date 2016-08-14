using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BasicEnglishTest
{
	public partial class LessonItemView : ContentView
	{
		public ELesson Lesson { get; set; }
		public LessonItemView(ELesson lesson)
		{
			InitializeComponent();
			this.Lesson = lesson;
			this.BindingContext = this.Lesson;
		}
	}
}

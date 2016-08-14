using System;
using System.Collections.Generic;
using System.ComponentModel;
using SQLite;

namespace BasicEnglishTest
{
	[Table("Lesson")]
	public class ELesson : INotifyPropertyChanged
	{
		[PrimaryKey, Column("id")]
		public int Id { get; set; }

		[Column("text")]
		public String Title { get; set; }

		[Column("content")]
		public String Content { get; set; }

		private int _number = 0;

		[Column("number")]
		public int Number
		{
			get { return _number; }
			set
			{
				if (value != _number)
				{
					_number = value;
					Notify("Title2");
				}
			}
		}

		[Column("total")]
		public int Total { get; set; }


		public int Percent
		{
			get { return Number * 100 / Total; }
		}

		public string Title2
		{
			get { return string.Format("Bài {0}: ({1}%)", Id, Percent); }
		}
		[Ignore]
		public List<EQuestion> Questions { get; set; }
		public ELesson()
		{ }

		public event PropertyChangedEventHandler PropertyChanged;
		private void Notify(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}

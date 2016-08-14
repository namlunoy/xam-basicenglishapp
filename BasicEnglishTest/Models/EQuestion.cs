using System;
using System.Collections.Generic;
using SQLite;

namespace BasicEnglishTest
{
	[Table("Question")]
	public class EQuestion
	{
		[PrimaryKey, Column("id")]
		public string Id { get; set; }

		[Column("text")]
		public string Title { get; set; }

		[Column("explan")]
		public string Explanation { get; set; }

		[Column("lesson_id")]
		public int LessonId{get;set;}

		public List<EAnswer> Answers { get; set; }
		public EQuestion() { }
	}
}

using System;
using System.Collections.Generic;
using SQLite;

namespace BasicEnglishTest
{
	[Table("Lesson")]
	public class ELesson
	{
		[PrimaryKey, Column("id")]
		public int Id { get; set; }

		[Column("text")]
		public String Title { get; set; }

		[Column("content")]
		public String Content { get; set; }

		public List<EQuestion> Questions { get; set; }
		public ELesson()
		{}
	}
}

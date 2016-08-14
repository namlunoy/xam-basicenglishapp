using System;
using SQLite;


namespace BasicEnglishTest
{
	[Table("Answer")]
	public class EAnswer
	{
		[PrimaryKey, Column("id")]
		public String Id { get; set; }

		[Column("text")]
		public String Content { get; set; }

		[Column("is_correct")]
		public bool IsCorrect { get; set; }

		[Column("hint")]
		public String Hint { get; set; }

		[Column("question_id")]
		public string QuestionId{get;set;}

		public EAnswer()
		{ }
	}
}

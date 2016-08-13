using System;
using System.Collections.Generic;
using SQLite;

namespace BasicEnglishTest
{
	public class EQuestion
	{
		[PrimaryKey, Column("id")]
		public String Id { get; set; }

		[Column("text")]
		public String Title { get; set; }

		[Column("explan")]
		public String Explanation { get; set; }

		public List<EAnswer> Answers { get; set; }
		public EQuestion() { }
	}
}

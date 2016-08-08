using System;
using System.Collections.Generic;

namespace BasicEnglishTest
{
	public class EQuestion
	{
		public String Id { get; set; }
		public String Title { get; set; }
		public String Explanation { get; set; }
		public List<EAnswer> Answers { get; set; }
		public EQuestion() { }
	}
}

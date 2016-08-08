using System;
using System.Collections.Generic;

namespace BasicEnglishTest
{
	public class ELesson
	{
		public int Id { get; set; }
		public String Title { get; set; }
		public String Content { get; set; }
		public List<EQuestion> Questions { get; set; }
		public ELesson()
		{
		}
	}
}

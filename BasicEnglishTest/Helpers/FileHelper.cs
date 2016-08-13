using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace BasicEnglishTest
{
	public class FileHelper
	{
		public static IPlatform currenPlatform;
		public FileHelper()
		{
			Debug.WriteLine("FileHelper()");
			currenPlatform = DependencyService.Get<IPlatform>();
		}
	}
}

using System;
using System.Diagnostics;
using System.IO;
using BasicEnglishTest.iOS;
using Foundation;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(Platform_IOS))]
namespace BasicEnglishTest.iOS
{
	public class Platform_IOS : IPlatform
	{
		public Platform_IOS()
		{ }

		private string GetPath(string fileName)
		{
			string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

			if (Directory.Exists(libFolder) == false)
				Directory.CreateDirectory(libFolder);

			string path = Path.Combine(libFolder, fileName);

			return path;
		}

		public void CopyFromResourceToDevice(string fileName)
		{
			string filePath = GetPath(fileName);
			if (File.Exists(filePath) == false)
			{
				Debug.WriteLine("File is copying...");
				string[] name = fileName.Split('.');
				string existDB = NSBundle.MainBundle.PathForResource(name[0], name[1]);
				File.Copy(existDB, filePath);
				Debug.WriteLine("File is copied!");
			}
			else {
				Debug.WriteLine("File " + fileName + " is already exits!");
			}
		}

		public SQLiteConnection GetConnection(string fileName)
		{
			CopyFromResourceToDevice(fileName);
			return new SQLiteConnection(GetPath(fileName));
		}
	}
}

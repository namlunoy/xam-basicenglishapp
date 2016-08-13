using System;
using System.IO;
using Android.Util;
using BasicEnglishTest.Droid;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(Platform_Android))]
namespace BasicEnglishTest.Droid
{
	public class Platform_Android : IPlatform
	{
		public Platform_Android()
		{ }

		private string GetPath(string fileName)
		{
			string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string filePath = Path.Combine(folder, fileName);
			return filePath;
		}

		public void CopyFromResourceToDevice(string fileName)
		{
			string newFilePath = GetPath(fileName);
			if (File.Exists(newFilePath) == false)
			{
				Log.Debug("> ","Copying...");
				using (var br = new BinaryReader(Android.App.Application.Context.Assets.Open(fileName)))
				{
					using (var bw = new BinaryWriter(new FileStream(newFilePath, FileMode.Create)))
					{
						byte[] buffer = new byte[2048];
						int length = 0;

						while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
						{
							bw.Write(buffer, 0, length);
						}
					}
				}
				Log.Debug("> ","Copied!");
			}
			else {
				Log.Debug("> ", "File is already exits!");
			}
		}

		public SQLiteConnection GetConnection(string fileName)
		{
			CopyFromResourceToDevice(fileName);
			return new SQLiteConnection(GetPath(fileName));
		}
	}
}

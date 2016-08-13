using System;
using SQLite;

namespace BasicEnglishTest
{
	/// <summary>
	/// Contains things about platform specific
	/// </summary>
	public interface IPlatform
	{
		void CopyFromResourceToDevice(string fileName);
		SQLiteConnection GetConnection(string fileName);
	}
}

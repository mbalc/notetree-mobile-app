using NoteTree;
using System;
using System.IO;
using Xamarin.Forms;


[assembly: Dependency(typeof(FileHelper))]
namespace NoteTree
{
	public class FileHelper : NoteTree.IFileHelper
    {
		public string GetLocalFilePath(string filename)
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			return Path.Combine(path, filename);
		}
	}
}
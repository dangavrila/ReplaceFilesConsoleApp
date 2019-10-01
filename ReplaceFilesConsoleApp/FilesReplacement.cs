using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace ReplaceFilesConsoleApp
{
	public class FilesReplacement : IFilesReplacement
	{
		public string[] GetFileNames(string location)
		{
			DirectoryInfo di = new DirectoryInfo(location);
			var fi = di.GetFiles();

			List<string> fileNames = new List<string>(fi.Length);

			for (int i = 0; i < fi.Length; i++)
			{
				fileNames.Add(fi[i].Name);
			}

			return fileNames.ToArray();
		}

		public string[] GetFilesFromSource(string location, string[] fileNamesAtDest)
		{
			DirectoryInfo di = new DirectoryInfo(location);
			List<string> fileNames = new List<string>();

			for (int i = 0; i < fileNamesAtDest.Length; i++)
			{
				var fi = new FileInfo(Path.Combine(location, fileNamesAtDest[i]));
				if(fi.Exists)
					fileNames.Add(fi.FullName);
			}

			return fileNames.ToArray();
		}

		public DateTime GetLastModifiedDateTime(string filePath)
		{
			var fi = new FileInfo(filePath);
			return fi.LastWriteTime;
		}

		public DateTime Replace(string sourceFilePath, string destFilePath)
		{
			return DateTime.MinValue;
		}
	}
}

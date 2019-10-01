using System;
using System.Collections.Generic;
using System.Text;

namespace ReplaceFilesConsoleApp
{
	public interface IFilesReplacement
	{
		string[] GetFileNames(string location);
		string[] GetFilesFromSource(string sourceFolder, string[] fileNamesAtDest);
		DateTime GetLastModifiedDateTime(string filePath);
		bool Replace(string sourceFilePath, string destFilePath);
	}
}

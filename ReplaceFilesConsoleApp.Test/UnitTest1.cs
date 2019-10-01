using System;
using NUnit.Framework;

namespace ReplaceFilesConsoleApp.Test
{
	public class Tests
	{
		private string destFolder;
		private string sourceFolder;
		private IFilesReplacement _filesReplacement;
		private TimeSpan maxTimeSpanBetweenReplacements;

		[SetUp]
		public void Setup()
		{
			_filesReplacement = new FilesReplacement();

			destFolder =
				@"DestFolder";
			sourceFolder = @"SourceFolder";

			maxTimeSpanBetweenReplacements = new TimeSpan(0, 15, 0);
		}

		[Test]
		public void TestFilesExistAtDestination()
		{
			string[] fileNames = _filesReplacement.GetFileNames(destFolder);
			Assert.AreEqual(46, fileNames.Length);
		}

		[Test]
		public void TestFilesExistAtSource()
		{
			string[] fileNamesAtDest = _filesReplacement.GetFileNames(destFolder);
			string[] fileNamesAtSource = _filesReplacement.GetFilesFromSource(sourceFolder, fileNamesAtDest);

			Assert.AreEqual(fileNamesAtDest.Length, fileNamesAtSource.Length);
		}

		[Test]
		public void TestReplace()
		{
			// Arrange
			var destFileNames = _filesReplacement.GetFileNames(destFolder);
			var sourceFileNames = _filesReplacement.GetFileNames(sourceFolder);
			var destFilePaths = _filesReplacement.GetFilesFromSource(destFolder, destFileNames);
			var sourceFilePaths = _filesReplacement.GetFilesFromSource(sourceFolder, sourceFileNames);

			for (int i = 0; i < destFilePaths.Length; i++)
			{
				// Act
				bool replaced = _filesReplacement.Replace(sourceFilePaths[i], destFilePaths[i]);

				// Assert
				DateTime lastModifiedDate = _filesReplacement.GetLastModifiedDateTime(destFilePaths[i]);
				Assert.AreEqual(DateTime.Now.Date, lastModifiedDate.Date);
				Assert.LessOrEqual(lastModifiedDate.Minute, maxTimeSpanBetweenReplacements.Minutes);
			}
		}
	}
}
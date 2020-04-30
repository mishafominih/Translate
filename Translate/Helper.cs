using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Translate
{
	public class Helper
	{
		private static List<string> NameFiles = new List<string>();

		public static IEnumerable<string> SplitOnWords(string text)
		{
			foreach (var word in text.Split(new[] {
				' ', ',', '.', '\'', '"', ':', ';', '!', '?' },
				StringSplitOptions.RemoveEmptyEntries))
			{
				yield return word;
			}
		}

		public static IEnumerable<string> SplitOnSentence(string text)
		{
			foreach (var sentence in text.Split(new[] { '.', '!', '?' },
				StringSplitOptions.RemoveEmptyEntries)
				.Select(x => (x[0] == ' ') ? x.Remove(0, 1) : x))
			{
				yield return sentence;
			}
		}

		public static IEnumerable<string> GetNameFiles()
		{
			foreach (var name in NameFiles)
				yield return name;
		}

		public static void SaveText(string nameFile, string text)
		{
			if (!NameFiles.Contains(nameFile)) NameFiles.Add(nameFile);
			File.WriteAllText("texts\\" + nameFile, text);
		}

		public static string GetText(string nameFile)
		{
			return File.ReadAllText("texts\\" + nameFile);
		}
	}
}

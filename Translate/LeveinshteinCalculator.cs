using System;
using System.Collections.Generic;

using DocumentTokens = System.Collections.Generic.List<string>;

namespace Translate
{
	public class LevenshteinCalculator
	{
		public static double GetCompare(DocumentTokens document1, DocumentTokens document2)
		{
			var arr = InitialiseArray(document1, document2);
			FillArray(document1, document2, arr);
			return arr[document1.Count, document2.Count];
		}

		private static void FillArray(DocumentTokens document1, DocumentTokens document2, double[,] arr)
		{
			for (int i = 1; i <= document1.Count; i++)
			{
				for (int j = 1; j <= document2.Count; j++)
				{
					if (document1[i - 1] != document2[j - 1])
						arr[i, j] = GetValue(document1, document2, arr, i, j);
					else arr[i, j] = arr[i - 1, j - 1];
				}
			}
		}

		private static double GetValue(DocumentTokens document1, DocumentTokens document2, double[,] arr, int i, int j)
		{
			return Math.Min(
				TokenDistanceCalculator.GetTokenDistance(
					document1[i - 1],
					document2[j - 1]) + arr[i - 1, j - 1],
				Math.Min(1 + arr[i - 1, j], 1 + arr[i, j - 1]));
		}

		private static double[,] InitialiseArray(DocumentTokens document1, DocumentTokens document2)
		{
			var arr = new double[document1.Count + 1, document2.Count + 1];
			for (int i = 0; i <= document1.Count; i++)
			{
				arr[i, 0] = i;
			}
			for (int i = 0; i <= document2.Count; i++)
			{
				arr[0, i] = i;
			}
			return arr;
		}
	}

	public static class TokenDistanceCalculator
	{
		public static double GetTokenDistance(string token1, string token2)
		{
			var commonLetters = new HashSet<char>(token1);
			commonLetters.IntersectWith(new HashSet<char>(token2));
			var allLetters = new HashSet<char>(token1);
			allLetters.UnionWith(new HashSet<char>(token2));
			return 1 - commonLetters.Count / (double)allLetters.Count;
		}
	}
}
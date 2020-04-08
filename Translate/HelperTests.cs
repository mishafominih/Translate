using System.Linq;
using NUnit.Framework;

namespace Translate
{
	[TestFixture]
	class Tests
	{
		[TestCase("Hello, world", new string[] { "Hello", "world" })]
		public void TestSplitOnWords(string Start, string[] expected)
		{
			Assert.AreEqual(expected, Helper.SplitOnWords(Start));
		}

		[TestCase("Hello, my friend. World, i love you", new string[] { "Hello, my friend", "World, i love you" })]
		public void TestSplitOnSentence(string Start, string[] expected)
		{
			Assert.AreEqual(expected, Helper.SplitOnSentence(Start));
		}

		[Test]
		public void TestSaveText()
		{
			Helper.SaveText("test.txt", "hello");
			Assert.AreEqual(1, Helper.GetNameFiles().Count());
			Assert.AreEqual("hello", Helper.GetText("test.txt"));
			Helper.SaveText("test.txt", "world");
			Assert.AreEqual(1, Helper.GetNameFiles().Count());
			Assert.AreEqual("world", Helper.GetText("test.txt"));
		}
	}
}

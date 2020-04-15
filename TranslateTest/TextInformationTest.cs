using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Translate;

namespace TranslateTest
{
    [TestClass]
    public class TextInformationTest
    {
        [TestMethod]
        public void AddAndGetTestMethod()
        {
            var text = new TextInformation();
            text.Add("Мир нужен для того, чтобы в нем жить", "Мир и жизнь");
            text.Add("Поговорим о любви", "Любовь");
            Assert.AreEqual("Мир нужен для того, чтобы в нем жить", text.GetText("Мир и жизнь"));
            Assert.AreEqual("Поговорим о любви", text.GetText("Любовь"));
        }
    }
}

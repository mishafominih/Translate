using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Translate;

namespace TranslateTest
{
    [TestClass]
    public class TranslateTextTest
    {
        [TestMethod]
        public void TranslateTest()
        {
            var text = TranslateText.GetTextTranslation("Шел снег, я бежал по улице. Моя собака наблюдала за падающими снежинками.");
            Assert.AreEqual("Шел снег, я бежал по улице. Моя собака наблюдала за падающими снежинками.", text);
            text = TranslateText.GetTextTranslation("Привет.");
            Assert.AreEqual("Привет.", text);
        }

        [TestMethod]
        public void EmptyLineTest()
        {
            var text = TranslateText.GetTextTranslation("");
            Assert.AreEqual("", text);
        }

        [TestMethod]
        public void NullTest()
        {
            var text = TranslateText.GetTextTranslation(null);
            Assert.AreEqual("", text);
        }
    }
}

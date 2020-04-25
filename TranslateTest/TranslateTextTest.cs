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
            var text = new TranslateText("Шел снег, я бежал по улице. Моя собака наблюдала за падающими снежинками.");
            var newText = text.GetTextTranslation();
            Assert.AreEqual("Шел снег, я бежал по улице. Моя собака наблюдала за падающими снежинками.", newText);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translate
{
    public class TranslateText
    {
        public static string[] Text { get; private set; }

        public TranslateText(string text)
        {
            Text = text.Split(' ');
        }

        // Перевод самого текста 
        public string GetTextTranslation()
        {
            var result = new StringBuilder();
            result.Append(GetSentenceTranslation(Text[0]));
            for(var i = 1; i < Text.Length; i++)
            {
                var sentence = GetSentenceTranslation(Text[i]);
                result.Append(' ' + sentence);
            }
            return result.ToString();
        }

        // Переводим предложения 
        private static string GetSentenceTranslation(string sentence)
        {
            string newSentence;
            var len = sentence.Length - 1;
            if (!Char.IsLetter(sentence, len))
                return newSentence = GetWordTranslation(sentence.Remove(len)) + sentence[len];
            return newSentence = GetWordTranslation(sentence);
        }

        // Тут мы будем переводить слова, обращаясь к словарю.
        private static string GetWordTranslation(string sentence)
        {
            return sentence;
        }
    }
}

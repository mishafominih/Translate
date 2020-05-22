using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translate
{
    public class TranslateText
    {
        // Перевод самого текста 
        public static string GetTextTranslation(string data)
        {
            if (data == null || data.Length <= 0)
                return "";
            var text = data.Split(' ');
            var result = new StringBuilder();
            result.Append(GetSentenceTranslation(text[0]));
            for(var i = 1; i < text.Length; i++)
            {
                var sentence = GetSentenceTranslation(text[i]);
                result.Append(' ' + sentence);
            }
            return result.ToString();
        }

        // Переводим предложения 
        private static string GetSentenceTranslation(string sentence)
        {
            var len = sentence.Length - 1;
            if (!Char.IsLetter(sentence, len))
                return GetWordTranslation(sentence.Remove(len)) + sentence[len];
            return GetWordTranslation(sentence);
        }

        // Тут мы будем переводить слова, обращаясь к словарю.
        private static string GetWordTranslation(string sentence)
        {
			return Translator.TranslateWord(sentence);
        }
    }
}

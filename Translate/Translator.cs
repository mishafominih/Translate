using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

public static class Translator
{
        private static Dictionary<string, string> KnownWords = new Dictionary<string, string>();

        public static Dictionary<string, string> LoadDictionaryFrom(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    string[] array;
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        array = line.Split('-');
                        KnownWords.Add(array[0], array[1]);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return KnownWords;
        }

        public static string TranslateWord(string word)
        {
            return KnownWords.ContainsKey(word) ? KnownWords[word] : "[-]";
        }

        public static string TranslateSentence(string sentence)
        {
            var result = new StringBuilder("");
            var builder = new StringBuilder(sentence);
            var words = sentence
                        .Split(new[] { ' ', ',', '.', '\'', '"', ':', ';', '!', '?' },
                               StringSplitOptions.RemoveEmptyEntries);

            foreach(var currentWord in words)
            {
                builder.Remove(0, currentWord.Length);
                result.Append(TranslateWord(currentWord));
                while(builder.Length > 0 && !char.IsLetter(builder[0]))
                {
                    result.Append(builder[0]);
                    builder.Remove(0, 1);
                }
            }

            return result.ToString();
        }
}
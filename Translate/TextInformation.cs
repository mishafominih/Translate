using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Translate
{
    public class TextInformation
    {
        private static Dictionary<string, string> Texts = new Dictionary<string, string>();

        public void Add(string newText, string title)
        {
            if (Texts.ContainsKey(title))
                Texts.Remove(title);
            Texts.Add(title, newText);
        }

        public string GetText(string title)
        {
           
            if (!Texts.ContainsKey(title))
                throw new KeyNotFoundException("Текста с таким заголовком нет");
            return Texts[title];
        }
    }
}

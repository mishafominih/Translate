using System;
using System.Collections.Generic;
using System.Linq;

namespace Translate
{
    public class RevisingTask
    {
        private readonly List<Word> KnownWordsList;
        private readonly int OptionsCount;
        public readonly Tuple<string, List<Tuple<string, bool>>> Case;
                     // Tuple<слово на англ, Список вариантов ответа>

        public RevisingTask(Word word, int optionsCount, List<Word> knownWordsList)
        {
            KnownWordsList = knownWordsList
                .Where(currentWord => currentWord.GetHashCode() != word.GetHashCode())
                .ToList();

            if(KnownWordsList.Count < optionsCount)
                throw new ArgumentException("KnownWordsList is too small");

            OptionsCount = optionsCount;

            Case = MakeTaskCaseFrom(word);
        }

        private Tuple<string, List<Tuple<string, bool>>> MakeTaskCaseFrom(Word word)
        {
            var optionsList = new List<Tuple<string, bool>>();

            Random rnd = new Random();
            for(var count = 0; count < OptionsCount - 1; count++)
            {
                var index = rnd.Next(0, KnownWordsList.Count);
                var optionCase = Tuple.Create(KnownWordsList[index].Translation, false);
                optionsList.Add(optionCase);
            }
            optionsList.Add(Tuple.Create(word.Translation, true));
            //Заметка - Добавить перемешивание вариантов ответа

            return Tuple.Create(word.Translation, optionsList);
        }
    }
}
using System;

namespace Translate
{
    public class Word
    {
        public string Original { get; }
        public string Transcription { get; }
        public string Translation { get; }
        public DateTime DateOfAdd { get; }
        public DateTime DateOfRevise { get; set; }

        public Word(string original, string transcription, string translation, DateTime date)
        {
            Original = original;
            Transcription = transcription;
            Translation = translation;
            DateOfAdd = date;
        }

        public override int GetHashCode()
        {
            return Original.GetHashCode() + Translation.GetHashCode();
        }
    }
}
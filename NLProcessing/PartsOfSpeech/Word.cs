using System;
using System.Collections.Generic;
using System.Text;

namespace NLProcessing
{
    public class Word
    {
        public readonly string Value;
        public readonly List<string> PossiblePartsOfSpeech;

        private int _partOfSpeechIndex;
        public int PartOfSpeechIndex {
            get => _partOfSpeechIndex;
            set {
                _partOfSpeechIndex = value;
                while (_partOfSpeechIndex >= PossiblePartsOfSpeech.Count && PossiblePartsOfSpeech.Count >= 1)
                {
                    _partOfSpeechIndex -= PossiblePartsOfSpeech.Count;
                }
                while (_partOfSpeechIndex < 0 && PossiblePartsOfSpeech.Count >= 1)
                {
                    _partOfSpeechIndex += PossiblePartsOfSpeech.Count;
                }
            }
        }

        public string PartOfSpeech
        {
            get => PossiblePartsOfSpeech[PartOfSpeechIndex];
        }

        public Word(string value, List<string> possiblePartsOfSpeech)
        {
            Value = value;
            PossiblePartsOfSpeech = possiblePartsOfSpeech;
            PartOfSpeechIndex = 0;
        }
    }
}

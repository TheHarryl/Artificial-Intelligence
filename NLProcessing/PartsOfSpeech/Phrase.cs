using System;
using System.Collections.Generic;
using System.Text;

namespace NLProcessing
{
    public class Phrase
    {
        public readonly List<Word> Words;
        public readonly List<Word> Conjunctions;

        public Phrase(List<Word> words, List<Word> conjunctions)
        {
            Words = words;
            Conjunctions = conjunctions;
        }
    }
}

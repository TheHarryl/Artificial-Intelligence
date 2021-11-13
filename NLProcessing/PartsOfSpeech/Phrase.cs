using System;
using System.Collections.Generic;
using System.Text;

namespace NLProcessing
{
    public class Phrase
    {
        public List<Word> Words { get; }
        public List<Word> Conjunctions { get; }

        public Phrase(List<Word> words, List<Word> conjunctions)
        {
            Words = words;
            Conjunctions = conjunctions;
        }
    }
}

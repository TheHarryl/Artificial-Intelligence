using System;
using System.Collections.Generic;
using System.Text;

namespace NLProcessing
{
    public class Sentence
    {
        public readonly List<Clause> Clauses;
        public readonly List<Word> Conjunctions;
        
        public Sentence(List<Clause> clauses, List<Word> conjunctions)
        {
            Clauses = clauses;
            Conjunctions = conjunctions;
        }
    }
}

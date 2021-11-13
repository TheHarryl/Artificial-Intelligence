using System;
using System.Collections.Generic;
using System.Text;

namespace NLProcessing
{
    public class Sentence
    {
        public List<Clause> Clauses { get; }
        public List<Word> Conjunctions { get; }
        
        public Sentence(List<Clause> clauses, List<Word> conjunctions)
        {
            Clauses = clauses;
            Conjunctions = conjunctions;
        }
    }
}

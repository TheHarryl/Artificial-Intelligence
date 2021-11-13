using System;
using System.Collections.Generic;
using System.Text;

namespace NLProcessing
{
    public class Clause
    {
        public Phrase Subjects { get; }
        public Predicate Predicate { get; }

        public Clause(Phrase subjects, Predicate predicate)
        {
            Subjects = subjects;
            Predicate = predicate;
        }
    }
}

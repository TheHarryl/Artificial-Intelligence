using System;
using System.Collections.Generic;
using System.Text;

namespace NLProcessing
{
    public class Clause
    {
        public readonly Phrase Subjects;
        public readonly Predicate Predicate;

        public Clause(Phrase subjects, Predicate predicate)
        {
            Subjects = subjects;
            Predicate = predicate;
        }
    }
}

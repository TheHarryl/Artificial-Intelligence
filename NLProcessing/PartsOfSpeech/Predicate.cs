using System;
using System.Collections.Generic;
using System.Text;

namespace NLProcessing
{
    public class Predicate
    {
        public Phrase HelpingVerbs { get; }
        public Phrase Verbs { get; }
        public Phrase DirectObjects { get; }
        public Phrase IndirectObjects { get; }

        public Predicate(Phrase helpingVerbs, Phrase verbs, Phrase directObjects, Phrase indirectObjects)
        {
            HelpingVerbs = helpingVerbs;
            Verbs = verbs;
            DirectObjects = directObjects;
            IndirectObjects = indirectObjects;
        }
    }
}

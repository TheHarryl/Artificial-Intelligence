using System;
using System.Collections.Generic;
using System.Text;

namespace NLProcessing
{
    public class Predicate
    {
        public readonly Phrase HelpingVerbs;
        public readonly Phrase Verbs;
        public readonly Phrase DirectObjects;
        public readonly Phrase IndirectObjects;

        public Predicate(Phrase helpingVerbs, Phrase verbs, Phrase directObjects, Phrase indirectObjects)
        {
            HelpingVerbs = helpingVerbs;
            Verbs = verbs;
            DirectObjects = directObjects;
            IndirectObjects = indirectObjects;
        }
    }
}

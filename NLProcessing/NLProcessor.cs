using System;
using System.Collections.Generic;
using System.Text;

namespace NLProcessing
{
    public static class NLProcessor
    {
        public static List<Sentence> ProcessText(String text)
        {
            List<Word> words = Compiler.Run(text);
            return Diagrammer.Run(words);
        }
    }
}

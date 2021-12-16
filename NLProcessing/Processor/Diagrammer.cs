using System;
using System.Collections.Generic;
using System.Text;

namespace NLProcessing
{
    public static class Diagrammer
    {
        public static List<Sentence> Run(List<Word> words)
        {
            return Run(new List<List<Word>>() { words });
        }

        public static List<Sentence> Run(List<List<Word>> words)
        {
            for (int x = 0; x < words.Count; x++)
            {
                for (int i = 0; i < words[x].Count; i++)
                {
                    words[x][i].PartOfSpeechIndex++;
                    if (words[x][i].PartOfSpeechIndex == 0)
                    {
                        words[x][i]._partOfSpeechIndex = -1;
                        i--;
                    }
                    if (IsValid(words[x]))
                    {
                        if (i - 1 != words.Count)
                        {
                            return Run(words);
                        }
                    } else
                    {
                        return Run(words);
                    }
                }
                if (!IsValid(words[x]))
                {
                    if (words[x + 1] != null)
                    {
                        words[x + 1].Add(words[x][0]);
                    } else
                    {
                        words.Add(new List<Word> { words[x][0] });
                    }
                    words[x].Remove(words[x][0]);
                    return Run(words);
                }
            }
            return ConvertToSentences(words);
        }

        private static List<Sentence> ConvertToSentences(List<List<Word>> sentences)
        {
            List<Sentence> newSentences = new List<Sentence>();
            for (int i = 0; i < sentences.Count; i++)
            {
                List<Clause> clauses = new List<Clause>();
                List<Word> conjunctions = new List<Word>();
                newSentences.Add(new Sentence(clauses, conjunctions));
            }
            return newSentences;
        }

        private static bool IsValid(List<Word> words)
        {
            List<Word> prevWords = new List<Word>();
            List<Word> nextWords;
            for (int i = 0; i < words.Count; i++)
            {
                nextWords = words.GetRange(i + 1, words.Count - i - 1);
                Word word = words[i];
                if (word.PartOfSpeech.Count > 1)
                {
                    break;
                }
                else if (word.PartOfSpeech[0] == "Noun" || word.PartOfSpeech[0] == "Pronoun")
                {
                    if (
                        FindTargetWord(prevWords, new List<string>() { "Determiner", "Adjective", "Adverb", "Conjunction" }, "Preposition") ||
                        FindTargetWord(nextWords, new List<string>() { "Adverb", "Noun", "Pronoun" }, "Verb") ||
                        FindTargetWord(prevWords, new List<string>() { "Adverb", "Adjective", "Noun", "Pronoun" }, "Verb")
                    )
                    {
                        continue;
                    }
                }
                else if (word.PartOfSpeech[0] == "Verb")
                {
                    if (
                        FindTargetWord(prevWords, new List<string>() { "Adverb", "Conjunction" }, "Verb") ||
                        FindTargetWord(nextWords, new List<string>() { "Adverb", "Conjunction" }, "Verb") ||
                        (!WordExists(prevWords, "Verb") && !WordExists(nextWords, "Verb"))
                    )
                    {
                        continue;
                    }
                }
                else if (word.PartOfSpeech[0] == "Adjective")
                {
                    if (
                        FindTargetWord(prevWords, new List<string>() { "Adjective", "Conjunction", "Adverb" }, "Verb") ||
                        FindTargetWord(prevWords, new List<string>() { "Conjunction" }, "Adjective") ||
                        FindTargetWord(nextWords, new List<string>() { "Conjunction" }, "Adjective") ||
                        FindTargetWord(nextWords, new List<string>(), "Noun")
                    )
                    {
                        continue;
                    }
                }
                else if (word.PartOfSpeech[0] == "Adverb")
                {
                    if (
                        FindTargetWord(nextWords, new List<string>() { "Conjunction" } , "Adverb") ||
                        FindTargetWord(nextWords, new List<string>() { "Adverb", "Conjunction" }, "Adjective") ||
                        FindTargetWord(prevWords, new List<string>() { "Adverb", "Conjunction" }, "Verb") ||
                        FindTargetWord(nextWords, new List<string>() { "Adverb", "Conjunction" }, "Verb")
                    )
                    {
                        continue;
                    }
                }
                else if (word.PartOfSpeech[0] == "Determiner")
                {
                    if (
                        FindTargetWord(nextWords, new List<string>() { "Adjective", "Adverb", "Conjunction" }, "Noun")
                    )
                    {
                        continue;
                    }
                }
                else if (word.PartOfSpeech[0] == "Conjunction")
                {
                    if (
                        (FindTargetWord(prevWords, new List<string>() { "Adverb", "Conjunction" }, "Verb") &&
                        FindTargetWord(nextWords, new List<string>() { "Adverb", "Conjunction" }, "Verb")) ||
                        (FindTargetWord(prevWords, new List<string>() { "Adverb", "Conjunction" }, "Adjective") &&
                        FindTargetWord(nextWords, new List<string>() { "Adverb", "Conjunction" }, "Adjective")) ||
                        (FindTargetWord(prevWords, new List<string>() { "Determiner", "Adjective", "Adverb", "Conjunction" }, "Noun") &&
                        FindTargetWord(nextWords, new List<string>() { "Determiner", "Adjective", "Adverb", "Conjunction" }, "Noun"))
                    )
                    {
                        continue;
                    }
                }
                else if (word.PartOfSpeech[0] == "Preposition")
                {
                    if (
                        FindTargetWord(prevWords, new List<string>(), "Preposition") ||
                        FindTargetWord(nextWords, new List<string>(), "Preposition") ||
                        FindTargetWord(nextWords, new List<string>() { "Determiner", "Adjective", "Adverb", "Conjunction"}, "Noun")
                    )
                    {
                        continue;
                    }
                }
                return false;
            }
            return true;
        }
        
        private static bool FindTargetWord(List<Word> toCheck, List<string> allowedPartsOfSpeech, string targetPartOfSpeech)
        {
            for (int i = 0; i < toCheck.Count; i++)
            {
                Word word = toCheck[i];
                if (word.PartOfSpeech.Contains(targetPartOfSpeech))
                    return true;
                else
                {
                    bool containsAllowed = false;
                    for (int x = 0; x < allowedPartsOfSpeech.Count && !containsAllowed; x++)
                    {
                        if (word.PartOfSpeech.Contains(allowedPartsOfSpeech[x]))
                            containsAllowed = true;
                    }
                    if (!containsAllowed)
                        return false;
                }
            }
            return false;
        }

        private static bool WordExists(List<Word> toCheck, string targetPartOfSpeech)
        {
            for (int i = 0; i < toCheck.Count; i++)
            {
                Word word = toCheck[i];
                if (word.PartOfSpeech.Contains(targetPartOfSpeech))
                    return true;
            }
            return false;
        }
    }
}

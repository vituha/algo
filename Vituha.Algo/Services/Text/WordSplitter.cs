using System.Collections.Generic;
using System.Linq;

namespace Visuha.Algo.Services.Text
{
    public sealed class WordSplitter
    {
        private readonly ILookup<char, string> _dictionary;

        public WordSplitter(IEnumerable<string> dictionaryWords)
        {
            _dictionary = dictionaryWords.ToLookup(w => w[0]);
        }

        public IEnumerable<IEnumerable<string>> Split(string source)
        {
            ICollection<Sentence> sentences = new HashSet<Sentence>();

            using (IEnumerator<char> chars = source.GetEnumerator())
            {
                if (chars.MoveNext())
                {
                    InitializeSentences(sentences, chars.Current);

                    while (chars.MoveNext())
                    {
                        char c = chars.Current;
                        foreach (Sentence sentence in sentences.ToArray()) // making a copy since sentences can be modified
                        {
                            if (sentence.CandidatePromoted())
                            {
                                DiscoverNewCandidates(sentences, sentence, c);
                            }
                            else
                            {
                                if (CharEqual(sentence.Expected(), c))
                                {
                                    sentence.Advance();
                                }
                                else
                                {
                                    sentences.Remove(sentence);
                                }
                            }
                        }
                    }
                }
            }

            foreach (Sentence sentence in sentences)
            {
                if (sentence.CandidatePromoted())
                {
                    yield return sentence.Words;
                }
            }
        }

        private void InitializeSentences(ICollection<Sentence> sentences, char c)
        {
            using (IEnumerator<string> candidates = FindWords(c).GetEnumerator())
            {
                InitializeSentences(sentences, new string[0], candidates);
            }
        }

        private static void InitializeSentences(
            ICollection<Sentence> sentences,
            IReadOnlyCollection<string> words,
            IEnumerator<string> candidates)
        {
            while (candidates.MoveNext())
            {
                var sentence = new Sentence(words);
                sentences.Add(sentence);

                sentence.NewCandidate(candidates.Current);
            }
        }

        private void DiscoverNewCandidates(ICollection<Sentence> sentences, Sentence original, char firstChar)
        {
            using (IEnumerator<string> candidates = FindWords(firstChar).GetEnumerator())
            {
                if (candidates.MoveNext())
                {
                    string firstWord = candidates.Current;

                    InitializeSentences(sentences, original.Words, candidates);

                    original.NewCandidate(firstWord);
                }
                else
                {
                    sentences.Remove(original); // no matches on firstChar
                }
            }
        }

        private IEnumerable<string> FindWords(char c)
        {
            return _dictionary[c];
        }

        private static bool CharEqual(char x, char y)
        {
            return x == y;
        }
    }
}
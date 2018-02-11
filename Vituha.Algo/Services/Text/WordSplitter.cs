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
            var sentences = new HashSet<Sentence>();
            using (var en = source.GetEnumerator())
            {
                if (en.MoveNext())
                {
                    char c = en.Current;
                    InitializeSentences(sentences, c);

                    while (en.MoveNext())
                    {
                        c = en.Current;
                        foreach (Sentence sentence in sentences.ToArray())
                        {
                            if (sentence.CandidatePromoted())
                            {
                                sentences.Remove(sentence);
                                foreach (string word in FindWords(c))
                                {
                                    var newSencence = new Sentence(sentence);
                                    newSencence.NewCandidate(word);

                                    sentences.Add(newSencence);
                                }
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

        private void InitializeSentences(ICollection<Sentence> sentences, char firstChar)
        {
            foreach (string word in FindWords(firstChar))
            {
                var sentence = new Sentence();
                sentence.NewCandidate(word);

                sentences.Add(sentence);
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
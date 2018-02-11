using System;
using System.Collections.Generic;
using System.Linq;

namespace Visuha.Algo.Services.Text
{
    internal sealed class Sentence
    {
        private readonly List<string> _words;
        private string _candidate;
        private int _candidateIndex;

        public Sentence(Sentence source)
        {
            _words = source._words.ToList();
        }

        public Sentence()
        {
            _words = new List<string>();
        }

        public IReadOnlyList<string> Words => _words.AsReadOnly();

        public char Expected()
        {
            return _candidate[_candidateIndex];
        }

        public void NewCandidate(string word)
        {
            if (word.Length == 0)
            {
                throw new Exception("Non-empty string expected.");
            }

            _candidate = word;
            _candidateIndex = 0;

            Advance();
        }

        public void Advance()
        {
            if (_candidate == null)
            {
                throw new Exception("No word to advance.");
            }

            _candidateIndex++;

            if (_candidateIndex == _candidate.Length)
            {
                Promote();
            }
        }

        private void Promote()
        {
            _words.Add(_candidate);
            
            _candidate = null;
            _candidateIndex = 0;
        }

        public bool CandidatePromoted()
        {
            return _candidate == null;
        }
    }
}
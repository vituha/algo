using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Visuha.Algo.Services.Text
{
    public class WordSplitterTests
    {
        [Fact]
        public void Empty()
        {
            var sut = new WordSplitter(new string[0]);

            sut.Split(string.Empty).Should().BeEmpty("no words in text");
        }

        [Fact]
        public void SingleWord()
        {
            var sut = new WordSplitter(new[] { "fox" });

            sut.Split("fox").Should().BeEquivalentTo(new object[] { new[] { "fox" } });
        }

        [Fact]
        public void TwoWords()
        {
            var sut = new WordSplitter(new[] { "fox", "brown" });

            sut.Split("brownfox").Single().Should().Equal("brown", "fox");
        }

        [Fact]
        public void TwoSentences()
        {
            var sut = new WordSplitter(new[] { "xyy", "yyzzz", "x", "zzz" });

            sut.Split("xyyzzz").Should().BeEquivalentTo(new object[]
            {
                new [] {"x", "yyzzz"},
                new [] {"xyy", "zzz"}
            });
        }

        [Fact]
        public void LastCharNotMatching()
        {
            var sut = new WordSplitter(new[] { "x" });

            sut.Split("xy").Should().BeEmpty();
        }

        [Fact]
        public void FirstCharNotMatching()
        {
            var sut = new WordSplitter(new[] { "y" });

            sut.Split("xy").Should().BeEmpty();
        }

        [Fact]
        public void RealLife()
        {
            var sut = new WordSplitter(new[] { "girl", "boy", "friend", "end", "girlfriend", "boyfriend" });

            var expected = new[]
            {
                "girl friend boy friend",
                "girlfriend boy friend",
                "girl friend boyfriend",
                "girlfriend boyfriend",
            };

            var actual = sut.Split("girlfriendboyfriend").Select(s => string.Join(" ", s)).ToArray();

            actual.Should().BeEquivalentTo(expected);

            foreach (IEnumerable<string> sentences in sut.Split("girlfriendboyfriend"))
            {
                Console.WriteLine(string.Join(" ", sentences));
            }
        }
    }
}

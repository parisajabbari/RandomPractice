using System;
using Xunit;
using project;
using System.Collections.Generic;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void FindWinner_shouldReturnWinner()
        {
            List<string> votes = new List<string>{"A","A", "A", "B", "B"};

            Assert.Equal("A", VoteCounter.FindWinner(votes));

        }
        [Fact]
        public void PrepareVotes_ReturnsNonEmptyDictionary()
        {
            List<string> votes = new List<string>{"A","A", "A", "B", "B"};
            Assert.NotEmpty(VoteCounter.PrepareVotes(votes));
        }
    }
}

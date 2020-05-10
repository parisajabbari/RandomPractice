using System;
using Xunit;
using Moq;
using project;
using System.Linq;
using System.Collections.Generic;

namespace Tests
{
    public class RateLimitTest
    {
        private ITimer timer;
        string request = "R1";
        private RateLimit _ratelimiter;
        private  Dictionary<string, int> _requestCount = new Dictionary<string, int>();

        public RateLimitTest()
        {
            timer = Mock.Of<ITimer>();
            _ratelimiter = new RateLimit(timer, _requestCount);           
        }

        [Fact]
        public void ValidateARequestInTimeSpanLessThanMax_ShouldReturnTrue()
        {
            Mock.Get(timer).Setup(t => t.IsTimerStarted(request)).Returns(true);
            Mock.Get(timer).Setup(t => t.IsTimerExpired(request)).Returns(false);

            _requestCount.Add(request, 3);      

            Assert.True(_ratelimiter.ValidateRequest(request));

        }

        [Fact]
        public void ValidateARequestInTimeSpanMoreThanMax_ShouldReturnFalse()
        {
            Mock.Get(timer).Setup(t => t.IsTimerStarted(request)).Returns(true);
            Mock.Get(timer).Setup(t => t.IsTimerExpired(request)).Returns(false);        

            _requestCount.Add(request, 4);      

            Assert.False(_ratelimiter.ValidateRequest(request));
        }

        [Fact]
        public void ValidateARequestLessThanMaxWithExpiredTimer_ShouldReturnFalse()
        {
            Mock.Get(timer).Setup(t => t.IsTimerStarted(request)).Returns(true);
            Mock.Get(timer).Setup(t => t.IsTimerExpired(request)).Returns(true);        

            _requestCount.Add(request, 3);      

            Assert.False(_ratelimiter.ValidateRequest(request));
        }
    }
}

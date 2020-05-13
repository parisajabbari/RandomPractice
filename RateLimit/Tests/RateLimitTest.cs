using System;
using Xunit;
using Moq;
using project;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

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
            _ratelimiter = new RateLimit(timer);           
        }

        [Fact]
        public void ValidateARequestInTimeSpanLessThanMax_ShouldReturnTrue()
        {
            Mock.Get(timer).Setup(t => t.IsTimerStarted(request)).Returns(true);
            Mock.Get(timer).Setup(t => t.IsTimerExpired(request)).Returns(false);

            _ratelimiter.Register(request); 
            _ratelimiter.Register(request); 

            Assert.True(_ratelimiter.ValidateRequest(request));

        }

        [Fact]
        public void ValidateARequestInTimeSpanMoreThanMax_ShouldReturnFalse()
        {
            Mock.Get(timer).Setup(t => t.IsTimerStarted(request)).Returns(true);
            Mock.Get(timer).Setup(t => t.IsTimerExpired(request)).Returns(false);        

            _ratelimiter.Register(request); 
            _ratelimiter.Register(request);
            _ratelimiter.Register(request); 
            _ratelimiter.Register(request);
            _ratelimiter.Register(request); 
            _ratelimiter.Register(request);  

            Assert.False(_ratelimiter.ValidateRequest(request));
        }

        [Fact]
        public void ValidateARequestLessThanMaxWithExpiredTimer_ShouldReturntrue()
        {
            Mock.Get(timer).Setup(t => t.IsTimerStarted(request)).Returns(true);
            Mock.Get(timer).Setup(t => t.IsTimerExpired(request)).Returns(true);        

            _ratelimiter.Register(request); 
            _ratelimiter.Register(request);      

            Assert.True(_ratelimiter.ValidateRequest(request));
        }

    }
}

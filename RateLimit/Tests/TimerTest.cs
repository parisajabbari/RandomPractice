using System;
using Xunit;
using Moq;
using project;
using System.Linq;
using System.Collections.Generic;

namespace Tests
{
    public class TimerTest
    {
        private ITimer timer;
        private string request = "R1";
        public TimerTest()
        {
            timer = Mock.Of<ITimer>();
        }
        [Fact]
        public void TimerIsStarted_ShouldReturnTrue()
        {
            var timer = new RateTimer();

            timer.StartTimer(request);

            Assert.True(timer.IsTimerStarted(request));

        }

        [Fact]
        public void TimerIsNotExpired_ShouldReturnFalse()
        {
            var timer = new RateTimer();
            timer.StartTimer(request);

            Assert.False(timer.IsTimerExpired(request));
        }

        [Fact]
        public void TimerIsExpired_After2Seconds_ShouldReturnTrue()
        {
            var timer = new RateTimer();
            timer.StartTimer(request);
        }

    }
}
using System;
using Xunit;
using Moq;
using System.Threading;


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
        public void TimerIsExpired_After2Seconds_ShouldReturnTrue()
        {
            var autoResetEvent = new AutoResetEvent(false);

            var timer = new RateTimer();
            timer.StartTimer(request);

            autoResetEvent.WaitOne(3000);
            autoResetEvent.Set();

            Assert.True(timer.IsTimerExpired(request));
        }

        [Fact]
        public void TimerIsValid_Before2Seconds_ShouldReturnFalse()
        {
            var autoResetEvent = new AutoResetEvent(false);

            var timer = new RateTimer();
            timer.StartTimer(request);

            autoResetEvent.WaitOne(1000);
            autoResetEvent.Set();

            Assert.False(timer.IsTimerExpired(request));
        }
    }
}
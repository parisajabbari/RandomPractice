using System;
using Xunit;
using Moq;
using System.Threading;
using project;
using System.Collections.Generic;


namespace Tests
{
    public class LimiterAndTimerTest
    {
         static RateTimer Timer = new RateTimer();
         RateLimit rateLimit = new RateLimit(Timer);
         string request = "R1";

         [Fact]
         public void RequestsLessThanMax_ExpiredTimer_ShouldReturnTrue()
         {
            var autoEventReset = new AutoResetEvent(false);

            rateLimit.Register(request); 
            rateLimit.Register(request);

            autoEventReset.WaitOne(4000);
            autoEventReset.Set();

            Assert.True(rateLimit.ValidateRequest(request));       
         
         }

        [Fact]
         public void RequestsMoreThanMax_NonExpiredTimer_ShouldReturnFalse()
         {

            rateLimit.Register(request); 
            rateLimit.Register(request);
            rateLimit.Register(request); 
            rateLimit.Register(request);
            rateLimit.Register(request); 
            rateLimit.Register(request);


            Assert.False(rateLimit.ValidateRequest(request));       
         
         }

        [Fact]
         public void CountinousRequests_ShouldReturntrue()
         {
            var autoEventReset = new AutoResetEvent(false);

            rateLimit.Register(request); 
            rateLimit.Register(request);
            rateLimit.Register(request); 
            rateLimit.Register(request);

            autoEventReset.WaitOne(4000);
            autoEventReset.Set();

            rateLimit.Register(request); 
            rateLimit.Register(request);


            Assert.True(rateLimit.ValidateRequest(request));       
         
         }



    }
}
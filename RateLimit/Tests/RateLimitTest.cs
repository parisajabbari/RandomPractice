using System;
using Xunit;
using project;
using System.Collections.Generic;
using Moq;

namespace Tests
{
    public class RateLimitTest    
    {
        //private Mock<IRequest> request;
        private Mock<ITimer> timer;
        string request = "R1";
        public RateLimitTest()
        {
            //request = new Mock<IRequest>();
            timer = new Mock<ITimer>();
            
        }

        [Fact]
        public void CountOneRequestLessThanMax_SouldReturnOK()
        {
            // request.Setup(r => r.GetAllRequests()).Returns(new Dictionary<string, int>(){
            //     {"R1", 5}
            // });

            timer.Setup(r => r.IsFinished()).Returns(true);

            var result = RateLimit.ValidateRequest(request);

            Assert.True(result);
        }

        //setup
        //SetTimer
        //StartsTimer
        //MakeRequests(create the dictionary of requests and repeat)

        //Tets
        //CountOneRequestLessThanMax_SouldReturnOK
        //Mock of timer to say it has elapsed(reached limit)
        //Mock of "a funcion" that builds a dictionary
        //Now look into built dictionary and analyse values 
        // [Fact]
        // public void CountRequestsPerId_ShouldReturnOK()
        // {
        //     var Dictionary = new Dictionary<int, int>();
        //     Dictionary.Add(1, 5);

        //     Assert.Equal("OK", RateLimit.CountRequests(Dictionary));
            

        // }

        [Fact]
        public void Dummy()
        {
            //SetTimer
                //StartsTimer
            //MakeRequests



            

        }
    }
}

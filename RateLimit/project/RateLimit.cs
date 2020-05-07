using System;
using System. Collections.Generic;
using System.Timers;

namespace project
{
    //max request from each id = 10 in 5 seconds
    public class RateLimit
    {
        private ITimer _timer;

        public RateLimit(ITimer timer, IRequest request)
        {
            _timer = timer;
        }

        public static bool ValidateRequest(string request)
        {
            return false;
        }
        
    }
}

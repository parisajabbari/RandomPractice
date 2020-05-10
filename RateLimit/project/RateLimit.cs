using System;
using System.Collections.Generic;

namespace project
{
    public class RateLimit
    {
         Dictionary<string, int> _requestCount = new Dictionary<string, int>();
         ITimer _timer;
         int _maxRequest = 5;

        public RateLimit(ITimer timer, Dictionary<string, int> requestCount)
        {
            _timer = timer;
            _requestCount = requestCount;
            
        }

        public bool ValidateRequest(string request)
        {
            if(!_timer.IsTimerStarted(request))
            {
                _timer.StartTimer(request);
            }

            if(!_timer.IsTimerExpired(request))
            {
                if(!_requestCount.ContainsKey(request))
                {
                    _requestCount[request] = 0;
                }
                _requestCount[request]++;

                return _requestCount[request] < _maxRequest;
            }
            return false;
        }
    }
}

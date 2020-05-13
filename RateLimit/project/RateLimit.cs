using System;
using System.Collections.Generic;

namespace project
{
    public class RateLimit
    {
         Dictionary<string, int> _requestCount = new Dictionary<string, int>();
         ITimer _timer;
         int _maxRequest = 5;


        public RateLimit(ITimer timer)
        {
            _timer = timer;
            
        }

        public void Register(string request)
        {
            if(!_timer.IsTimerStarted(request))
            {
                _requestCount.Clear();
                _timer.StartTimer(request);
            }


            if(!_requestCount.ContainsKey(request))
            {
                _requestCount[request] = 0;
            }
            _requestCount[request]++;

        }
        public bool ValidateRequest(string request)
        {
            if(_requestCount[request] < _maxRequest)
            {
                if(_timer.IsTimerExpired(request))
                {
                    _timer.ResetTimer(request);
                }
                return true;
            }
            return false;
        }
    }
}

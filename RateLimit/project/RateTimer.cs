using System.Collections.Generic;
using System.Timers;

public class RateTimer : ITimer
{
    Dictionary<string, Timer> map = new Dictionary<string, Timer>();
    Timer _timer = new Timer();
    public void StartTimer(string request)
    {
        map[request] = new Timer(2000);
        map[request].Start();
        map[request].Enabled = true;
        map[request].Elapsed += (sender, e) => OnTimedEvent(request);

    }

    private void OnTimedEvent(string request)
    {
        map.Remove(request);
    }

    public bool IsTimerStarted(string request)
    {
        return map.ContainsKey(request) && map[request].Enabled;

    }

    public bool IsTimerExpired(string request)
    {
        return map.ContainsKey(request) ?  false :  true;
        
    }
}
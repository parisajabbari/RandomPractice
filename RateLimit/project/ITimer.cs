public interface ITimer
{
    void StartTimer(string request);
    bool IsTimerStarted(string request);
    bool IsTimerExpired(string request);

}
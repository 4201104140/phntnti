namespace Microsoft.TimeoutManager
{
    public class TimeoutManagerFactory : ITimeoutManagerFactory
    {
        public ITimeoutManager<T> CreateTimeoutManager<T>(int timeoutMilliseconds, int checkForTimeoutIntervalMilliseconds = TimeoutManagerConstants.DefaultIntervalTimeoutCheckMilliseconds)
        {
            return new TimeoutManager<T>(timeoutMilliseconds, checkForTimeoutIntervalMilliseconds);
        }
    }
}
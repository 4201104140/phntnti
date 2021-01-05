namespace Microsoft.TimeoutManager
{
    using System.Collections.Generic;

    internal class TimeoutManagerItemWrapperComparer<T> : IEqualityComparer<TimeoutManagerItemWrapper<T>>
    {
        public bool Equals(TimeoutManagerItemWrapper<T> x, TimeoutManagerItemWrapper<T> y)
        {
            return x.Item.Equals(y.Item);
        }

        public int GetHashCode(TimeoutManagerItemWrapper<T> obj)
        {
            return obj.Item.GetHashCode();
        }
    }
}
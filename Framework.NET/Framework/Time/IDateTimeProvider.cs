using System;

namespace Framework.Time
{
    public interface IDateTimeProvider
    {
        public DateTime Now();
    }
}
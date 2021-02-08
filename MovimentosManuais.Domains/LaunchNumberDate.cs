using System;

namespace MovimentosManuais.Domains
{
    public struct LaunchNumberDate
    {
        public DateTime Value { get; private set; }

        public static LaunchNumberDate FromTo(MonthDate monthDate, YearDate yearDate)
        {
            return new LaunchNumberDate
            {
                Value = new DateTime(yearDate.Value, (int)monthDate, DateTime.Now.Day, 0, 0, 0)
            };
        }
    }
}

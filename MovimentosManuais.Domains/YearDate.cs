using System;

namespace MovimentosManuais.Domains
{
    public sealed class YearDate
    {
        public int Value { get; private set; }
        public static YearDate FromString(string year)
        {
            if (!int.TryParse(year, out int result) 
                    && DateTime.TryParse(string.Format("1/1/{0}", year), out DateTime dateTime))
            {
                throw new ArgumentException("Invalid year. The value can't be null or empty.");
            }
            return new YearDate(result);
        }

        private YearDate(int value)
        {
            Value = value;
        }
    }
}

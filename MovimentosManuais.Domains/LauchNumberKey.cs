using System;

namespace MovimentosManuais.Domains
{
    public sealed class LauchNumberKey
    {
        private const int DefaultStartValue = 1;
        public int Value { get; private set; }
        public static LauchNumberKey FromString(string key)
        {
            if (!int.TryParse(key, out int result))
            {
                throw new ArgumentException("Invalid lauch number key. The value can't be null or empty.");
            }
            return new LauchNumberKey(result);
        }

        public static LauchNumberKey NewKey()
        {
            return new LauchNumberKey(DefaultStartValue);
        }

        public static LauchNumberKey FromLastKey(int lastKey)
        {
            return new LauchNumberKey(++lastKey);
        }

        private LauchNumberKey(int value)
        {
            Value = value;
        }
    }
}

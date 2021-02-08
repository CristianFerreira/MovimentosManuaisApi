using System;

namespace MovimentosManuais.Domains
{
    public sealed class CosifProductKey
    {
        public string Value { get; private set; }
        public static CosifProductKey FromString(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Invalid cosif product key. The value can't be null or empty.");
            }
            return new CosifProductKey(key);
        }

        private CosifProductKey(string value)
        {
            Value = value;
        }
    }
}

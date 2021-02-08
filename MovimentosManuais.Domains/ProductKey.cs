using System;

namespace MovimentosManuais.Domains
{
    public sealed class ProductKey
    {
        public string Value { get; private set; }
        public static ProductKey FromString(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Invalid product key. The value can't be null or empty.");
            }
            return new ProductKey(key);
        }

        private ProductKey(string value)
        {
            Value = value;
        }
    }
}

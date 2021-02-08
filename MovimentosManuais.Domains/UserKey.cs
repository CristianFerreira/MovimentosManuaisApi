using System;

namespace MovimentosManuais.Domains
{
    public sealed class UserKey
    {
        public string Value { get; private set; }
        public static UserKey FromString(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Invalid user key. The value can't be null or empty.");
            }
            return new UserKey(key);
        }

        private UserKey(string value)
        {
            Value = value;
        }
    }
}

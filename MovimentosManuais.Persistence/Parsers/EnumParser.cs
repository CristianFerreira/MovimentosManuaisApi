using System;

namespace MovimentosManuais.Persistence.Parsers
{
    public static class EnumParser<T> where T : struct, IConvertible
    {
        public static T ParseTo(string value)
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException($"T must be an enumerated type. ({typeof(T)})");
            }
            else if (!Enum.TryParse(typeof(T), value, out object result))
            {
                throw new ArgumentNullException($"Error to try parse Enum: ({typeof(T)}).");
            }
            else
            {
                return (T)result;
            }
        }
    }
}

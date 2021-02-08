using System;

namespace MovimentosManuais.Application.Presenters.Converters
{
    public class EnumConverter<T> where T : struct, IConvertible
    {
        public static T ConvertTo(string value)
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException($"T must be an enumerated type. ({typeof(T)})");
            }
            else if (!Enum.TryParse(typeof(T), value, out var result))
            {
                throw new ArgumentNullException($"Error to convert Enum: ({typeof(T)}).");
            }
            else
            { 
                return (T)result;
            }
        }
    }
}

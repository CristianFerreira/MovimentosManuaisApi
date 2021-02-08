using MovimentosManuais.Domains;

namespace MovimentosManuais.Persistence.Parsers
{
    public static class LaunchNumberParser
    {
        public static LauchNumberKey ParseTo(dynamic value)
        {
            if (value == null) return null;
            return LauchNumberKey.FromString(value.LaunchNumber.ToString());
        }
    }
}

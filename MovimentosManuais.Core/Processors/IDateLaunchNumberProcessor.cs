using MovimentosManuais.Domains;
using System.Threading.Tasks;

namespace MovimentosManuais.Core.Processors
{
    public interface IDateLaunchNumberProcessor
    {
        Task<LauchNumberKey> GenerateKeyAsync(MonthDate monthDate, YearDate yearDate);
    }
}

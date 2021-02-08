using MovimentosManuais.Domains;
using System.Threading.Tasks;

namespace MovimentosManuais.Core.Api
{
    public interface IManualMovementService
    {
        Task<LauchNumberKey> GenerateLauchNumberKeyAsync(MonthDate monthDate, YearDate yearDate);
        Task OnRegisterBy(ManualMovement manualMovement);
    }
}

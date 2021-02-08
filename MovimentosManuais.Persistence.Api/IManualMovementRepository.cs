using MovimentosManuais.Domains;
using System;
using System.Threading.Tasks;

namespace MovimentosManuais.Persistence.Api
{
    public interface IManualMovementRepository
    {
        Task<ManualMovement[]> GetAll();
        Task<bool> AnyOpenPeriodAfterDateAsync(DateTime currentDate);
        Task<LauchNumberKey> OnFindLastLaunchNumberBy(DateTime beforeDatePeriod, DateTime currentDatePeriod);
        Task Register(ManualMovement manualMovement);
    }
}

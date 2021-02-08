using MovimentosManuais.Core.Api;
using MovimentosManuais.Core.Factories;
using MovimentosManuais.Domains;
using MovimentosManuais.Persistence.Api;
using System.Threading.Tasks;

namespace MovimentosManuais.Core.Services
{
    public class ManualMovementService : IManualMovementService
    {
        private readonly IManualMovementRepository manualMovementRepository;
        private readonly IDateLaunchNumberFactory dateLaunchNumberFactory;

        public ManualMovementService(
            IManualMovementRepository manualMovementRepository,
            IDateLaunchNumberFactory dateLaunchNumberFactory)
        {
            this.manualMovementRepository = manualMovementRepository;
            this.dateLaunchNumberFactory = dateLaunchNumberFactory;
        }

        public async Task<LauchNumberKey> GenerateLauchNumberKeyAsync(MonthDate monthDate, YearDate yearDate)
        {
            var processor = dateLaunchNumberFactory.CreateProcessor();
            return await processor.GenerateKeyAsync(monthDate, yearDate);
        }

        public async Task OnRegisterBy(ManualMovement manualMovement)
        {
            await manualMovementRepository.Register(manualMovement);
        }
    }
}

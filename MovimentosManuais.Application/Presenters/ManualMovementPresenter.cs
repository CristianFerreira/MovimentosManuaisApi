using MovimentosManuais.Application.Presenters.Converters;
using MovimentosManuais.Application.ViewItems;
using MovimentosManuais.Core.Api;
using MovimentosManuais.Domains;
using MovimentosManuais.Persistence.Api;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovimentosManuais.Application.Presenters
{
    public class ManualMovementPresenter : IManualMovementPresenter
    {
        private readonly IManualMovementRepository manualMovementRepository;
        private readonly IManualMovementService manualMovementService;

        public ManualMovementPresenter(
                IManualMovementService manualMovementService,
                IManualMovementRepository manualMovementRepository)
        {
            this.manualMovementService = manualMovementService;
            this.manualMovementRepository = manualMovementRepository;
        }

        public async Task<IEnumerable<ManualMovementResponseDTO>> GetAll()
        {
            var manualMovements = await manualMovementRepository.GetAll();
            return ManualMovementConverter.ConvertToDTO(manualMovements);
        }

        public async Task OnRegisterBy(ManualMovementRequestDTO requestDTO)
        {
            var monthDate = EnumConverter<MonthDate>.ConvertTo(requestDTO.MonthDate);
            var yearDate = YearDate.FromString(requestDTO.YearDate);
            var lauchNumber = await manualMovementService.GenerateLauchNumberKeyAsync(monthDate, yearDate);
            var manualMovement = ManualMovementConverter.ConvertTo(requestDTO, lauchNumber);
            await manualMovementService.OnRegisterBy(manualMovement);
        }
    }
}

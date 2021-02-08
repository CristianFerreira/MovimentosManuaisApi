using MovimentosManuais.Application.ViewItems;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovimentosManuais.Application.Presenters
{
    public interface IManualMovementPresenter
    {
        Task<IEnumerable<ManualMovementResponseDTO>> GetAll();
        Task OnRegisterBy(ManualMovementRequestDTO requestDTO);
    }
}

using MovimentosManuais.Application.ViewItems;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovimentosManuais.Application.Presenters
{
    public interface ICosifProductPresenter
    {
        Task<IEnumerable<CosifProductResponseDTO>> GetAll();
    }
}

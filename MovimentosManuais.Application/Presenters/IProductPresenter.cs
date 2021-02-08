using MovimentosManuais.Application.ViewItems;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovimentosManuais.Application.Presenters
{
    public interface IProductPresenter
    {
        Task<IEnumerable<ProductResponseDTO>> GetAll();
    }
}

using MovimentosManuais.Application.Presenters.Converters;
using MovimentosManuais.Application.ViewItems;
using MovimentosManuais.Persistence.Api;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovimentosManuais.Application.Presenters
{
    public class CosifProductPresenter : ICosifProductPresenter
    {
        private readonly ICosifProductRepository cosifProductRepository;

        public CosifProductPresenter(ICosifProductRepository cosifProductRepository)
        {
            this.cosifProductRepository = cosifProductRepository;
        }

        public async Task<IEnumerable<CosifProductResponseDTO>> GetAll()
        {
            var cosifProducts = (await cosifProductRepository.GetAll());
            return CosifProductConverter.ConvertToDTO(cosifProducts);
        }
    }
}

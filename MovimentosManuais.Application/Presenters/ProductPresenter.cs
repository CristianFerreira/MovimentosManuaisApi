
using MovimentosManuais.Application.Presenters.Converters;
using MovimentosManuais.Application.ViewItems;
using MovimentosManuais.Persistence.Api;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovimentosManuais.Application.Presenters
{
    public class ProductPresenter : IProductPresenter
    {
        private readonly IProductRepository productRepository;

        public ProductPresenter(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductResponseDTO>> GetAll()
        {
            var products = (await productRepository.GetAll());
            return ProductConverter.ConvertToDTO(products);
        }
    }
}

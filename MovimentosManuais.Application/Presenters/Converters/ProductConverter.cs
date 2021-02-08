
using MovimentosManuais.Application.ViewItems;
using MovimentosManuais.Domains;
using System.Linq;

namespace MovimentosManuais.Application.Presenters.Converters
{
    public static class ProductConverter
    {
        public static ProductResponseDTO[] ConvertToDTO(Product[] products)
        {
            if (products != null && products.Length > 0)
            {
                return products.Select(it => ConvertToDTO(it)).ToArray();
            }

            return Enumerable.Empty<ProductResponseDTO>().ToArray();
        }

        private static ProductResponseDTO ConvertToDTO(Product product)
        {
            return new ProductResponseDTO
            {
                Code = product.Key.Value,
                Description = product.Description
            };
        }
    }
}

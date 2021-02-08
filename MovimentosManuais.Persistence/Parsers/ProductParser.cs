using MovimentosManuais.Domains;
using MovimentosManuais.Persistence.Entities;
using System.Linq;

namespace MovimentosManuais.Persistence.Parsers
{
    public static class ProductParser
    {
        public static Product[] ParseTo(ProductEntity[] items)
        {
            if (items != null && items.Any())
            {
                return items.Select(it => ParseTo(it)).ToArray() as Product[];
            }
            return Enumerable.Empty<Product>().ToArray();
        }

        public static Product ParseTo(ProductEntity entity)
        {
            return new Product
            (
                ProductKey.FromString(entity.ProductCode),
                entity.Description,
                EnumParser<ProductStatus>.ParseTo(entity.Status)
            ); 
        }
    }
}

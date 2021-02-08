using MovimentosManuais.Domains;
using System.Linq;

namespace MovimentosManuais.Persistence.Parsers
{
    public static class CosifProductParser
    {
        public static CosifProduct[] ParseTo(dynamic[] items)
        {
            if (items is object[] && !(items.Length > 0))
            {
                return Enumerable.Empty<CosifProduct>().ToArray();
            }
            
            return items.Select(it => (CosifProduct)ParseTo(it)).ToArray();
        }


        private static CosifProduct ParseTo(dynamic item)
        {
            var product = new Product
            (
                ProductKey.FromString(item.ProductCode),
                item.ProductDescription,
                EnumParser<ProductStatus>.ParseTo(item.ProductStatus)
            );

            return new CosifProduct
            (
                CosifProductKey.FromString(item.CosifProductCode),
                product,
                item.Classification,
                EnumParser<CosifProductStatus>.ParseTo(item.CosifProductStatus)
            );
        }

    }
}

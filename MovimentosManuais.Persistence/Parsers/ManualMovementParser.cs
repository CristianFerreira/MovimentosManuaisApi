using MovimentosManuais.Domains;
using MovimentosManuais.Persistence.Entities;
using System.Linq;

namespace MovimentosManuais.Persistence.Parsers
{
    public static class ManualMovementParser
    {
        public static ManualMovement[] ParseTo(dynamic[] items)
        {
            if (items is object[] && !(items.Length > 0))
            {
                return Enumerable.Empty<ManualMovement>().ToArray();
            }
            
            return items.Select(it => (ManualMovement)ParseTo(it)).ToArray();
        }

        private static ManualMovement ParseTo(dynamic item)
        {
            var product = new Product
            (
                ProductKey.FromString(item.ProductCode),
                item.ProductDescription,
                EnumParser<ProductStatus>.ParseTo(item.ProductStatus)
            );

            var cosifProduct = new CosifProduct
            (
                CosifProductKey.FromString(item.CosifProductCode),
                product,
                item.Classification,
                EnumParser<CosifProductStatus>.ParseTo(item.CosifProductStatus)
            );

            return new ManualMovement
            (
               item.Description,
               item.Value,
               LauchNumberKey.FromString(item.LaunchNumber.ToString()),
               YearDate.FromString(item.YearDate.ToString()),
               EnumParser<MonthDate>.ParseTo(item.MonthDate.ToString()),
               cosifProduct
            );
        }
        public static ManualMovementEntity ParseTo(ManualMovement manualMovement)
        {
            return new ManualMovementEntity
            {
                YearDate = manualMovement.YearDate.Value,
                Value = manualMovement.Value,
                CosifCode = manualMovement.CosifProduct.Key.Value,
                Description = manualMovement.Description,
                LaunchNumber = manualMovement.LauchNumber.Value,
                MonthDate = (int)manualMovement.MonthDate,
                MovementDate = manualMovement.MovementDate,
                ProductCode = manualMovement.CosifProduct.Product.Key.Value,
                UserCode = manualMovement.UserKey.Value
            };
        }
    }
}

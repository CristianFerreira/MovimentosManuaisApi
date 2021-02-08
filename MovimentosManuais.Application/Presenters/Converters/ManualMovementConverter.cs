using MovimentosManuais.Application.ViewItems;
using MovimentosManuais.Domains;
using System.Linq;

namespace MovimentosManuais.Application.Presenters.Converters
{
    public static class ManualMovementConverter
    {
        public static ManualMovementResponseDTO[] ConvertToDTO(ManualMovement[] manualMovements)
        {
            if (manualMovements != null && manualMovements.Length > 0)
            {
                return manualMovements.Select(it => ConvertToDTO(it)).ToArray();
            }

            return Enumerable.Empty<ManualMovementResponseDTO>().ToArray();
        }

        private static ManualMovementResponseDTO ConvertToDTO(ManualMovement manualMovement)
        {
            return new ManualMovementResponseDTO
            {
                MonthDate = ((int)manualMovement.MonthDate).ToString(),
                YearDate = manualMovement.YearDate.Value,
                ProductCode = manualMovement.CosifProduct.Product.Key.Value,
                ProductDescription = manualMovement.CosifProduct.Product.Description,
                LaunchNumber = manualMovement.LauchNumber.Value.ToString(),
                Description = manualMovement.Description,
                Value = manualMovement.Value
            };
        }

        public static ManualMovement ConvertTo(ManualMovementRequestDTO dto, LauchNumberKey lauchNumberKey)
        {
            var product = new Product
            (
                ProductKey.FromString(dto.ProductCode)
            );

            var cosifProduct = new CosifProduct
            (
                CosifProductKey.FromString(dto.CosifProductCode),
                product
            );

            return new ManualMovement
            (
                dto.Description,
                dto.Value,
                lauchNumberKey,
                YearDate.FromString(dto.YearDate),
                EnumConverter<MonthDate>.ConvertTo(dto.MonthDate),
                cosifProduct
            );
        }
    }
}

using MovimentosManuais.Application.ViewItems;
using MovimentosManuais.Domains;
using System.Linq;

namespace MovimentosManuais.Application.Presenters.Converters
{
    public static class CosifProductConverter
    {
        public static CosifProductResponseDTO[] ConvertToDTO(CosifProduct[] cosifProducts)
        {
            if (cosifProducts != null && cosifProducts.Length > 0)
            {
                return cosifProducts.Select(it => ConvertToDTO(it)).ToArray();
            }

            return Enumerable.Empty<CosifProductResponseDTO>().ToArray();
        }

        private static CosifProductResponseDTO ConvertToDTO(CosifProduct cosifProduct)
        {
            return new CosifProductResponseDTO
            {
                Code = cosifProduct.Key.Value,
                Classification = cosifProduct.Classification
            };
        }
    }
}

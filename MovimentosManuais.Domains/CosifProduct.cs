using System;

namespace MovimentosManuais.Domains
{
    public class CosifProduct
    {
        public CosifProductKey Key { get; private set; }
        public Product Product { get; private set; }        
        public string Classification { get; private set; }
        public CosifProductStatus Status { get; private set; }

        public CosifProduct(CosifProductKey key, Product product)
        {
            Key = key ?? throw new ArgumentNullException("Cosif product key is required");
            Product = product ?? throw new ArgumentNullException("Product is required");
        }

        public CosifProduct(CosifProductKey key, Product product, string classification)
        {
            Key = key ?? throw new ArgumentNullException("Cosif product key is required");
            Product = product ?? throw new ArgumentNullException("Product is required");
            Classification = classification;
        }

        public CosifProduct(CosifProductKey key, Product product, string classification, CosifProductStatus status)
        {
            Key = key ?? throw new ArgumentNullException("Cosif product key is required");
            Product = product ?? throw new ArgumentNullException("Product is required");
            Classification = classification;
            Status = status;
        }
    }
}

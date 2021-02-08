using System;

namespace MovimentosManuais.Domains
{
    public class Product
    {
        public ProductKey Key { get; private set; }
        public string Description { get; private set; }
        public ProductStatus Status { get; private set; }

        public Product(ProductKey key)
        {
            Key = key ?? throw new ArgumentNullException("Product key is required");
        }

        public Product(ProductKey key, string description)
        {
            Key = key ?? throw new ArgumentNullException("Product key is required");
            Description = description;
        }

        public Product(ProductKey key, string description, ProductStatus status)
        {
            Key = key ?? throw new ArgumentNullException("Product key is required");
            Description = description;
            Status = status;
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace MovimentosManuais.Persistence.Entities
{
    [Table("PRODUTO")]
    public class ProductEntity
    {
        [Column("COD_PRODUTO")]
        public string ProductCode { get; set; }
        [Column("DES_PRODUTO")]
        public string Description { get; set; }
        [Column("STA_STATUS")]
        public string Status { get; set; }
    }
}

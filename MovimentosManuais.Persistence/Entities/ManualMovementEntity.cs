using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovimentosManuais.Persistence.Entities
{
    [Table("MOVIMENTO_MANUAL")]
    public class ManualMovementEntity
    {
        [Column("DAT_MES")]
        public decimal MonthDate { get; set; }
        [Column("DAT_ANO")]
        public decimal YearDate { get; set; }
        [Column("NUM_LANCAMENTO")]
        public decimal LaunchNumber { get; set; }
        [Column("COD_PRODUTO")]
        public string ProductCode { get; set; }
        [Column("COD_COSIF")]
        public string CosifCode { get; set; }
        [Column("DES_DESCRICAO")]
        public string Description { get; set; }
        [Column("DAT_MOVIMENTO")]
        public DateTime MovementDate { get; set; }
        [Column("COD_USUARIO")]
        public string UserCode { get; set; }
        [Column("VAL_VALOR")]
        public decimal Value { get; set; }
    }
}

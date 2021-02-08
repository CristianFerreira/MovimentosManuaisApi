namespace MovimentosManuais.Application.ViewItems
{
    public class ManualMovementRequestDTO
    {
        private string _MonthDate;
        public string MonthDate
        {
            get
            {
                return int.Parse(_MonthDate).ToString();
            }
            set
            {
                _MonthDate = value;
            }
        }
        public string YearDate { get; set; }
        public string ProductCode { get; set; }
        public string CosifProductCode { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }

    }
}

namespace MovimentosManuais.Application.ViewItems
{
    public class ManualMovementResponseDTO
    {
        private string _MonthDate;
        public string MonthDate
        {
            get
            {
                return int.Parse(_MonthDate).ToString("d2");
            }
            set
            {
                _MonthDate = value;
            }
        }
        public int YearDate { get; set; }
        private string _LaunchNumber;
        public string LaunchNumber
        {
            get
            {
                return int.Parse(_LaunchNumber).ToString("000");
            }
            set
            {
                _LaunchNumber = value;
            }
        }
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
    }
}

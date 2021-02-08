using System;

namespace MovimentosManuais.Domains
{
    public class ManualMovement
    {
        public MonthDate MonthDate { get; private set; }
        public YearDate YearDate { get; private set; }
        public LauchNumberKey LauchNumber { get; private set; }
        public CosifProduct CosifProduct { get; private set; }
        public string Description { get; private set; }
        public DateTime MovementDate { get; private set; }
        public UserKey UserKey { get; private set; }
        public decimal Value { get; private set; }

        public ManualMovement(string description, decimal value, LauchNumberKey lauchNumberKey, YearDate yearDate, MonthDate monthDate, CosifProduct cosifProduct)
        {
            Description = description ?? throw new ArgumentNullException("Description is required");          
            LauchNumber = lauchNumberKey ?? throw new ArgumentNullException("Lauch number key is required");
            YearDate = yearDate ?? throw new ArgumentNullException("Year date is required");
            CosifProduct = cosifProduct ?? throw new ArgumentNullException("Cosif product is required");
            MonthDate = monthDate;
            Value = value;
            MovementDate = DateTime.Now;
            UserKey = UserKey.FromString("TESTE");
        }
    }
}

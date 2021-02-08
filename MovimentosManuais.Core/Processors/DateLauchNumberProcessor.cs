using MovimentosManuais.Domains;
using MovimentosManuais.Persistence.Api;
using System;
using System.Threading.Tasks;

namespace MovimentosManuais.Core.Processors
{
    public class DateLauchNumberProcessor : IDateLaunchNumberProcessor
    {
        private const int DefaultPeriodInYears = 1;
        private readonly IManualMovementRepository manualMovementRepository;
        public DateLauchNumberProcessor(IManualMovementRepository manualMovementRepository)
        {
            this.manualMovementRepository = manualMovementRepository;
        }

        public async Task<LauchNumberKey> GenerateKeyAsync(MonthDate monthDate, YearDate yearDate)
        {
            var currentDatePeriod = LaunchNumberDate.FromTo(monthDate, yearDate).Value;
            var AnyOpenPeriodAfterDate = await manualMovementRepository.AnyOpenPeriodAfterDateAsync(currentDatePeriod);
            if (AnyOpenPeriodAfterDate)
            {
                throw new ArgumentException("It was not possible to generate a launch key. There is already an open period after the informed date!");
            }

            var beforeDatePeriod = ConvertToBeforeDatePeriod(monthDate, yearDate);

            var lastLauchNumberKey =
                    await manualMovementRepository
                            .OnFindLastLaunchNumberBy(beforeDatePeriod, currentDatePeriod);

            if (lastLauchNumberKey != null)
            {
                return LauchNumberKey.FromLastKey(lastLauchNumberKey.Value);
            }

            return LauchNumberKey.NewKey();

        }

        private static DateTime ConvertToBeforeDatePeriod(MonthDate monthDate, YearDate yearDate)
        {
            var date = LaunchNumberDate.FromTo(monthDate, yearDate).Value;
            date = date.AddYears(-DefaultPeriodInYears);

            return date;
        }
    }
}

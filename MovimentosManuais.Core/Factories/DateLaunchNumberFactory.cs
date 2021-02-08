using MovimentosManuais.Core.Processors;
using MovimentosManuais.Persistence.Api;

namespace MovimentosManuais.Core.Factories
{
    public class DateLaunchNumberFactory : IDateLaunchNumberFactory
    {
        private readonly IManualMovementRepository repository;
        public DateLaunchNumberFactory(IManualMovementRepository repository)
        {
            this.repository = repository;
        }

        public IDateLaunchNumberProcessor CreateProcessor()
        {
            return new DateLauchNumberProcessor(repository);
        }
    }
}

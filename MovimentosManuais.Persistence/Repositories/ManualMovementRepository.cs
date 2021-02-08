using MovimentosManuais.Domains;
using MovimentosManuais.Libraries;
using MovimentosManuais.Persistence.Api;
using MovimentosManuais.Persistence.Parsers;
using MovimentosManuais.Persistence.Repositories.DAO;
using System;
using System.Threading.Tasks;

namespace MovimentosManuais.Persistence.Repositories
{
    public class ManualMovementRepository : IManualMovementRepository
    {
        private readonly IDataContext dataContext;

        public ManualMovementRepository(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<ManualMovement[]> GetAll()
        {
            using (var connection = dataContext.AcquireConnection())
            {
                var manualMovementDAO = new ManualMovementDAO(connection);
                var entities = await manualMovementDAO.GetAllAsync();
                return ManualMovementParser.ParseTo(entities);
            }
        }

        public async Task<bool> AnyOpenPeriodAfterDateAsync(DateTime currentDate)
        {
            using (var connection = dataContext.AcquireConnection())
            {
                var manualMovementDAO = new ManualMovementDAO(connection);
                return await manualMovementDAO.AnyOpenPeriodAfterDateAsync(currentDate);
            }
        }

        public async Task<LauchNumberKey> OnFindLastLaunchNumberBy(DateTime beforeDatePeriod, DateTime currentDatePeriod)
        {
            using (var connection = dataContext.AcquireConnection())
            {
                var manualMovementDAO = new ManualMovementDAO(connection);
                var result = await manualMovementDAO.FindLastLaunchNumberKeyAsyncBy(currentDatePeriod, beforeDatePeriod);
                return LaunchNumberParser.ParseTo(result);
            }
        }

        public async Task Register(ManualMovement manualMovement)
        {
            using (var connection = dataContext.AcquireConnection())
            {
                var manualMovementDAO = new ManualMovementDAO(connection);
                var entity = ManualMovementParser.ParseTo(manualMovement);
                await manualMovementDAO.RegisterAsync(entity);
            }
        }
    }
}

using MovimentosManuais.Domains;
using MovimentosManuais.Libraries;
using MovimentosManuais.Persistence.Api;
using MovimentosManuais.Persistence.Parsers;
using MovimentosManuais.Persistence.Repositories.DAO;
using System.Linq;
using System.Threading.Tasks;

namespace MovimentosManuais.Persistence.Repositories
{
    public class CosifProductRepository : ICosifProductRepository
    {
        private readonly IDataContext dataContext;

        public CosifProductRepository(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<CosifProduct[]> GetAll()
        {
            using (var connection = dataContext.AcquireConnection())
            {
                var cosifProductDAO = new CosifProductDAO(connection);
                var entities = await cosifProductDAO.GetAll();
                return CosifProductParser.ParseTo(entities);
            }
        }
    }
}

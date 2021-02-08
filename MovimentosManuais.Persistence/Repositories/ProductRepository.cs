using MovimentosManuais.Domains;
using MovimentosManuais.Libraries;
using MovimentosManuais.Persistence.Api;
using MovimentosManuais.Persistence.Parsers;
using MovimentosManuais.Persistence.Repositories.DAO;
using System.Threading.Tasks;

namespace MovimentosManuais.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataContext dataContext;

        public ProductRepository(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Product[]> GetAll()
        {
            using (var connection = dataContext.AcquireConnection())
            {
                var productDAO = new ProductDAO(connection);
                var entities = (await productDAO.GetAll());
                return  ProductParser.ParseTo(entities);
            }
        }
    }
}

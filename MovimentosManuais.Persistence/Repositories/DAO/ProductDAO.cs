using MovimentosManuais.Domains;
using MovimentosManuais.Libraries;
using MovimentosManuais.Persistence.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace MovimentosManuais.Persistence.Repositories.DAO
{
    internal sealed class ProductDAO
    {
        private readonly IConnectionContext connectionContext;

        public ProductDAO(IConnectionContext connectionContext)
        {
            this.connectionContext = connectionContext;
        }

        public async Task<ProductEntity[]> GetAll()
        {
            const string query =
                   @"SELECT  CAST(RTRIM([COD_PRODUTO]) AS VARCHAR(5)) AS ProductCode
                            ,[DES_PRODUTO] AS Description
                            ,[STA_STATUS] AS Status
                      FROM [MovimentosManuais].[dbo].[PRODUTO]";

            return (await connectionContext.QueryAsync<ProductEntity>(query)).ToArray();
        }

        public async Task<ProductEntity> FindBy(ProductKey productKey)
        {
            const string query =
                   @"SELECT [COD_PRODUTO]
                           ,[DES_PRODUTO]
                           ,[STA_STATUS]
                      FROM [MovimentosManuais].[dbo].[PRODUTO]
                      WHERE [COD_PRODUTO] = @ProductKey";

            return (await connectionContext
                            .QueryAsync<ProductEntity>
                            (
                               query,
                               new { ProductKey = productKey.Value }
                            )).First();
        }
    }
}
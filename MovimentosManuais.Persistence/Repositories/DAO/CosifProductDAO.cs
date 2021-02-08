using MovimentosManuais.Domains;
using MovimentosManuais.Libraries;
using System.Linq;
using System.Threading.Tasks;

namespace MovimentosManuais.Persistence.Repositories.DAO
{
    internal sealed class CosifProductDAO
    {
        private readonly IConnectionContext connectionContext;

        public CosifProductDAO(IConnectionContext connectionContext)
        {
            this.connectionContext = connectionContext;
        }

        public async Task<dynamic[]> GetAll()
        {
            const string query =
                   @"SELECT CAST(RTRIM(pc.[COD_COSIF]) AS VARCHAR(15)) AS CosifProductCode
                            ,CAST(RTRIM(pc.[COD_CLASSIFICACAO]) AS VARCHAR(10)) AS Classification
                            ,pc.[STA_STATUS] AS CosifProductStatus
		                    ,CAST(RTRIM(pc.[COD_PRODUTO]) AS VARCHAR(5)) AS ProductCode
		                    ,p.[DES_PRODUTO] AS ProductDescription
		                    ,p.[STA_STATUS] AS ProductStatus
                        FROM [MovimentosManuais].[dbo].[PRODUTO_COSIF] pc
	                    JOIN [MovimentosManuais].[dbo].[PRODUTO] p 
                            ON p.COD_PRODUTO = pc.COD_PRODUTO";

            return (await connectionContext.QueryAsync<dynamic>(query)).ToArray();
        }
    }
}
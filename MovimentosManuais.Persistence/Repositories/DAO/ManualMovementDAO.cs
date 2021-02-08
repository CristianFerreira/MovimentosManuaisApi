using MovimentosManuais.Libraries;
using MovimentosManuais.Persistence.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovimentosManuais.Persistence.Repositories.DAO
{
    internal sealed class ManualMovementDAO
    {
        private const int DefaultLauchNumberStartPeriod = 1;
        private readonly IConnectionContext connectionContext;

        public ManualMovementDAO(IConnectionContext connectionContext)
        {
            this.connectionContext = connectionContext;
        }

        public async Task<dynamic[]> GetAllAsync()
        {
            const string query =
                @"SELECT mm.[DAT_MES] AS MonthDate
                        ,mm.[DAT_ANO] AS YearDate
                        ,mm.[NUM_LANCAMENTO] AS LaunchNumber
                        ,mm.[DES_DESCRICAO] AS Description
                        ,mm.[DAT_MOVIMENTO] AS MovementDate
                        ,mm.[COD_USUARIO] AS UserCode
                        ,mm.[VAL_VALOR] AS Value
	                    ,CAST(RTRIM(pc.[COD_COSIF]) AS VARCHAR(15)) AS CosifProductCode
	                    ,CAST(RTRIM(pc.[COD_CLASSIFICACAO]) AS VARCHAR(10)) AS CosifProductClassification
	                    ,pc.[STA_STATUS] AS CosifProductStatus
	                    ,CAST(RTRIM(p.[COD_PRODUTO]) AS VARCHAR(5)) AS ProductCode
	                    ,p.[DES_PRODUTO] AS ProductDescription
	                    ,p.[STA_STATUS] AS ProductStatus
                   FROM [MovimentosManuais].[dbo].[MOVIMENTO_MANUAL] mm
                   JOIN [MovimentosManuais].[dbo].[PRODUTO_COSIF] pc 
                        ON pc.COD_COSIF = mm.COD_COSIF
                   JOIN [MovimentosManuais].[dbo].[PRODUTO] p 
                        ON p.COD_PRODUTO = pc.COD_PRODUTO
                   ORDER BY MovementDate ASC";

            return (await connectionContext.QueryAsync<dynamic>(query)).ToArray();
        }

        public async Task RegisterAsync(ManualMovementEntity entity)
        {
            var sqlStatement = @" INSERT INTO [MOVIMENTO_MANUAL] 
                                        (
                                            [DAT_MES]
                                            ,[DAT_ANO]
                                            ,[NUM_LANCAMENTO]
                                            ,[COD_PRODUTO]
                                            ,[COD_COSIF]
                                            ,[DES_DESCRICAO]
                                            ,[DAT_MOVIMENTO]
                                            ,[COD_USUARIO]
                                            ,[VAL_VALOR]
                                        )
                                    VALUES 
                                        (
                                             @MonthDate
                                            ,@YearDate
                                            ,@LaunchNumber
                                            ,@ProductCode
                                            ,@CosifCode
                                            ,@Description
                                            ,@MovementDate
                                            ,@UserCode
                                            ,@Value
                                        )";

            await connectionContext.ExecuteAsync(sqlStatement, entity);
        }

        public async Task<bool> AnyOpenPeriodAfterDateAsync(DateTime currentDate)
        {
            const string query =
                @"SELECT Count(1) FROM MOVIMENTO_MANUAL
                  WHERE datefromparts(DAT_ANO, DAT_MES, DAY(Sysdatetime())) > @CurrentDate";

            return (await connectionContext.QueryAsync<int>(query, new { CurrentDate = currentDate })).Single() > 0;
        }

        public async Task<dynamic> FindLastLaunchNumberKeyAsyncBy(DateTime currentDate, DateTime beforePeriodDate)
        {
            const string query =
                    @"WITH StartLauchNumberDate
	                        AS
	                        (
		                        SELECT 
			                        mm.NUM_LANCAMENTO as LaunchNumber, 
			                        mm.DAT_ANO as YearDate, 
			                        mm.DAT_MES as MonthDate, 
			                        mm.DAT_MOVIMENTO AS MovimentDate
		                        FROM [MovimentosManuais].[dbo].[MOVIMENTO_MANUAL] mm
		                        WHERE datefromparts(mm.DAT_ANO, mm.DAT_MES, DAY(Sysdatetime())) <= @CurrentDate
		                        AND datefromparts(mm.DAT_ANO, mm.DAT_MES, DAY(Sysdatetime())) > @BeforePeriodDate
	                        ) 
                            SELECT TOP 1 CAST(LaunchNumber as INTEGER) AS LaunchNumber
	                        FROM StartLauchNumberDate
	                        WHERE EXISTS(SELECT CAST(LaunchNumber as INTEGER) FROM StartLauchNumberDate WHERE LaunchNumber = @StartValue)
	                        ORDER BY LaunchNumber DESC";

            return (await connectionContext.QueryAsync<dynamic>(query, new { CurrentDate = currentDate, BeforePeriodDate = beforePeriodDate, StartValue = DefaultLauchNumberStartPeriod })).ToArray().FirstOrDefault();
        }
    }
}

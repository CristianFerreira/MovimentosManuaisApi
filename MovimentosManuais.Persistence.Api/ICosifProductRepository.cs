using MovimentosManuais.Domains;
using System.Threading.Tasks;

namespace MovimentosManuais.Persistence.Api
{
    public interface ICosifProductRepository
    {
        Task<CosifProduct[]> GetAll();
    }
}

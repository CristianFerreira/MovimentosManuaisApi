using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovimentosManuais.Application.Presenters;
using MovimentosManuais.Application.ViewItems;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovimentosManuais.API.Controllers
{
    [Route("api/cosif/product")]
    public class CosifProductController : ControllerBase
    {
        private readonly ICosifProductPresenter cosifProductPresenter;

        public CosifProductController(ICosifProductPresenter presenter)
        {
            this.cosifProductPresenter = presenter;
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(IEnumerable<CosifProductResponseDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var products = await cosifProductPresenter.GetAll();
            return Ok(products);
        }
    }
}

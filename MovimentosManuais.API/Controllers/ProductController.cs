using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovimentosManuais.Application.Presenters;
using MovimentosManuais.Application.ViewItems;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovimentosManuais.API.Controllers
{
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductPresenter productPresenter;

        public ProductController(IProductPresenter presenter)
        {
            this.productPresenter = presenter;
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(IEnumerable<ProductResponseDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var products = await productPresenter.GetAll();
            return Ok(products);
        }
    }
}

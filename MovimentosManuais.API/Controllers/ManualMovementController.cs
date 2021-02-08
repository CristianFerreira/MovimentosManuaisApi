using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovimentosManuais.Application.Presenters;
using MovimentosManuais.Application.ViewItems;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovimentosManuais.API.Controllers
{
    [Route("api/manual/movement")]
    public class ManualMovementController : ControllerBase
    {
        private readonly IManualMovementPresenter manualMovementPresenter;

        public ManualMovementController(IManualMovementPresenter presenter)
        {
            manualMovementPresenter = presenter;
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(IEnumerable<ManualMovementResponseDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var manualMovements = await manualMovementPresenter.GetAll();
            return Ok(manualMovements);
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Register([FromBody] ManualMovementRequestDTO requestDTO)
        {
            await manualMovementPresenter.OnRegisterBy(requestDTO);
            return Ok();
        }
    }
}

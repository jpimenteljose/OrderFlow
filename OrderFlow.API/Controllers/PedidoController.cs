using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderFlow.Application.DTOs;
using OrderFlow.Application.Interfaces;

namespace OrderFlow.API.Controllers
{
    [Route("api/v1/pedidos")]
    [ApiController]
    public class PedidoController (IPedidoService _pedidoService) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(PedidoResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync([FromBody] PedidoRequest request)
        {
            try
            {
                var response = await _pedidoService.CriarAsync(request);

                return StatusCode(StatusCodes.Status201Created, response);
            }
            catch (ArgumentException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (InvalidOperationException e)
            {
                return Conflict(new { mensagem = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }
    }
}

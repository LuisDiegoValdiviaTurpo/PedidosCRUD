using Microsoft.AspNetCore.Mvc;
using MyApi.Modelos;
using MyApi.Services;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _service;

        public PedidoController(PedidoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PedidoAux pedido)
        {
            try
            {
                int id = await _service.CrearPedido(pedido);
                return Ok(new { message = "Pedido creado", id });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MyApi.Services;
using MyApi.Modelos;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AIController : ControllerBase
    {
        private readonly AIService _aiService;

        public AIController(AIService aiService)
        {
            _aiService = aiService;
        }

        [HttpPost("response")]
        public async Task<IActionResult> Response([FromBody] AIRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.Input))
                return BadRequest(new { error = "El campo 'input' es requerido." });

            var answer = await _aiService.GetResponseAsync(req.Input);
            return Ok(new { answer });
        }
    }
}

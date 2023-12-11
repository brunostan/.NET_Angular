using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Contratos;
using ProEventos.Domain;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventosController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEventosAsync()
        {
            try
            {
                var eventos = await _eventoService.GetAllEventosAsync(true);

                return eventos != null
                    ? Ok(eventos)
                    : NotFound("Nenhum evento encontrado.");
            }
            catch (Exception error)
            {
                return Problem(
                    detail: $"Erro ao obter eventos. Erro: {error.Message}",
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("tema/{tema}")]
        public async Task<IActionResult> GetAllEventosByTemaAsync(string tema)
        {
            try
            {
                var eventos = await _eventoService.GetAllEventosByTemaAsync(tema, true);

                return eventos != null
                    ? Ok(eventos)
                    : NotFound("Nenhum evento encontrado.");
            }
            catch (Exception error)
            {
                return Problem(
                    detail: $"Erro ao obter eventos por tema. Erro: {error.Message}",
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventoByIdAsync(int id)
        {
            try
            {
                var evento = await _eventoService.GetEventoByIdAsync(id, true);

                return evento != null
                    ? Ok(evento)
                    : NotFound("Nenhum evento encontrado.");
            }
            catch (Exception error)
            {
                return Problem(
                    detail: $"Erro ao obter evento. Erro: {error.Message}",
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEventoAsync(Evento model)
        {
            try
            {
                var evento = await _eventoService.AddEventoAsync(model);

                return evento != null
                    ? Ok(evento)
                    : BadRequest("Erro ao tentar adicionar evento.");
            }
            catch (Exception error)
            {
                return Problem(
                    detail: $"Erro ao adicionar evento. Erro: {error.Message}",
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEventoAsync(int id, Evento model)
        {
            try
            {
                var evento = await _eventoService.UpdateEventoAsync(id, model);

                return evento != null
                    ? Ok(evento)
                    : BadRequest("Erro ao tentar adicionar evento.");
            }
            catch (Exception error)
            {
                return Problem(
                    detail: $"Erro ao modificar evento. Erro: {error.Message}",
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventoAsync(int id)
        {
            try
            {
                return await _eventoService.DeleteEventoAsync(id)
                    ? Ok("Evento deletado.")
                    : BadRequest("Erro ao deletar evento.");
            }
            catch (Exception error)
            {
                return Problem(
                    detail: $"Erro ao deletar evento. Erro: {error.Message}",
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
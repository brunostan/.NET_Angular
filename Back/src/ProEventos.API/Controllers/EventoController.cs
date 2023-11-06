using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{

    private readonly DataContext _context;

    public EventoController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _context.Eventos;
    }

    [HttpGet("{id}")]
    public async Task<Evento?> GetById(int id)
    {
        return await _context.Eventos.FirstOrDefaultAsync(evento => evento.EventoId == id);
    }

    [HttpPost]
    public string Post()
    {
        return "POST value";
    }

    [HttpPut("{id}")]
    public string Put(int id)
    {
        return $"PUT value {id}";
    }

    [HttpDelete("{id}")]
    public string Delete(int id)
    {
        return $"DELETE value {id}";
    }
}

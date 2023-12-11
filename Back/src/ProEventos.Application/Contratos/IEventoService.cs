using ProEventos.Domain;

namespace ProEventos.Application.Contratos;

public interface IEventoService
{
    Task<Evento?> AddEventoAsync(Evento model);
    Task<Evento?> UpdateEventoAsync(int eventoId, Evento model);
    Task<bool> DeleteEventoAsync(int eventoId);

    Task<Evento[]?> GetAllEventosAsync(bool includePalestrantes = false);
    Task<Evento[]?> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
    Task<Evento?> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
}
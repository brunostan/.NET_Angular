using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;

        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            _geralPersist = geralPersist;
            _eventoPersist = eventoPersist;
        }

        public async Task<Evento?> AddEventoAsync(Evento model)
        {
            try
            {
                _geralPersist.Add(model);

                await _geralPersist.SaveChangesAsync();

                return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
            }

            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
        public async Task<Evento?> UpdateEventoAsync(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);

                if (evento == null)
                {
                    return null;
                }

                model.Id = evento.Id;

                _geralPersist.Update(model);

                return await _geralPersist.SaveChangesAsync()
                   ? await _eventoPersist.GetEventoByIdAsync(model.Id, false)
                   : null;
            }

            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public async Task<bool> DeleteEventoAsync(int eventoId)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false)
                    ?? throw new Exception("Evento para delete não encontrado.");

                _geralPersist.Delete(evento);

                return await _geralPersist.SaveChangesAsync();
            }

            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public async Task<Evento[]?> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                return await _eventoPersist.GetAllEventosAsync(includePalestrantes);
            }

            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public async Task<Evento[]?> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                return await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);
            }

            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public async Task<Evento?> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                return await _eventoPersist.GetEventoByIdAsync(eventoId, includePalestrantes);
            }

            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
    }
}
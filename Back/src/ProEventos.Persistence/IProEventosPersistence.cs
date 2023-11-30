using ProEventos.Domain;

namespace ProEventos.Persistence
{
    internal interface IProEventosPersistence
    {
        // GERAL

        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        // EVENTOS

        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
        Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes);

        // PALESTRANTES

        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos);
    }
}
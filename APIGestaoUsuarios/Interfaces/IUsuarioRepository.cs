using APIGestaoUsuarios.Models;

namespace APIGestaoUsuarios.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario?> BuscarPorIdAsync(Guid id);
        Task AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
    }
}

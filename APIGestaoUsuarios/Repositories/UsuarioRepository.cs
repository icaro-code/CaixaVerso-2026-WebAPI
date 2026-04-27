using APIGestaoUsuarios.Interfaces;
using APIGestaoUsuarios.Models;

namespace APIGestaoUsuarios.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Dictionary<string, Usuario> _usuarios = new();

        public Task<Usuario?> GetByEmailAsync(string email) =>
            Task.FromResult(_usuarios.GetValueOrDefault(email)); // <- retorna Usuario?

        public Task<IEnumerable<Usuario>> GetAllAsync() =>
            Task.FromResult(_usuarios.Values.AsEnumerable());

        public Task AddAsync(Usuario usuario)
        {
            _usuarios[usuario.Email] = usuario;
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Usuario usuario)
        {
            _usuarios[usuario.Email] = usuario;
            return Task.CompletedTask;
        }
    }
}
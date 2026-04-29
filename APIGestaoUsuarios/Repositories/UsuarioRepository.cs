using APIGestaoUsuarios.Interfaces;
using APIGestaoUsuarios.Models;

namespace APIGestaoUsuarios.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Dictionary<string, Usuario> _usuarios = new();

        public Task<Usuario?> GetByEmailAsync(string email) =>
            Task.FromResult(_usuarios.GetValueOrDefault(email));

        public Task<IEnumerable<Usuario>> GetAllAsync() =>
            Task.FromResult(_usuarios.Values.AsEnumerable());

        public Task<Usuario?> BuscarPorIdAsync(Guid id)
        {
            var usuario = _usuarios.Values.FirstOrDefault(u => u.Id == id);
            return Task.FromResult(usuario);
        }

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
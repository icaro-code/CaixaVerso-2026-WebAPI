using APIGestaoUsuarios.Aplication.Interfaces;

namespace APIGestaoUsuarios.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Dictionary<Guid, Usuario> _usuarios = new();
        public Task AddAsync(Usuario usuario)
        {
            _usuarios.Add(usuario.Id, usuario);
            return Task.CompletedTask;
        }
        public Task<IEnumerable<Usuario>> GetAllAsync()  => Task.FromResult(_usuarios.Values.AsEnumerable());
        public Task<Usuario?> GetByIdAsync(Guid id)
        => Task.FromResult(_usuarios.GetValueOrDefault(id));
        public Task<Usuario?> GetByEmailAsync(string email)
        => Task.FromResult(_usuarios.Values.FirstOrDefault(u => u.Email == email));
        public Task UpdateAsync(Usuario usuario)
        {
            _usuarios[usuario.Id] = usuario;
            return Task.CompletedTask;
        }
    }
}
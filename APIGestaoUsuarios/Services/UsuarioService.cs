using APIGestaoUsuarios.Interfaces;
using APIGestaoUsuarios.Models;
using APIGestaoUsuarios.Utils;

namespace APIGestaoUsuarios.Aplication.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repo;

        public UsuarioService(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        public async Task<Usuario> CadastrarAsync(string nome, string email, string senha, string? cargo)
        {
            var hash = PasswordHasher.HashPassword(senha);
            var usuario = new Usuario 
            { 
                Nome = nome, 
                Email = email, 
                SenhaHash = hash, 
                Cargo = cargo 
            };

            await _repo.AddAsync(usuario);
            return usuario;
        }

        public async Task<IEnumerable<Usuario>> ListarAsync() => await _repo.GetAllAsync();

        public async Task<Usuario?> BuscarPorEmailAsync(string email)
        {
            return await _repo.GetByEmailAsync(email); // <- coerente com interface
        }

        public async Task<Usuario?> AtualizarAsync(string email, string nome, string? cargo)
        {
            var usuario = await _repo.GetByEmailAsync(email);
            if (usuario == null) return null;

            usuario.Nome = nome;
            usuario.Cargo = cargo;
            usuario.AtualizadoEm = DateTime.Now;

            await _repo.UpdateAsync(usuario);
            return usuario;
        }

        public async Task<Usuario?> DesativarAsync(string email)
        {
            var usuario = await _repo.GetByEmailAsync(email);
            if (usuario == null) return null;

            usuario.Ativo = false;
            usuario.AtualizadoEm = DateTime.Now;

            await _repo.UpdateAsync(usuario);
            return usuario;
        }
    }
}

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
                Cargo = cargo,
                Ativo = true,
                CriadoEm = DateTime.Now,
                AtualizadoEm = DateTime.Now
            };

            await _repo.AddAsync(usuario);
            return usuario;
        }

        public async Task<IEnumerable<Usuario>> ListarAsync() => await _repo.GetAllAsync();

        public async Task<Usuario?> BuscarPorIdAsync(Guid id)
        {
            return await _repo.BuscarPorIdAsync(id);
        }

        public async Task<Usuario?> AtualizarPorIdAsync(Guid id, string? nome, string? cargo)
        {
            var usuario = await _repo.BuscarPorIdAsync(id);
            if (usuario == null) return null;

            // Atualiza apenas os campos informados
            if (!string.IsNullOrWhiteSpace(nome))
                usuario.Nome = nome;

            if (!string.IsNullOrWhiteSpace(cargo))
                usuario.Cargo = cargo;

            usuario.AtualizadoEm = DateTime.Now;

            await _repo.UpdateAsync(usuario);
            return usuario;
        }

        public async Task<Usuario?> DesativarPorIdAsync(Guid id)
        {
            var usuario = await _repo.BuscarPorIdAsync(id);
            if (usuario == null) return null;

            usuario.Ativo = false;
            usuario.AtualizadoEm = DateTime.Now;

            await _repo.UpdateAsync(usuario);
            return usuario;
        }
    }
}

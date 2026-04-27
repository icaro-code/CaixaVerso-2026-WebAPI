namespace APIGestaoUsuarios.Aplication.Services
{
    public interface IUsuarioService
    {
        private readonly IUsuarioRepository _repo;
        private readonly PasswordHasher _hasher;
        public UsuarioService(IUsuarioRepository repo, PasswordHasher hasher)
        {
            _repo = repo;
            _hasher = hasher;
        }

        public async Task<Usuario> CriarAsync(string nome, string email, string senha, string? cargo)
        {
            if (await _repo.GetByEmailAsync(email) != null)
                throw new Exception("Email já cadastrado");
            var usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = nome,
                Email = email,
                SenhaHash = _hasher.Hash(senha),
                Cargo = cargo,
                CriadoEm = DateTime.Now
            };
            await _repo.AddAsync(usuario);
            return usuario;
        }
        public Task<IEnumerable<Usuario>> ListarAsync() => _repo.GetAllAsync();
        public async Task DesativarAsync(Guid id)
        {
            var usuario = await _repo.GetByIdAsync(id)
            ?? throw new Exception("Usuário não encontrado");
            usuario.Ativo = false;
            usuario.AtualizadoEm = DateTime.Now;
            await _repo.UpdateAsync(usuario);
        }
    }
}
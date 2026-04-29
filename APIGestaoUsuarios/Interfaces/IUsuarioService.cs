using APIGestaoUsuarios.Models;

namespace APIGestaoUsuarios.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> CadastrarAsync(string nome, string email, string senha, string? cargo);
        Task<IEnumerable<Usuario>> ListarAsync();
        Task<Usuario?> BuscarPorIdAsync(Guid id);
        Task<Usuario?> AtualizarPorIdAsync(Guid id, string? nome, string? cargo); // <-- ajuste aqui
        Task<Usuario?> DesativarPorIdAsync(Guid id);
    }

}

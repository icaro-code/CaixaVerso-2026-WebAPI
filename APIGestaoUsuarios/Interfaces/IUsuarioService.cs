using APIGestaoUsuarios.Models;

namespace APIGestaoUsuarios.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> CadastrarAsync(string nome, string email, string senha, string? cargo);
        Task<IEnumerable<Usuario>> ListarAsync();
        Task<Usuario?> BuscarPorEmailAsync(string email);   // <- permite null
        Task<Usuario?> AtualizarAsync(string email, string nome, string? cargo); // <- permite null
        Task<Usuario?> DesativarAsync(string email);        // <- permite null
    }
}
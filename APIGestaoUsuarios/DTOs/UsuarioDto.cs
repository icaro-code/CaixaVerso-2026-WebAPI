using System.ComponentModel.DataAnnotations;

namespace APIGestaoUsuarios.DTOs
{
    // Para cadastro
    public class UsuarioCadastroDto
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres")]
        public required string Senha { get; set; }

        [Required(ErrorMessage = "O cargo é obrigatório")]
        public required string Cargo { get; set; }
    }

    // Para atualização
    public class UsuarioAtualizacaoDto
    {
        public string? Nome { get; set; }
        public string? Cargo { get; set; }
    }
}

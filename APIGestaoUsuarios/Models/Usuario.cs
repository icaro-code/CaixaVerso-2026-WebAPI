namespace APIGestaoUsuarios.Models
{
    public class Usuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public required string Nome { get; set; }   // obrigatório
        public required string Email { get; set; }  // obrigatório
        public required string SenhaHash { get; set; } // obrigatório

        public bool Ativo { get; set; } = true;
        public DateTime CriadoEm { get; set; } = DateTime.Now;

        public DateTime? AtualizadoEm { get; set; } // opcional
        public string? Cargo { get; set; }          // opcional
    }
}
namespace APIGestaoUsuarios.Models
{
    public class Usuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public required string Nome { get; set; } 
        public required string Email { get; set; } 
        public required string SenhaHash { get; set; }

        public bool Ativo { get; set; } = true;
        public DateTime CriadoEm { get; set; } = DateTime.Now;

        public DateTime? AtualizadoEm { get; set; } 
        public string? Cargo { get; set; }          
    }
}
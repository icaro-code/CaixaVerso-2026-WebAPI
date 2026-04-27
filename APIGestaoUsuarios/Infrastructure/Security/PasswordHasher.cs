using Microsoft.AspNetCore.Identity;


namespace APIGestaoUsuarios.Infrastructure.Security
{
    public class PasswordHasher
    {
        private readonly PasswordHasher<string> _hasher = new();
        public string Hash(string senha)
        => _hasher.HashPassword(null!, senha);
    }
}
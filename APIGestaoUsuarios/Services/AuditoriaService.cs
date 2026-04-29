using Microsoft.Extensions.Logging;

namespace APIGestaoUsuarios.Services
{
    public class AuditoriaService
    {
        private readonly ILogger<AuditoriaService> _logger;

        public AuditoriaService(ILogger<AuditoriaService> logger)
        {
            _logger = logger;
        }

        public void Registrar(string acao, Guid? usuarioId = null, string? detalhes = null)
        {
            _logger.LogInformation(
                "AUDITORIA => Ação: {Acao}, UsuarioId: {UsuarioId}, Detalhes: {Detalhes}, Timestamp: {Timestamp}",
                acao,
                usuarioId,
                detalhes,
                DateTime.Now
            );
        }
    }
}

using APIGestaoUsuarios.Interfaces;
using APIGestaoUsuarios.DTOs;
using APIGestaoUsuarios.Services; // importar o AuditoriaService
using Microsoft.AspNetCore.Mvc;

namespace APIGestaoUsuario.Controllers
{
    [ApiController]
    [Route("api/v1/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        private UsuarioRespostaDto MapToRespostaDto(APIGestaoUsuarios.Models.Usuario usuario)
        {
            return new UsuarioRespostaDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Cargo = usuario.Cargo,
                Ativo = usuario.Ativo,
                CriadoEm = usuario.CriadoEm,
                AtualizadoEm = usuario.AtualizadoEm
            };
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] UsuarioCadastroDto dto, [FromServices] AuditoriaService auditoria)
        {
            var usuario = await _service.CadastrarAsync(dto.Nome, dto.Email, dto.Senha, dto.Cargo);
            var resposta = MapToRespostaDto(usuario);

            auditoria.Registrar("Cadastro de usuário", usuario.Id, $"Email: {usuario.Email}");

            return Ok(resposta);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar([FromServices] AuditoriaService auditoria)
        {
            var usuarios = await _service.ListarAsync();
            var resposta = usuarios.Select(u => MapToRespostaDto(u));

            auditoria.Registrar("Listagem de usuários", null, $"Total: {usuarios.Count()}");

            return Ok(resposta);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(Guid id, [FromServices] AuditoriaService auditoria)
        {
            var usuario = await _service.BuscarPorIdAsync(id);
            if (usuario == null) return NotFound();

            var resposta = MapToRespostaDto(usuario);
            auditoria.Registrar("Busca de usuário por ID", usuario.Id);

            return Ok(resposta);
        }

        [HttpGet("{id}/senha-hash")]
        public async Task<IActionResult> VerificarHash(Guid id)
        {
            var usuario = await _service.BuscarPorIdAsync(id);
            if (usuario == null) return NotFound();

            return Ok(new
            {
                Mensagem = "Senha hash não retornar para o cliente",
                HashDidatico = usuario.SenhaHash
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] UsuarioAtualizacaoDto dto, [FromServices] AuditoriaService auditoria)
        {
            var usuario = await _service.AtualizarPorIdAsync(id, dto.Nome, dto.Cargo);
            if (usuario == null) return NotFound();

            var resposta = MapToRespostaDto(usuario);
            auditoria.Registrar("Atualização de usuário", usuario.Id, $"Novo nome: {usuario.Nome}");

            return Ok(resposta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Desativar(Guid id, [FromServices] AuditoriaService auditoria)
        {
            var usuario = await _service.DesativarPorIdAsync(id);
            if (usuario == null) return NotFound();

            var resposta = MapToRespostaDto(usuario);
            auditoria.Registrar("Desativação de usuário", usuario.Id);

            return Ok(resposta);
        }
    }
}

using APIGestaoUsuarios.Interfaces;
using APIGestaoUsuarios.DTOs;
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

        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] UsuarioDto dto)
        {
            var usuario = await _service.CadastrarAsync(dto.Nome, dto.Email, dto.Senha, dto.Cargo);
            return Ok(usuario);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            var usuarios = await _service.ListarAsync();
            return Ok(usuarios);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Buscar(string email)
        {
            var usuario = await _service.BuscarPorEmailAsync(email);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpPut("atualizar/{email}")]
        public async Task<IActionResult> Atualizar(string email, [FromBody] UsuarioDto dto)
        {
            var usuario = await _service.AtualizarAsync(email, dto.Nome, dto.Cargo);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpDelete("desativar/{email}")]
        public async Task<IActionResult> Desativar(string email)
        {
            var usuario = await _service.DesativarAsync(email);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }
    }
}
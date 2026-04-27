using Microsoft.AspNetCore.Mvc;

namespace APIGestaoUsuarios.Controllers
{
    [ApiController]
    [Route("api/v1/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;
        public UsuariosController(IUsuarioService service)
        => _service = service;
        
        [HttpPost]
        public async Task<IActionResult> Criar(UsuarioCreateDto dto)
        => Ok(await _service.CriarAsync(dto.Nome, dto.Email, dto.Senha, dto.Cargo));

        [HttpGet]
        public async Task<IActionResult> Listar() => Ok(await _service.ListarAsync());
       
        [HttpDelete("{id}/desativar")]
        public async Task<IActionResult> Desativar(Guid id)
        {
            await _service.DesativarAsync(id);
            return NoContent();
        }
    }
}
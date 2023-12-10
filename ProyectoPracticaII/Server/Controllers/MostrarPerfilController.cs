using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPracticaII.Client.Models;

namespace ProyectoPracticaII.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MostrarPerfilController : ControllerBase
    {
        private readonly Motored01Context motored01Context;

        public MostrarPerfilController(Motored01Context motored01Context)
        {
            this.motored01Context = motored01Context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<Usuario>>> GetUsuario(int id)
        {
            var lista = await motored01Context.Usuarios.Where(e => e.IdUsuario == id).ToListAsync();
            return Ok(lista);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<List<Usuario>>> UpdateUsuario(Usuario objeto)
        {

            var DbObjeto = await motored01Context.Usuarios.FindAsync(objeto.IdUsuario);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            DbObjeto.NombreUsuario = objeto.NombreUsuario;
            DbObjeto.Correo = objeto.Correo;
            DbObjeto.Clave = objeto.Clave;

            await motored01Context.SaveChangesAsync();

            return Ok(await motored01Context.Usuarios.ToListAsync());

        }
    }
}

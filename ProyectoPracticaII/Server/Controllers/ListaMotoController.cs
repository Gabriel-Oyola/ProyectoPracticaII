using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPracticaII.Client.Models;

namespace ProyectoPracticaII.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaMotoController : ControllerBase
    {
        private readonly Motored01Context motored01Context;

        public ListaMotoController(Motored01Context motored01Context)
        {
            this.motored01Context = motored01Context;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Motocicleta>>> GetSingleMotocicleta(int id)
        {
            var miobjeto = await motored01Context.Motocicletas.FirstOrDefaultAsync(ob => ob.IdMoto == id);
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);



        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<Motocicleta>>> GetMotocicleta(int id)
        {
            var lista = await motored01Context.Motocicletas.Where(e => e.IdUsuario == id).ToListAsync();
            return Ok(lista);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPracticaII.Client.Models;

namespace ProyectoPracticaII.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaTallerController : ControllerBase
    {
        private readonly Motored01Context motored01Context;

        public ListaTallerController(Motored01Context motored01Context)
        {
            this.motored01Context = motored01Context;
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<Taller>>> GetTaller(int id)
        {
            var lista = await motored01Context.Tallers.Where(e => e.IdUsuario == id).ToListAsync();
            return Ok(lista);
        }
    }
}

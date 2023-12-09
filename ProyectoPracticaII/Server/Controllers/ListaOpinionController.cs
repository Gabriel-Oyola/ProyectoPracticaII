using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPracticaII.Client.Models;

namespace ProyectoPracticaII.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaOpinionController : ControllerBase
    {
        private readonly Motored01Context motored01Context;

        public ListaOpinionController(Motored01Context motored01Context)
        {
            this.motored01Context = motored01Context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<Opinione>>> GetOpinion(int id)
        {
            var lista = await motored01Context.Opiniones.Where(e => e.IdTaller == id).ToListAsync();
            return Ok(lista);
        }

       

        
    }
}

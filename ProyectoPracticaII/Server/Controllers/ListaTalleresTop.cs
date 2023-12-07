using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPracticaII.Client.Models;

namespace ProyectoPracticaII.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaTalleresTop : ControllerBase
    {
        private readonly Motored01Context motored01Context;

        public ListaTalleresTop(Motored01Context motored01Context)
        {
            this.motored01Context = motored01Context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<TallerTop>>> GetOpinion(int id)
        {
            var lista = await motored01Context.Opiniones.Where(e => e.IdTaller == id).OrderByDescending(e => e.Rating).AverageAsync(e => e.Rating); 
            return Ok(lista);
        }

      

    }
}



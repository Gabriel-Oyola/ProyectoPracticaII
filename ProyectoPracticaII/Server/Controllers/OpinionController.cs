using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPracticaII.Client.Models;

namespace ProyectoPracticaII.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpinionController : ControllerBase
    {
        private readonly Motored01Context motored01Context; 

        public OpinionController(Motored01Context motored01Context)
        {
            this.motored01Context = motored01Context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Taller>>> Get()
        {
            var resp = await motored01Context.Tallers.ToListAsync();
            return resp;
        }



        private async Task<List<Opinione>> GetDbOpiniones()
        {
            return await motored01Context.Opiniones.ToListAsync();
        }

        [HttpPost]

        public async Task<ActionResult<Opinione>> CreateOpinion(Opinione objeto)
        {

            motored01Context.Opiniones.Add(objeto);
            await motored01Context.SaveChangesAsync();
            return Ok(await GetDbOpiniones());
        }

    }


  
}

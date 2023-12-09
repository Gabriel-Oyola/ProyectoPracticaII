using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPracticaII.Client.Models;


namespace ProyectoPracticaII.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaReporteOpinionController : ControllerBase
    {
        private readonly Motored01Context motored01Context;

        public ListaReporteOpinionController(Motored01Context motored01Context)
        {
            this.motored01Context = motored01Context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<ReportesOpinione>>> GetOpinion(int id)
        {
            var lista = await motored01Context.ReportesOpiniones.Where(e => e.IdReporte == id).ToListAsync();
            return Ok(lista);
        }




    }
}

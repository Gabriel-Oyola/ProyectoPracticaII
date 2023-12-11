using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPracticaII.Client.Models;

namespace ProyectoPracticaII.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteOPController : ControllerBase
    {
        private readonly Motored01Context motored01Context;

        public ReporteOPController(Motored01Context motored01Context)
        {
            this.motored01Context = motored01Context;
        }

      

        [HttpPost]
        public async Task<ActionResult<ReportesOpinione>> CreateReporte(ReportesOpinione objeto)
        {

            motored01Context.ReportesOpiniones.Add(objeto);
            await motored01Context.SaveChangesAsync();
            return Ok(await GetReportesOpiniones());
        }

        [HttpGet("Lista")]
        public async Task<ActionResult<List<ReportesOpinione>>> GetMotocicleta()
        {
            var lista = await motored01Context.ReportesOpiniones.ToListAsync();
            return Ok(lista);
        }


        private async Task<List<ReportesOpinione>> GetReportesOpiniones()
        {
            return await motored01Context.ReportesOpiniones.ToListAsync();
        }
    }
}

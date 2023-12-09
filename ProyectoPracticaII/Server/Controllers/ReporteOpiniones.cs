using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPracticaII.Client.Models;

namespace ProyectoPracticaII.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteOpiniones
    {
      
        public class OpinionController : ControllerBase
        {
            private readonly Motored01Context motored01Context;

            public OpinionController(Motored01Context motored01Context)
            {
                this.motored01Context = motored01Context;
            }

            [HttpGet]
            public async Task<ActionResult<List<Opinione>>> Get()
            {
                var resp = await motored01Context.Opiniones.ToListAsync();
                return resp;
            }



            private async Task<List<ReportesOpinione>> GetReportesOpiniones()
            {
                return await motored01Context.ReportesOpiniones.ToListAsync();
            }

            [HttpPost]

            public async Task<ActionResult<ReportesOpinione>> CreateReporte(ReportesOpinione objeto)
            {

                motored01Context.ReportesOpiniones.Add(objeto);
                await motored01Context.SaveChangesAsync();
                return Ok(await GetReportesOpiniones());
            }

        }
    }
}

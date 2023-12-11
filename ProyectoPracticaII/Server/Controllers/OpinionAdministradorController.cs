using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPracticaII.Client.Models;

namespace ProyectoPracticaII.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpinionAdministradorController : ControllerBase
    {
        private readonly Motored01Context motored01Context;

        public OpinionAdministradorController(Motored01Context motored01Context)
        {
            this.motored01Context = motored01Context;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Opinione>>> DeleteOpinion(int id)
        {
            var DbObjeto = await motored01Context.Opiniones.FirstOrDefaultAsync(Ob => Ob.IdOpinion == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            motored01Context.Opiniones.Remove(DbObjeto);
            await motored01Context.SaveChangesAsync();

            return Ok(await GetOpiniones());
        }


        private async Task<List<Opinione>> GetOpiniones()
        {
            return await motored01Context.Opiniones.ToListAsync();
        }


     






         [HttpDelete]
        [Route("EliminarOpinion/{id}")]
        public async Task<ActionResult<List<ReportesOpinione>>> DeleteReporte(int id)
        {
            var DbObjeto = await motored01Context.ReportesOpiniones.FirstOrDefaultAsync(Ob => Ob.IdReporte == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            motored01Context.ReportesOpiniones.Remove(DbObjeto);
            await motored01Context.SaveChangesAsync();

            return Ok(await GetReportes());
        }


        private async Task<List<Opinione>> GetReportes()
        {
            return await motored01Context.Opiniones.ToListAsync();
        }
    }
}

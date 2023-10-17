using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPracticaII.Client.Models;

namespace ProyectoPracticaII.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TallerController : ControllerBase
    {
        private readonly Motored01Context motored01Context; 

        public TallerController(Motored01Context motored01Context)
        {
            this.motored01Context = motored01Context; 
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Taller>> Get(int id)
        {
            var Taller = await motored01Context.Tallers
                                         .Where(e => e.IdTaller == id)
                                         //.Include(m => m.Matriculas)
                                         .FirstOrDefaultAsync();
            if (Taller == null)
            {
                return NotFound($"No existe el Taller de Id={id}");
            }
            return Taller;
        }


        [HttpPost]

        public async Task<ActionResult<Taller>> CreateMotocicleta(Taller objeto)
        {

            motored01Context.Tallers.Add(objeto);
            await motored01Context.SaveChangesAsync();
            return Ok(await GetDbTaller());
        }

        private async Task<List<Taller>> GetDbTaller()
        {
            return await motored01Context.Tallers.ToListAsync();
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<List<Taller>>> UpdateTaller(Taller objeto)
        {

            var DbObjeto = await motored01Context.Tallers.FindAsync(objeto.IdTaller);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            DbObjeto.NombreTaller = objeto.NombreTaller;
            DbObjeto.País = objeto.País;
            DbObjeto.Provincia = objeto.Provincia;
            DbObjeto.Localidad = objeto.Localidad;
            DbObjeto.Direccion = objeto.Direccion;
            DbObjeto.Email = objeto.Email;
            DbObjeto.Numero = objeto.Numero;
            DbObjeto.Horarios = objeto.Horarios;
            DbObjeto.LinksMapa = objeto.LinksMapa;
            



            await motored01Context.SaveChangesAsync();

            return Ok(await motored01Context.Tallers.ToListAsync());


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Taller>>> DeleteTaller(int id)
        {
            var DbObjeto = await motored01Context.Tallers.FirstOrDefaultAsync(Ob => Ob.IdTaller == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            motored01Context.Tallers.Remove(DbObjeto);
            await motored01Context.SaveChangesAsync();

            return Ok(await GetDbTaller());
        }
    }
}

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
            var lista = await motored01Context.Motocicletas.Where(e => e.IdUsuario == id && e.Estado != "Baja").ToListAsync();
            return Ok(lista);
        }

        [HttpPut("ActualizarEstado/{id}")]
        public async Task<IActionResult> ActualizarEstado(int id)
        {
            var Moto = await motored01Context.Motocicletas.FindAsync(id);

            if (Moto == null)
            {
                return NotFound(); // Si no se encuentra el Moto, se retorna un error 404
            }

            if (Moto.Estado == null)
            {
                Moto.Estado = "Baja"; // Actualiza el estado a "Baja" si es null
                motored01Context.Entry(Moto).State = EntityState.Modified;
                await motored01Context.SaveChangesAsync();
                return Ok(); // Retorna un código 200 indicando éxito en la actualización
            }
            else
            {
                return BadRequest("El estado ya está definido."); // Si el estado ya tiene un valor, se retorna un error 400
            }
        }

    }
}

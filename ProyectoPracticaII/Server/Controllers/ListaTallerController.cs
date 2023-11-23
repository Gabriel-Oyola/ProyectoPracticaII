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



        [HttpPut("ActualizarEstado/{id}")]
        public async Task<IActionResult> ActualizarEstado(int id)
        {
            var taller = await motored01Context.Tallers.FindAsync(id);

            if (taller == null)
            {
                return NotFound(); // Si no se encuentra el taller, se retorna un error 404
            }

            if (taller.Estado == null)
            {
                taller.Estado = "Baja"; // Actualiza el estado a "Baja" si es null
                motored01Context.Entry(taller).State = EntityState.Modified;
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

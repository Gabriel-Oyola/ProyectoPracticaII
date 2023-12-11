using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPracticaII.Client.Models;

namespace ProyectoPracticaII.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaBTController : ControllerBase
    {

        private readonly Motored01Context _Context;

        public ListaBTController(Motored01Context motored01Context)
        {
            _Context = motored01Context;
        }

        
        [HttpGet("{nombre}")]
        public async Task<ActionResult<Taller>> GetTallerPorNombre(string nombre)
        {
            try
            {
                var taller = await _Context.Tallers
                    .FirstOrDefaultAsync(t => t.NombreTaller == nombre);

                if (taller == null)
                {
                    // Aquí puedes establecer una variable de estado o mostrar un mensaje al usuario
                }

                return taller;
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar cualquier excepción no controlada, por ejemplo, registrándola o mostrando un mensaje de error genérico.

                return NotFound();
            }


        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<Motocicleta>>> GetMotocicleta(int id)
        {
            var lista = await _Context.Motocicletas.Where(e => e.IdUsuario == id).ToListAsync();
            return Ok(lista);
        }

       

        //[HttpGet("RatrearIdT/{nombre}")]
        //public async Task<ActionResult<int>> Get(string nombre)
        //{
        //    var IdT = await _Context.Tallers
        //                                 .Where(e => e.NombreTaller == nombre)
        //                                 .Select(u => u.IdTaller)
        //                                 //.Include(m => m.Matriculas)
        //                                 .FirstOrDefaultAsync();
        //    if (    IdT == null)
        //    {
        //        return NotFound($"No existe usuario con el correo ={nombre}");
        //    }
        //    return IdT;
        //}

    }
}

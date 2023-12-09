using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPracticaII.Client.Models;

namespace ProyectoPracticaII.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RastrearIdController : ControllerBase
    {
        private readonly Motored01Context _dbContext;

        public RastrearIdController(Motored01Context dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<int>> Get(string correo)
        {
            var Usuario = await _dbContext.Usuarios
                                         .Where(e => e.Correo == correo)
                                         .Select(u => u.IdUsuario)
                                         //.Include(m => m.Matriculas)
                                         .FirstOrDefaultAsync();
            if (    Usuario == null)
            {
                return NotFound($"No existe usuario con el correo ={correo}");
            }
            return Usuario;
        }


    }
}

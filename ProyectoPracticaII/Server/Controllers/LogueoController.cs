using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPracticaII.Client.Models;
using System.Security.Claims;

namespace ProyectoPracticaII.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogueoController : ControllerBase
    {
        private readonly Motored01Context _dbContext;

        public LogueoController(Motored01Context dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpPost]
        
        public async Task<ActionResult<Usuario>> IniciarSesion(string correo, string clave)
        {

            Usuario usuario_encontrado = await GetUsuario(correo, clave);

            if (usuario_encontrado == null)
            {
                string error = "No se encontraron coinsidencias";

            }

           
            return usuario_encontrado;
        }
        public async Task<Usuario> GetUsuario(string correo, string clave)
        {
            Usuario usuario_encontrado = await _dbContext.Usuarios.Where(u => u.Correo == correo && u.Clave == clave).FirstOrDefaultAsync();

            return usuario_encontrado;
        }

    }
}

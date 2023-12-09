using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPracticaII.Client.Models;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;

using ProyectoPracticaII.Shared;

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
        [Route("Login")]

        public async Task<ActionResult> Login([FromBody]LoginDTO login)
        {
            SesionDTO sesionDTO = new SesionDTO();
            ULT email = new ULT(); 

            Usuario usuario_encontrado = await GetUsuario(login.Correo, CalcularHash(login.Clave));

            if(usuario_encontrado != null)
            {
                sesionDTO.Nombre = usuario_encontrado.NombreUsuario;
                sesionDTO.Correo = login.Correo;
                sesionDTO.Rol = "UsuarioRegistrado";
                email.GuardarDato(login.Correo);
            }
            if(login.Correo=="invitado@email.com" && login.Clave=="1234")
            {
                sesionDTO.Nombre = "Invitado";
                sesionDTO.Correo = login.Correo;
                sesionDTO.Rol = "invitado";
            }

            return StatusCode(StatusCodes.Status200OK, sesionDTO); 

        }

        //public async Task<ActionResult<Usuario>> IniciarSesion(Usuario usuario)
        //{


        //    Usuario usuario_encontrado = await GetUsuario(usuario.Correo, CalcularHash( usuario.Clave));

        //    if (usuario_encontrado == null)
        //    {
        //        string error = "No se encontraron coinsidencias";

        //    }


        //    return usuario_encontrado;
        //}
        public async Task<Usuario> GetUsuario(string correo, string clave)
        {
            bool Status;
            Usuario usuario_encontrado = await _dbContext.Usuarios.Where(u => u.Correo == correo && u.Clave == clave).FirstOrDefaultAsync();

            if (usuario_encontrado != null)
            {
                Status = true;
            }
            else
            {
                Status = false;
            }
            return usuario_encontrado;


        }


        private string CalcularHash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }
}

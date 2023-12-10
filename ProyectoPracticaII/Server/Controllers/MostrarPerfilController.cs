using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPracticaII.Client.Models;
using System.Security.Cryptography;
using System.Text;

namespace ProyectoPracticaII.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MostrarPerfilController : ControllerBase
    {
        private readonly Motored01Context motored01Context;

        public MostrarPerfilController(Motored01Context motored01Context)
        {
            this.motored01Context = motored01Context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var User = await motored01Context.Usuarios.Where(e => e.IdUsuario == id).FirstOrDefaultAsync();
            if (User == null)
            {
                return NotFound($"No existe el usuario de Id={id}");
            }
            ConvertToHexString(User.Clave);
            return Ok(User);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<List<Usuario>>> UpdateUsuario(Usuario objeto)
        {

            var DbObjeto = await motored01Context.Usuarios.FindAsync(objeto.IdUsuario);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            DbObjeto.NombreUsuario = objeto.NombreUsuario;
            DbObjeto.Correo = objeto.Correo;
            DbObjeto.Clave = CalcularHash(objeto.Clave);

            await motored01Context.SaveChangesAsync();

            return Ok(await motored01Context.Usuarios.ToListAsync());

            

        }
        public static string ConvertToHexString(string hash)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("x2")); // Convierte cada byte a su representación hexadecimal
            }
            return sb.ToString();
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

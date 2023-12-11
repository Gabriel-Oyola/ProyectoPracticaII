using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPracticaII.Client.Models;
using ProyectoPracticaII.Shared;
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
  

        [HttpPost]
        [Route("Login")]

        public async Task<ActionResult> Login([FromBody] LoginDTO login)
        {
            SesionDTO sesionDTO = new SesionDTO();
           

            Usuario usuario_encontrado = await GetUsuario(login.Correo, CalcularHash(login.Clave));

            if (usuario_encontrado != null)
            {
                sesionDTO.Nombre = usuario_encontrado.NombreUsuario;
                sesionDTO.Correo = login.Correo;
                sesionDTO.Rol = "UsuarioRegistrado";
             
            }
          

            return StatusCode(StatusCodes.Status200OK, sesionDTO);

        }

       
        public async Task<Usuario> GetUsuario(string correo, string clave)
        {
            bool Status;
            Usuario usuario_encontrado = await motored01Context.Usuarios.Where(u => u.Correo == correo && u.Clave == clave).FirstOrDefaultAsync();

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

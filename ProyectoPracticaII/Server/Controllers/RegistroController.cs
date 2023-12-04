using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using System;
using ProyectoPracticaII.Client.Models;
using Microsoft.EntityFrameworkCore;

namespace ProyectoPracticaII.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroController : ControllerBase
    {
        private readonly Motored01Context _context;

        public RegistroController(Motored01Context context)
        {
            _context = context;
        }

        [HttpPost]
        
        public async Task<ActionResult<Usuario>> Registrarse(Usuario modelo)
        {
            modelo.Clave = CalcularHash(modelo.Clave);


            _context.Usuarios.Add(modelo);
            await _context.SaveChangesAsync();
            return modelo;



        }


        private string CalcularHash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convertir la contraseña en bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convertir los bytes a una cadena hexadecimal
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

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoPracticaII.Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;
using System;

namespace ProyectoPracticaII.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotocicletaController : ControllerBase
    {
        private readonly Motored01Context motored01Context;

        public MotocicletaController(Motored01Context motored01Context)
        {
            this.motored01Context = motored01Context;
        }

        //[HttpGet("{id:int}")]

        //public async Task<ActionResult<List<Motocicleta>>> GetMotocicleta(int id)
        //{
        //    var lista = await motored01Context.Motocicletas.Where(e => e.IdUsuario == id).ToListAsync();
        //    return Ok(lista);
        //}

        //[HttpGet]
        //public async Task<ActionResult<List<Motocicleta>>> Get()
        //{
        //    var resp = await motored01Context.Motocicletas.ToListAsync();
        //    return resp;
        //}



        //[HttpGet]
        //[Route("{id}")]
        //public async Task<ActionResult<List<Motocicleta>>> GetSingleMotocicleta(int id)
        //{
        //    var miobjeto = await motored01Context.Motocicletas.FirstOrDefaultAsync(ob => ob.IdMoto == id);
        //    if (miobjeto == null)
        //    {
        //        return NotFound(" :/");
        //    }

        //    return Ok(miobjeto);



        //}

        [HttpGet("{id:int}")]
        
        public async Task<ActionResult<Motocicleta>> Get(int id)
        {
            var Moto = await motored01Context.Motocicletas
                                         .Where(e => e.IdMoto == id)
                                         //.Include(m => m.Matriculas)
                                         .FirstOrDefaultAsync();
            if (Moto == null)
            {
                return NotFound($"No existe la motocicleta de Id={id}");
            }
            return Moto;
        }

        [HttpPost]

        public async Task<ActionResult<Motocicleta>> CreateMotocicleta(Motocicleta objeto)
        {

            motored01Context.Motocicletas.Add(objeto);
            await motored01Context.SaveChangesAsync();
            return Ok(await GetDbMotocicleta());
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<List<Motocicleta>>> UpdateMotocicleta(Motocicleta objeto)
        {

            var DbObjeto = await motored01Context.Motocicletas.FindAsync(objeto.IdMoto);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            DbObjeto.Patente = objeto.Patente;
            DbObjeto.Marca = objeto.Marca; 
            DbObjeto.Modelo = objeto.Modelo;
            DbObjeto.Año = objeto.Año;
            DbObjeto.Aseguradora = objeto.Aseguradora; 

            await motored01Context.SaveChangesAsync();

            return Ok(await motored01Context.Motocicletas.ToListAsync());


        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Motocicleta>>> DeleteMotocicleta(int id)
        {
            var DbObjeto = await motored01Context.Motocicletas.FirstOrDefaultAsync(Ob => Ob.IdMoto == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            motored01Context.Motocicletas.Remove(DbObjeto);
            await motored01Context.SaveChangesAsync();

            return Ok(await GetDbMotocicleta());
        }


        private async Task<List<Motocicleta>> GetDbMotocicleta()
        {
            return await motored01Context.Motocicletas.ToListAsync();
        }


    }
}


        
            





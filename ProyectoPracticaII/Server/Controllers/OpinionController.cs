﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using ProyectoPracticaII.Client.Models;

namespace ProyectoPracticaII.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpinionController : ControllerBase
    {
        private readonly Motored01Context motored01Context; 

        public OpinionController(Motored01Context motored01Context)
        {
            this.motored01Context = motored01Context;
        }

        [HttpGet("GetOpinionesPorIdTaller/{idTaller}")]
        public async Task<ActionResult<IEnumerable<Opinione>>> GetOpinionesPorIdTaller(int idTaller)
        {
            // Recupera la lista de opiniones asociadas al IdTaller proporcionado
            var opiniones = await motored01Context.Opiniones
                .Where(opinion => opinion.IdTaller == idTaller)
                .ToListAsync();

            if (opiniones == null || opiniones.Count == 0)
            {
                return NotFound(); // No se encontraron opiniones para el IdTaller dado
            }

            return opiniones;
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<Opinione>> Get(int id)
        {
            var opinion = await motored01Context.Opiniones
                                         .Where(e => e.IdOpinion == id)
                                         //.Include(m => m.Matriculas)
                                         .FirstOrDefaultAsync();
            if (opinion == null)
            {
                return NotFound($"No existe la motocicleta de Id={id}");
            }
            return opinion;
        }

        
        private async Task<List<Opinione>> GetDbOpiniones()
        {
            return await motored01Context.Opiniones.ToListAsync();
        }

        [HttpPost]

        public async Task<ActionResult<Opinione>> CreateOpinion(Opinione objeto)
        {

            motored01Context.Opiniones.Add(objeto);
            await motored01Context.SaveChangesAsync();
            return Ok(await GetDbOpiniones());
        }

    }


  
}

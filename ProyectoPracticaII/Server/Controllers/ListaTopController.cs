using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPracticaII.Client.Models;
using ProyectoPracticaII.Client.Pages.PTaller;

namespace ProyectoPracticaII.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaTopController : ControllerBase
    {
        private readonly Motored01Context motored01Context;

        public ListaTopController(Motored01Context motored01Context)
        {
            this.motored01Context = motored01Context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TallerTop>>> GetOpinion()
        {
            //            var sumaRatingsPorTaller = motored01Context.Opiniones
            //    .GroupBy(opinion => opinion.IdTaller) // Agrupar por IdTaller
            //    .Select(grupo => new
            //    {
            //        IdTaller = grupo.Key, // Obtener el IdTaller del grupo actual
            //        SumaRating = grupo.Sum(opinion => opinion.Rating ?? 0) // Sumar los ratings del grupo actual
            //    })
            //    .AsNoTracking() // Agregar AsNoTracking aquí
            //    .ToList();

            //            var promedioRatingsPorTaller = sumaRatingsPorTaller
            //.Select(resultado => new
            //{
            //    IdTaller = resultado.IdTaller,
            //    PromedioRating = (double)resultado.SumaRating / motored01Context.Opiniones.Count(opinion => opinion.IdTaller == resultado.IdTaller)
            //})
            //.ToList();
            //            var resultadosConNombres = promedioRatingsPorTaller
            //                .Join(
            //                    motored01Context.Tallers,
            //                    resultado => resultado.IdTaller,
            //                    taller => taller.IdTaller,
            //                    (resultado, taller) => new
            //                    {
            //                        IdTaller = resultado.IdTaller,
            //                        NombreTaller = taller.NombreTaller, // Nombre del taller
            //                        PromedioRating = (double)resultado.PromedioRating / motored01Context.Opiniones.Count(opinion => opinion.IdTaller == resultado.IdTaller)
            //                    })
            //                .ToList();




            //            var resultadosOrdenados = resultadosConNombres
            //    .OrderByDescending(resultado => resultado.PromedioRating)
            //    .ToList();

            //            var primerosResultados = resultadosOrdenados.Take(3).ToList();


            //            return Ok(primerosResultados);

            ///////////////////////////Controlador guardando y funcionando bien///////////////////////////////////

            //       var sumaRatingsPorTaller = motored01Context.Opiniones
            //.GroupBy(opinion => opinion.IdTaller) // Agrupar por IdTaller
            //.Select(grupo => new
            //{
            //    IdTaller = grupo.Key, // Obtener el IdTaller del grupo actual
            //    SumaRating = grupo.Sum(opinion => opinion.Rating ?? 0) // Sumar los ratings del grupo actual
            //})
            //.AsNoTracking() // Agregar AsNoTracking aquí
            //.ToList();

            //       var promedioRatingsPorTaller = sumaRatingsPorTaller
            //           .Select(resultado => new
            //           {
            //               IdTaller = resultado.IdTaller,
            //               PromedioRating = (double)resultado.SumaRating / motored01Context.Opiniones.Count(opinion => opinion.IdTaller == resultado.IdTaller)
            //           })
            //           .ToList();

            //       var resultadosConNombres = promedioRatingsPorTaller
            //           .Join(
            //               motored01Context.Tallers,
            //               resultado => resultado.IdTaller,
            //               taller => taller.IdTaller,
            //               (resultado, taller) => new TallerTop
            //               {
            //                   IdTaller = (int)resultado.IdTaller,
            //                   NombreTaller = taller.NombreTaller, // Nombre del taller
            //                   PromedioRating = resultado.PromedioRating
            //               })
            //           .ToList();

            //       var resultadosOrdenados = resultadosConNombres
            //           .OrderByDescending(resultado => resultado.PromedioRating)
            //           .ToList();

            //       var primerosResultados = resultadosOrdenados.Take(3).ToList();

            //       // Guardar en la base de datos
            //       motored01Context.TallerTops.AddRange(resultadosOrdenados);
            //       await motored01Context.SaveChangesAsync();

            //       return Ok(primerosResultados);


            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
        

            if (!motored01Context.TallerTops.Any()) // Verifica si la tabla está vacía
            {
                // Si está vacía, realiza la carga de datos
                var sumaRatingsPorTaller = motored01Context.Opiniones
                    .GroupBy(opinion => opinion.IdTaller)
                    .Select(grupo => new
                    {
                        IdTaller = grupo.Key,
                        SumaRating = grupo.Sum(opinion => opinion.Rating ?? 0)
                    })
                    .AsNoTracking()
                    .ToList();

                var promedioRatingsPorTaller = sumaRatingsPorTaller
                    .Select(resultado => new
                    {
                        IdTaller = resultado.IdTaller,
                        PromedioRating = (double)resultado.SumaRating / motored01Context.Opiniones.Count(opinion => opinion.IdTaller == resultado.IdTaller)
                    })
                    .ToList();

                var resultadosConNombres = promedioRatingsPorTaller
                    .Join(
                        motored01Context.Tallers,
                        resultado => resultado.IdTaller,
                        taller => taller.IdTaller,
                        (resultado, taller) => new TallerTop
                        {
                            IdTaller = (int)resultado.IdTaller,
                            NombreTaller = taller.NombreTaller,
                            PromedioRating = resultado.PromedioRating
                        })
                    .ToList();

                var resultadosOrdenados = resultadosConNombres
                    .OrderByDescending(resultado => resultado.PromedioRating)
                    .ToList();

                var primerosResultados = resultadosOrdenados.Take(10).ToList();

                // Guardar los nuevos datos en la base de datos
                motored01Context.TallerTops.AddRange(resultadosOrdenados);
                await motored01Context.SaveChangesAsync();

                return Ok(primerosResultados);
            }
            else
            {
                // Si la tabla tiene datos, borra los existentes y carga los nuevos
                motored01Context.TallerTops.RemoveRange(motored01Context.TallerTops);

                var sumaRatingsPorTaller = motored01Context.Opiniones
            .GroupBy(opinion => opinion.IdTaller) // Agrupar por IdTaller
            .Select(grupo => new
            {
                IdTaller = grupo.Key, // Obtener el IdTaller del grupo actual
                SumaRating = grupo.Sum(opinion => opinion.Rating ?? 0) // Sumar los ratings del grupo actual
            })
            .AsNoTracking() // Agregar AsNoTracking aquí
            .ToList();

                var promedioRatingsPorTaller = sumaRatingsPorTaller
                    .Select(resultado => new
                    {
                        IdTaller = resultado.IdTaller,
                        PromedioRating = (double)resultado.SumaRating / motored01Context.Opiniones.Count(opinion => opinion.IdTaller == resultado.IdTaller)
                    })
                    .ToList();

                var resultadosConNombres = promedioRatingsPorTaller
                    .Join(
                        motored01Context.Tallers,
                        resultado => resultado.IdTaller,
                        taller => taller.IdTaller,
                        (resultado, taller) => new TallerTop
                        {
                            IdTaller = (int)resultado.IdTaller,
                            NombreTaller = taller.NombreTaller, // Nombre del taller
                            PromedioRating = resultado.PromedioRating
                        })
                    .ToList();

                var resultadosOrdenados = resultadosConNombres
                    .OrderByDescending(resultado => resultado.PromedioRating)
                    .ToList();

                var primerosResultados = resultadosOrdenados.Take(10).ToList();

                // Guardar en la base de datos
                motored01Context.TallerTops.AddRange(resultadosOrdenados);
                await motored01Context.SaveChangesAsync();

                return Ok(primerosResultados);

              

                // Luego, puedes realizar la carga de datos de la misma manera que antes
                // ...

                
            }
        }
    }
}

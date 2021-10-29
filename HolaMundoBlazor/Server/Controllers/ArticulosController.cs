using HolaMundoBlazor.BD.Data;
using HolaMundoBlazor.BD.Data.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolaMundoBlazor.Server.Controllers
{
    [ApiController]

    [Route("api/articulos")]
    public class ArticulosController : ControllerBase
    {
        private readonly Jscontext context;

        public ArticulosController(Jscontext context)
        {
            this.context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Articulo>>> Get()
        {
            //Select * from Paises --------- SQL
            //return await context.Paises.Include(x => x.Provincias).ToListAsync();
            return await context.Articulos.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Articulo>> Get(int id)
        {
            //Select * from Paises --------- SQL
            Articulo articulo = await context.Articulos.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (articulo == null)
            {
                return NotFound($"No se encontro el Articulo con id igual a {id}");
            }
            return articulo;
        }

        [HttpPost]
        public async Task<ActionResult<Articulo>> Post(Articulo articulo)
        {

            try
            {
                context.Articulos.Add(articulo);
                await context.SaveChangesAsync();

                return articulo;
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Articulo articulo)
        {
            if (id != articulo.Id)
            {
                return BadRequest("Datos Erroneos");
            }

            var error = await context.Articulos.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (error == null)
            {
                return NotFound("No existe el articulo a modificar");
            }

            error.CodArticulo = articulo.CodArticulo;
            error.NombreArticulo = articulo.NombreArticulo;
            error.UnidadArticulo = articulo.UnidadArticulo;
            error.CantidadArticulo = articulo.CantidadArticulo;
            error.DescripcionArticulo = articulo.DescripcionArticulo;
            error.Categoria = articulo.Categoria;

            try
            {
                context.Articulos.Update(error);
                await context.SaveChangesAsync();

                return Ok("Los datos fueron cambiados.");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            //Select * from Articulos --------- SQL
            Articulo articulo = await context.Articulos.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (articulo == null)
            {
                return NotFound($"No se encontro el articulo con id igual a {id}");
            }

            try
            {
                context.Articulos.Remove(articulo);
                await context.SaveChangesAsync();

                return Ok($"El articulo {articulo.NombreArticulo} ah sido borrado.");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }


    }
}

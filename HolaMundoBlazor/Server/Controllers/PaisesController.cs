using HolaMundoBlazor.BD.Data;
using HolaMundoBlazor.BD.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolaMundoBlazor.Server.Controllers
{
    [ApiController]

    //Se puede poner "api/[controller]"
    [Route("api/paises")]
    public class PaisesController : ControllerBase
    {
        private readonly Jscontext context;

        public PaisesController(Jscontext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async  Task<ActionResult<List<Pais>>> Get()
        {
            //Select * from Paises --------- SQL
            return await context.Paises.Include(x => x.Provincias).ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pais>> Get(int id)
        {
            //Select * from Paises --------- SQL
            Pais pais =await context.Paises.Include(x => x.Provincias).Where(x => x.Id == id).FirstOrDefaultAsync();
            if (pais == null)
            {
                return NotFound($"No se encontro el pais con id igual a {id}");
            }
            return pais;
        }

        [HttpPost]
        public async Task<ActionResult<Pais>> Post(Pais pais)
        {

            try
            {
                context.Paises.Add(pais);
                await  context.SaveChangesAsync();

                return pais;
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody]Pais pais)
        {
            if (id != pais.Id)
            {
                return BadRequest("Datos Erroneos");
            }

            var error =await context.Paises.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (error == null)
            {
                return NotFound("No existe el pais a modificar");
            }

            error.CodPais = pais.CodPais;
            error.NombrePais = pais.NombrePais;

            try
            {
                context.Paises.Update(error);
                await context.SaveChangesAsync();

                return Ok("Los datos fueron cambiados.");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        [HttpDelete("{id:int}")]
        public async  Task<ActionResult> Delete(int id)
        {
            //Select * from Paises --------- SQL
            Pais pais =await context.Paises.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (pais == null)
            {
                return NotFound($"No se encontro el pais con id igual a {id}");
            }

            try
            {
                context.Paises.Remove(pais);
                await context.SaveChangesAsync();

                return Ok($"El pais {pais.NombrePais} ah sido borrado.");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
           
        }


    }
}

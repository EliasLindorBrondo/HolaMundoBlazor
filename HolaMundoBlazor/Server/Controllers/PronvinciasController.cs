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

    [Route("api/provincias")]
    public class PronvinciasController : ControllerBase
    {
        private readonly Jscontext context;

        public PronvinciasController(Jscontext context)
        {
            this.context = context;
        }

        [HttpGet]

        public ActionResult<List<Provincia>> Get()
        {
            return context.Provincias.Include(x => x.Pais).ToList();
        }

        [HttpPost]

        public ActionResult<Provincia> Post(Provincia provincia)
        {
            context.Provincias.Add(provincia);
            context.SaveChanges();

            return provincia;
        }

        [HttpGet("{id:int}")]

       public ActionResult<Provincia> Get(int id)
       {
           Provincia provincia = context.Provincias.Include(x => x.Pais).Where(x => x.Id == id).FirstOrDefault();
       
           if (provincia == null)
           {
               return NotFound($"No se encontro la pronvincia con el id igual a {id}");
           }
            return provincia;
            
            
           
       
       }

        [HttpPut("{id:int}")]

        public ActionResult Put(int id,[FromBody] Provincia provincia)
        {
            if (id != provincia.Id)
            {
                return BadRequest("Datos erroneos.");
            }

            var error = context.Provincias.Where(x => x.Id == id).FirstOrDefault();
            if (error == null)
            {
                return NotFound($"No existe provincia a modificar.");
            }

            error.CodProvincia = provincia.CodProvincia;
            error.NombreProvincia = provincia.NombreProvincia;
            error.PaisId = provincia.PaisId;

            try
            {
                context.Provincias.Update(error);
                context.SaveChanges();

                return Ok("Los datos fueron cambiados.");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")]

        public ActionResult Delete(int id)
        {
            Provincia provincia = context.Provincias.Where(x => x.Id == id).FirstOrDefault();
            if (provincia == null)
            {
                return NotFound($"No se encontro la provincia con id igual a {id}");
            }


            try
            {
                context.Provincias.Remove(provincia);
                context.SaveChanges();

                return Ok($"La provincia llamada {provincia.NombreProvincia} fue borrada.");

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            

        }


    }
}

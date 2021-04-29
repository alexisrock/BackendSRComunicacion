using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solucion.Clases;
using Solucion.Interfaces;
using Solucion.Models;

namespace Solucion.Controllers
{
    [Route("api/Correspondencia")]
    [ApiController]
    public class CorrespondenciaController : ControllerBase
    {

        [HttpGet("GetAll")]
        public IEnumerable<VwCorrespondencium> GetAll()
        {

            string cadena = HttpContext.Request.Path;
            CSCorrespondencia corresponencia = new CSCorrespondencia();
            return corresponencia.GetAll();

        }



        [HttpPost("Add")]
        public Response Add(ICorrespondencia correspondencia)
        {
            CSCorrespondencia corresponencia = new CSCorrespondencia();
           
            Log.Add(HttpContext.Request.Path);
            var respuesta = corresponencia.Add(correspondencia);
            return respuesta;
        }


        [HttpDelete("Delete/{id}")]
        public Response Delete(string id)
        {
            Log.Add(HttpContext.Request.Path);
            CSCorrespondencia corresponencia = new CSCorrespondencia();
            var respuesta = corresponencia.Delete(id);
            return respuesta;

        }


        [HttpPut("Update/{id}")]
        public Response Update(string id, ICorrespondencia correspondencia)
        {
            Log.Add(HttpContext.Request.Path);
            CSCorrespondencia corresponencia = new CSCorrespondencia();
            var respuesta = corresponencia.Update(id, correspondencia);
            return respuesta;
        }


    }
}

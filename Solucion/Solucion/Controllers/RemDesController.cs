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
    [Route("api/RemDes")]
    [ApiController]
    public class RemDesController : ControllerBase
    {

        [HttpGet("GetAll")]
        public IEnumerable<IRemDes> GetAll()
        {
            CSRemDes remdem = new CSRemDes();

            return remdem.GetAll();

        }

        [HttpPost("Add")]
        public Response AddU(IRemDes remdes)
        {
            Log.Add(HttpContext.Request.Path);
            CSRemDes remdem = new CSRemDes();
            var respuesta = remdem.Add(remdes);
            return respuesta;
        }


        [HttpDelete("Delete/{id}")]
        public Response Delete(long id)
        {
            Log.Add(HttpContext.Request.Path);
            CSRemDes remdem = new CSRemDes();
            var respuesta = remdem.Delete(id);
            return respuesta;

        }


        [HttpPut("Update/{id}")]
        public Response Update(long id, IRemDes remdes)
        {
            Log.Add(HttpContext.Request.Path);
            CSRemDes remdem = new CSRemDes();
            var respuesta = remdem.Update(id, remdes);
            return respuesta;
        }


    }
}

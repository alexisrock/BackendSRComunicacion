using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solucion.Clases;
using Solucion.Interfaces;

namespace Solucion.Controllers
{
    [Route("api/TipoRemDes")]
    [ApiController]
    public class TipoRemDesController : ControllerBase
    {


        [HttpGet("GetAll")]
        public IEnumerable<ITipoRemDes> GetAll()
        {
            CSTipoRemDes tipo = new CSTipoRemDes();

            return tipo.GetAll();

        }

        [HttpPost("Add")]
        public Response AddRol(ITipoRemDes objtipo)
        {
            CSTipoRemDes tipo = new CSTipoRemDes();
            var respuesta = tipo.Add(objtipo);
            return respuesta;
        }

        [HttpDelete("Delete/{id}")]
        public Response DeleteRol(long id)
        {
            CSTipoRemDes tipo = new CSTipoRemDes();
            var respuesta = tipo.Delete(id);
            return respuesta;

        }



    }
}

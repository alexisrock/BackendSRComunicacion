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
    [Route("api/Roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        [HttpGet("GetAll")]
        public IEnumerable<Roles> GetAll()
        {
            CSRoles roles = new CSRoles();

            return roles.GetAll();

        }

        [HttpPost("Add")]
        public Response AddRol(Roles rol) {
            CSRoles roles = new CSRoles();
            var respuesta = roles.Add(rol);
            return respuesta;
        }

        [HttpDelete("Delete/{id}")]
        public Response DeleteRol(long id) {
            CSRoles roles = new CSRoles();
            var respuesta = roles.DeleteRol(id);
            return respuesta;

        }





    }
}

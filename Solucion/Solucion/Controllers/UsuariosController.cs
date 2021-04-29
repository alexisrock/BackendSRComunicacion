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
    [Route("api/Usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {



        [HttpGet("GetAll")]
        public IEnumerable<IUsuarios> GetAll()
        {
            CSUsuario usuario = new CSUsuario();

            return usuario.GetAll();

        }


        [HttpPost("Add")]
        public Response AddUsuario(IUsuarios user)
        {
            Log.Add(HttpContext.Request.Path);
            CSUsuario usuario = new CSUsuario();
            var respuesta = usuario.Add(user);
            return respuesta;
        }


        [HttpDelete("Delete/{id}")]
        public Response Deleteusuario(long id)
        {
            Log.Add(HttpContext.Request.Path);
            CSUsuario usuario = new CSUsuario();
            var respuesta = usuario.Delete(id);
            return respuesta;

        }


        [HttpPut("Update/{id}")]
        public Response UpdateUsuario(long id, IUsuarios user)
        {
            Log.Add(HttpContext.Request.Path);
            CSUsuario usuario = new CSUsuario();
            var respuesta = usuario.Update(id, user);
            return respuesta;
        }


        [HttpPost("Login")]
        public IUsuarios AddUsuario(string user, string pass)
        {
            Log.Add(HttpContext.Request.Path);
            CSUsuario usuario = new CSUsuario();
            var respuesta = usuario.Login(user, pass);
            return respuesta;
        }





    }
}

using Solucion.Interfaces;
using Solucion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solucion.Clases
{
    public class CSRoles
    {
    private   BDComunicationContext dbcontext = new BDComunicationContext();



        public List<Roles>  GetAll() {
            var listroles =   dbcontext.Roles.ToList();
            var Roles = listroles.Select(x => new Roles
            {
                idRol = x.IdRol,
                Descripcion = x.Descripcion
            }).ToList();

            return Roles; 
        }


        public Response Add(Roles rol) {
            try
            {
                Role objrol = new Role();
          
                objrol.Descripcion = rol.Descripcion;
                dbcontext.Roles.Add(objrol);
                dbcontext.SaveChanges();

                var response = new Response
                {
                    code = 1,
                    Descripcion = "Rol Creado con exito"
                };


                return response;
            }
            catch (Exception)
            {
                var response = new Response
                {
                    code = 2,
                    Descripcion = "Error al crear el rol"
                };
                return response;

            }
        }


        public Response DeleteRol(long id) {
            try
            {

                var objrol = dbcontext.Roles.Where(x => x.IdRol == id).FirstOrDefault();

                dbcontext.Roles.Remove(objrol);
                dbcontext.SaveChanges();
                var response = new Response
                {
                    code = 1,
                    Descripcion = "Rol eliminado con exito"
                };


                return response;


            }
            catch (Exception)            {

                var response = new Response
                {
                    code = 2,
                    Descripcion = "Error al eliminar el rol"
                };
                return response;
            }
        
        }


    }
}

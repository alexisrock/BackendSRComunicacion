using Solucion.Interfaces;
using Solucion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solucion.Clases
{
    public class CSTipoRemDes
    {

        BDComunicationContext dbcontext = new BDComunicationContext();


        public List<ITipoRemDes> GetAll()
        {
            var listtiporemdes = dbcontext.TipoRemDes.ToList();
            var tiporemdesporemdes = listtiporemdes.Select(x => new ITipoRemDes
            {
                idTipoRemDes = x.IdTipoRemDes,
                Descripcion = x.Descripcion
            }).ToList();

            return tiporemdesporemdes;
        }

        public Response Add(ITipoRemDes tipo)
        {
            try
            {
                TipoRemDe objtipo = new TipoRemDe();

                objtipo.Descripcion = tipo.Descripcion;
                dbcontext.TipoRemDes.Add(objtipo);
                dbcontext.SaveChanges();

                var response = new Response
                {
                    code = 1,
                    Descripcion = "TipoRemDe Creado con exito"
                };


                return response;
            }
            catch (Exception)
            {
                var response = new Response
                {
                    code = 2,
                    Descripcion = "Error al crear el TipoRemDe"
                };
                return response;

            }
        }


        public Response Delete(long id)
        {
            try
            {

                var objtipo = dbcontext.TipoRemDes.Where(x => x.IdTipoRemDes == id).FirstOrDefault();

                dbcontext.TipoRemDes.Remove(objtipo);
                dbcontext.SaveChanges();
                var response = new Response
                {
                    code = 1,
                    Descripcion = "TipoRemDes eliminado con exito"
                };


                return response;


            }
            catch (Exception)
            {

                var response = new Response
                {
                    code = 2,
                    Descripcion = "Error al eliminar el TipoRemDes"
                };
                return response;
            }

        }



    }
}

using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Solucion.Interfaces;
using Solucion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solucion.Clases
{
    public class CSRemDes
    {
        private BDComunicationContext dbcontext = new BDComunicationContext();
        public List<IRemDes> GetAll()
        {
            var List = dbcontext.RemDes.Select(x => new IRemDes
                {
                    idremitente = x.Idremitente,
                    nombres = x.Nombres,
                    apellidos = x.Apellidos,
                    documento = x.Documento,
                    direccion = x.Direccion,
                    telefono = x.Telefono,
                    idTipoRemDes = x.IdTipoRemDes
                }).ToList();

            return List;

        }

        public Response Add(IRemDes remdem)
        {
            try
            {
         
                Log.Add("Insertar Datos");
                Log.Add(JsonConvert.SerializeObject(remdem));
                RemDe obj = new RemDe();


                obj.Nombres = remdem.nombres;
                obj.Apellidos = remdem.apellidos;
                obj.Documento = remdem.documento;
                obj.Direccion = remdem.direccion;
                obj.Telefono = remdem.telefono;
                obj.IdTipoRemDes = remdem.idTipoRemDes;
                dbcontext.RemDes.Add(obj);
                dbcontext.SaveChanges();

                Log.Add("Datos creados exitosamente");
                var response = new Response
                {
                    code = 1,
                    Descripcion = "RemitenteDEstinatario Creado con exito"
                };


                return response;
            }
            catch (Exception ex)
            {
                Log.Add("Error: "+ex);
                var response = new Response
                {
                    code = 2,
                    Descripcion = "Error al crear el RemitenteDEstinatario"
                };
                return response;

            }
        }


        public Response Delete(long id)
        {
            try
            {
                Log.Add("Eliminar id"+id);
                var obj = dbcontext.RemDes.Where(x => x.Idremitente == id).FirstOrDefault();
                dbcontext.RemDes.Remove(obj);
                dbcontext.SaveChanges();
                var response = new Response
                {
                    code = 1,
                    Descripcion = "RemitenteDEstinatario eliminado con exito"
                };

                Log.Add("Registro Eliminado ");
                return response;
            }
            catch (Exception ex)
            {

                Log.Add("Error: " + ex);
                var response = new Response
                {
                    code = 2,
                    Descripcion = "Error al eliminar el RemitenteDEstinatario"
                };
                return response;
            }

        }


        public Response Update(long id, IRemDes remdem)
        {
            try
            {

                Log.Add("Actulizar Datos");
                Log.Add(JsonConvert.SerializeObject(remdem));
                var obj = dbcontext.RemDes.Where(x => x.Idremitente == id).FirstOrDefault();
                obj.IdTipoRemDes = remdem.idTipoRemDes;
                obj.Nombres = remdem.nombres;
                obj.Documento = remdem.documento;
                obj.Apellidos = remdem.apellidos;
                obj.Direccion = remdem.direccion;
                obj.Telefono = remdem.telefono;
                dbcontext.Entry(obj).State = EntityState.Modified;
                dbcontext.SaveChanges();
                Log.Add("Datos actulizados");
                var response = new Response
                {
                    code = 1,
                    Descripcion = "RemitenteDEstinatario actualizado con exito"
                };


                return response;
            }
            catch (Exception ex)
            {

                Log.Add("Error: " + ex);
                var response = new Response
                {
                    code = 2,
                    Descripcion = "Error al crear el RemitenteDEstinatario"
                };
                return response;

            }
        }

    }
}

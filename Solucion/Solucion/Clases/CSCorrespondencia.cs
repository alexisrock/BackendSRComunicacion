using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Solucion.Interfaces;
using Solucion.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Solucion.Clases
{
    public class CSCorrespondencia
    {
        private BDComunicationContext dbcontext = new BDComunicationContext();
        private readonly IHostingEnvironment environment;

        public List<VwCorrespondencium> GetAll()
        {

        
             Log.Add("realizar consulta");

            var List = dbcontext.VwCorrespondencia.ToList();

            return List;

        }


        public Response Add(ICorrespondencia correspondencia)
        {
            try
            {
                using (var dbcon = new BDComunicationContext()){

                    Log.Add("Insertar Datos");
                    Log.Add(JsonConvert.SerializeObject(correspondencia));

                    string cadena = "spAddCorrespondencia " + correspondencia.idRemitente + ", " +
                                     correspondencia.idDestinatario + ", '" + correspondencia.rutaArchivo + "', '" +
                                     correspondencia.observacion + "', " + correspondencia.idusuariocreacion + ", " +
                                      correspondencia.tipoCorrespondencia;
                    dbcon.Database.ExecuteSqlRaw(cadena);
                }

                Log.Add("Datos ingresados correctamente");              
                var response = new Response
                {
                    code = 1,
                    Descripcion = "Correspondencia Creada con exito"
                };


                return response;
            }
            catch (Exception ex)
            {
                Log.Add("Error: " + ex.Message);
                var response = new Response
                {
                    code = 2,
                    Descripcion = "Error al crear el Correspondencia"
                };
                return response;

            }
        }


        public Response Delete(string id)
        {
            try
            {
                Log.Add("Id a eliminar: "+id);
                var obj = dbcontext.Correspondencia.Where(x => x.IdCorrespondencia == id).FirstOrDefault();
                dbcontext.Correspondencia.Remove(obj);
                dbcontext.SaveChanges();
                var response = new Response
                {
                    code = 1,
                    Descripcion = "Correspondencia eliminado con exito"
                };
                Log.Add("Id a elimados con exito ");
                return response;
            }
            catch (Exception ex)
            {
                Log.Add("Error: " + ex.Message);
                var response = new Response
                {
                    code = 2,
                    Descripcion = "Error al eliminar el Correspondencia"
                };
                return response;
            }

        }


        public Response Update(string id, ICorrespondencia correspondencia)
        {
            try
            {

                Log.Add("Actualizar Datos");
                Log.Add(JsonConvert.SerializeObject(correspondencia));

                var obj = dbcontext.Correspondencia.Where(x => x.IdCorrespondencia == id).FirstOrDefault();
                obj.IdDestinatario = correspondencia.idDestinatario;
                obj.IdRemitente = correspondencia.idRemitente;
                if(correspondencia.rutaArchivo!="") obj.RutaArchivo = correspondencia.rutaArchivo;

                obj.Observacion = correspondencia.observacion;
                obj.Idusuarioactualizacion = correspondencia.idusuarioactualizacion;
                obj.Fechaactualizacion = DateTime.Now;


                dbcontext.Entry(obj).State = EntityState.Modified;
                dbcontext.SaveChanges();
                Log.Add("Datos actualizados");
                var response = new Response
                {
                    code = 1,
                    Descripcion = "RemitenteDEstinatario actualizado con exito"
                };


                return response;
            }
            catch (Exception ex)
            {
                Log.Add("Error: " + ex.Message);
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

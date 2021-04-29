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
    public class CSUsuario
    {
        private BDComunicationContext dbcontext = new BDComunicationContext();

        public List<IUsuarios> GetAll() {

            var ListUsuarios = dbcontext.Usuarios.Select(x=> new IUsuarios { 
             idUser = x.IdUser,
             username = x.Username,
             contrasena = x.Contrasena,
             documento = x.Documento,
             idrol = x.Idrol            
            }).ToList();

            return ListUsuarios;

        }



        public Response Add(IUsuarios user)
        {
            try
            {
                Log.Add("Insertar Datos");
                Log.Add(JsonConvert.SerializeObject(user));
                Usuario obj = new Usuario();
                

                obj.Idrol = user.idrol;
                obj.Username = user.username;
                obj.Documento = user.documento;
                obj.Contrasena = CSEncrypt.Encrypt(user.contrasena);
                dbcontext.Usuarios.Add(obj);
                dbcontext.SaveChanges();

                var response = new Response
                {
                    code = 1,
                    Descripcion = "Usuario Creado con exito"
                };


                Log.Add("Datos creados exitosamente");
                return response;
            }
            catch (Exception ex)
            {
                Log.Add("Error"+ex);
                var response = new Response
                {
                    code = 2,
                    Descripcion = "Error al crear el Usuario"
                };
                return response;

            }
        }


        public Response Delete(long id)
        {
            try
            {
                Log.Add("Eliminar id" + id);
                var obj = dbcontext.Usuarios.Where(x => x.IdUser == id).FirstOrDefault();
                dbcontext.Usuarios.Remove(obj);
                dbcontext.SaveChanges();
                var response = new Response
                {
                    code = 1,
                    Descripcion = "Usuario eliminado con exito"
                };
                Log.Add("Registro Eliminado ");
                return response;
            }
            catch (Exception ex)
            {
                Log.Add("Error" + ex);
                var response = new Response
                {
                    code = 2,
                    Descripcion = "Error al eliminar el Usuario"
                };
                return response;
            }

        }


        public Response Update(long id,IUsuarios user)
        {
            try
            {
                Log.Add("Actulizar Datos");
                Log.Add(JsonConvert.SerializeObject(user));

                var obj = dbcontext.Usuarios.Where(x => x.IdUser == id).FirstOrDefault();
                obj.Idrol = user.idrol;
                obj.Username = user.username;
                obj.Documento = user.documento;
                obj.Contrasena = CSEncrypt.Encrypt(user.contrasena);
                dbcontext.Entry(obj).State = EntityState.Modified;
                dbcontext.SaveChanges();

                var response = new Response
                {
                    code = 1,
                    Descripcion = "Usuario actualizado con exito"
                };

                Log.Add("Datos actualizados");
                return response;
            }
            catch (Exception ex)
            {
                Log.Add("Error" + ex);
                var response = new Response
                {
                    code = 2,
                    Descripcion = "Error al crear el Usuario"
                };
                return response;

            }
        }



        public IUsuarios Login(string username, string password)
        {
            try
            {
                Log.Add("log  username" + username);
                var response = new IUsuarios();
                var obj = dbcontext.Usuarios.Where(x => x.Username == username).FirstOrDefault();
                if (obj != null)
                {
                    if (password.Equals(CSEncrypt.Decrypt(obj.Contrasena)))
                    {
                        response.documento = obj.Documento;
                        response.username = obj.Username;
                        response.idrol = obj.Idrol;
                        response.idUser = obj.IdUser;
                    }
                    else {
                        response.contrasena = "Error en la contraseña";
                        Log.Add("log  pass no encontrado");
                    } 
                }
                else {
                    Log.Add("log  username no encontrado" + username);
                    response = null;
                }








                return response;
            }
            catch (Exception ex)
            {
                Log.Add("Error: " + ex);
                return null;

            }
        }





    }
}

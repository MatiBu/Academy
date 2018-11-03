using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Data.Database
{
    public class ModuloUsuarioAdapter: Adapter
    {
        public List<ModuloUsuario> GetMooduleByUserId(int ID)
        {
            List<ModuloUsuario> modulosUsr = new List<ModuloUsuario>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdModuloUsuario = new SqlCommand("select * from modulos_usuarios where id_usuario = @id", sqlConn);
                cmdModuloUsuario.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drModuloUsr = cmdModuloUsuario.ExecuteReader();
                while (drModuloUsr.Read())
                {
                    ModuloUsuario moduloUsr = new ModuloUsuario();
                    moduloUsr.IdUsuario = (int)drModuloUsr["id_usuario"];
                    moduloUsr.IdModulo = (int)drModuloUsr["id_modulo"];
                    moduloUsr.PermiteAlta = (bool)drModuloUsr["alta"];
                    moduloUsr.PermiteBaja = (bool)drModuloUsr["baja"];
                    moduloUsr.PermiteModificacion = (bool)drModuloUsr["modificacion"];
                    moduloUsr.PermiteModificacion = (bool)drModuloUsr["modificacion"];
                    moduloUsr.PermiteConsulta = (bool)drModuloUsr["consulta"];

                    modulosUsr.Add(moduloUsr);
                }
                drModuloUsr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar un usuario por id", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modulosUsr;
        }
    }
}

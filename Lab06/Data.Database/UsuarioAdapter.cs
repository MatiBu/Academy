using System;
using System.Collections.Generic;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter : Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Usuario> _Usuarios;

        private static List<Usuario> Usuarios
        {
            get
            {
                if (_Usuarios == null)
                {
                    _Usuarios = new List<Business.Entities.Usuario>();
                    Business.Entities.Usuario usr;
                    usr = new Business.Entities.Usuario();
                    usr.ID = 1;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Casimiro";
                    usr.Apellido = "Cegado";
                    usr.NombreUsuario = "casicegado";
                    usr.Clave = "miro";
                    usr.EMail = "casimirocegado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 2;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Armando Esteban";
                    usr.Apellido = "Quito";
                    usr.NombreUsuario = "aequito";
                    usr.Clave = "carpintero";
                    usr.EMail = "armandoquito@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 3;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Alan";
                    usr.Apellido = "Brado";
                    usr.NombreUsuario = "alanbrado";
                    usr.Clave = "abrete sesamo";
                    usr.EMail = "alanbrado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                }
                return _Usuarios;
            }
        }
        #endregion

        public List<Usuario> GetAll(int tipo = 2)
        {
            // return new List<Usuario>(Usuarios);
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("", sqlConn);
                if (tipo == 2)
                {
                    cmdUsuarios.CommandText = "select u.id_usuario, u.nombre_usuario, u.clave, u.habilitado, p.nombre, p.apellido, p.email " +
                        "from usuarios u left join personas p on p.id_persona = u.id_persona";
                }
                else
                {
                    cmdUsuarios.CommandText = "select u.id_usuario, u.nombre_usuario, u.clave, u.habilitado, p.nombre, p.apellido, p.email " +
                        "from usuarios u left join personas p on p.id_persona = u.id_persona " +
                        "where p.tipo_persona = @tipo";
                    cmdUsuarios.Parameters.Add("@tipo", SqlDbType.Int).Value = tipo;
                }

                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (Boolean)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.EMail = (string)drUsuarios["email"];

                    usuarios.Add(usr);
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usuarios;
        }

        public Usuario GetOne(int ID)
        {
            //return Usuarios.Find(delegate (Usuario u) { return u.ID == ID; });
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();                

                SqlCommand cmdUsuario = new SqlCommand("select u.id_usuario, u.nombre_usuario, u.clave, u.habilitado, p.nombre, p.apellido, p.email from usuarios u left join personas p on p.id_persona = u.id_persona where u.id_usuario = @id", sqlConn);
                cmdUsuario.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuario.ExecuteReader();
                if (drUsuarios.Read())
                {

                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (Boolean)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.EMail = (string)drUsuarios["email"];
                }
                drUsuarios.Close();
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
            return usr;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlTransaction transaction;

                transaction = sqlConn.BeginTransaction();

                SqlCommand cmdDelete = new SqlCommand("select id_persona from usuarios where id_usuario = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.Transaction = transaction;
                try
                {
                    var id_persona = cmdDelete.ExecuteScalar();

                    cmdDelete.CommandText = "delete usuarios where id_usuario = @id";
                    cmdDelete.ExecuteNonQuery();
                    cmdDelete.Parameters.Clear();

                    cmdDelete.CommandText = "delete personas where id_persona = @id";
                    cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = id_persona;
                    cmdDelete.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
               

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar un usuario por id", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuario = new SqlCommand("UPDATE usuarios SET nombre_usuario = @nombre_usuario, clave = @clave, habilitado = @habilitado WHERE id_usuario = @id;" +
                     "SELECT id_persona FROM usuarios where id_usuario = @id", sqlConn);
                cmdUsuario.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdUsuario.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdUsuario.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdUsuario.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                var id_persona = cmdUsuario.ExecuteScalar();

                cmdUsuario.Parameters.Clear();

                cmdUsuario.CommandText = "UPDATE personas SET nombre = @nombre, apellido = @apellido, email = @email WHERE id_persona = @id_persona";
                cmdUsuario.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdUsuario.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdUsuario.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.EMail;
                cmdUsuario.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.ID;
                cmdUsuario.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de un usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSavePersona = new SqlCommand("Insert into personas (nombre, apellido, email, fecha_nac, tipo_persona, id_plan) " +
                    "values (@nombre, @apellido, @email, GETUTCDATE(), 3, 1) " +
                    "select @@identity", sqlConn);
                cmdSavePersona.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSavePersona.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSavePersona.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.EMail;
                var id_persona = Decimal.ToInt32((decimal)cmdSavePersona.ExecuteScalar());
                cmdSavePersona.Parameters.Clear();

                cmdSavePersona.CommandText = "Insert into usuarios (nombre_usuario, clave, habilitado, nombre, apellido, " +
                    "id_persona) values (@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @id_persona) " +
                    "select @@identity";
                cmdSavePersona.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSavePersona.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSavePersona.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSavePersona.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSavePersona.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSavePersona.Parameters.Add("@id_persona", SqlDbType.Int).Value = id_persona;
                usuario.ID = Decimal.ToInt32((decimal)cmdSavePersona.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de un usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Usuario usuario)
        {
            // Usuarios[Usuarios.FindIndex(delegate (Usuario u) { return u.ID == usuario.ID; })] = usuario;
            this.Update(usuario);

        }

        //public void Insert(Usuario user)
        //{
        //    this.Insert(user);
        //}

        public List<ModuloUsuario> GetModulesByUser(int ID)
        {
            List<ModuloUsuario> usuarios = new List<ModuloUsuario>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuarios = new SqlCommand("select md.id_modulo_usuario, md.alta, md.baja, md.modificacion, md.consulta, " +
                    "m.id_modulo, m.desc_modulo " +
                    "from modulos_usuarios md " +
                    "left join modulos m on m.id_modulo = md.id_modulo " +
                    "where md.id_usuario = @id", sqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                while (drUsuarios.Read())
                {
                    ModuloUsuario usr = new ModuloUsuario();
                    usr.ID = (int)drUsuarios["id_modulo_usuario"];
                    usr.IdModulo = (int)drUsuarios["id_modulo"];
                    usr.PermiteAlta = (Boolean)drUsuarios["alta"];
                    usr.PermiteBaja = (Boolean)drUsuarios["baja"];
                    usr.PermiteModificacion = (Boolean)drUsuarios["modificacion"];
                    usr.PermiteConsulta = (Boolean)drUsuarios["consulta"];
                    usr.Modulo = new Modulo();
                    usr.Modulo.ID = (int)drUsuarios["id_modulo"];
                    usr.Modulo.Descripcion = (string)drUsuarios["desc_modulo"];

                    usuarios.Add(usr);
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de modulos por usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usuarios;
        }

        public Usuario Login(Usuario usuario)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdLogin = new SqlCommand("SELECT * FROM usuarios u " +
                "LEFT JOIN personas p ON p.id_persona = u.id_persona " +
                "WHERE u.nombre_usuario = @nombre_usuario AND u.clave = @clave;", sqlConn);
                cmdLogin.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdLogin.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                SqlDataReader loginReader = cmdLogin.ExecuteReader();
                if (loginReader.Read())
                {
                    usr.ID = (int)loginReader["id_usuario"];
                    usr.NombreUsuario = (string)loginReader["nombre_usuario"];
                    usr.Habilitado = (Boolean)loginReader["habilitado"];
                    usr.EMail = (string)loginReader["email"];
                }
                loginReader.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al obtener dato del login de un usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            if (usr != null)
            {
                usr.ModulosPorUsuario = this.GetModulesByUser(usr.ID);
            }
            return usr;
        }

        public bool ValidateUnique(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdLogin = new SqlCommand("COUNT * FROM usuarios u " +
                "WHERE u.nombre_usuario = @nombre_usuario AND u.email = @email;", sqlConn);
                cmdLogin.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.EMail;
                cmdLogin.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;

                return Boolean.Parse((string)cmdLogin.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al obtener dato del login de un usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}

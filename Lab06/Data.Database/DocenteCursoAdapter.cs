using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;
using System.Data;

namespace Data.Database
{
    public class DocenteCursoAdapter : Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        //private static List<DocenteCurso> _docenteCurso;

        //private static List<DocenteCurso> DocenteCurso
        //{
        //    get
        //    {
        //        if (_docenteCurso == null)
        //        {
        //            //_docenteCurso = new List<Business.Entities.DocenteCurso>();
        //            //Business.Entities.DocenteCurso usr;
        //            //usr = new Business.Entities.DocenteCurso();
        //            //usr.IDPlanCurso = 1;
        //            //usr.State = Business.Entities.BusinessEntity.States.Unmodified;
        //            //usr.Nombre = "Casimiro";
        //            //usr.ApellIDCursoo = "Cegado";
        //            //usr.Descripcion = "casicegado";
        //            //usr.Clave = "miro";
        //            //usr.EMail = "casimirocegado@gmail.com";
        //            //usr.Habilitado = true;
        //            //_Usuarios.Add(usr);

        //            //usr = new Business.Entities.Usuario();
        //            //usr.IDPlan = 2;
        //            //usr.State = Business.Entities.BusinessEntity.States.Unmodified;
        //            //usr.Nombre = "Armando Esteban";
        //            //usr.ApellIDCursoo = "Quito";
        //            //usr.Descripcion = "aequito";
        //            //usr.Clave = "carpintero";
        //            //usr.EMail = "armandoquito@gmail.com";
        //            //usr.Habilitado = true;
        //            //_Usuarios.Add(usr);

        //            //usr = new Business.Entities.Usuario();
        //            //usr.IDPlan = 3;
        //            //usr.State = Business.Entities.BusinessEntity.States.Unmodified;
        //            //usr.Nombre = "Alan";
        //            //usr.ApellIDCursoo = "Brado";
        //            //usr.Descripcion = "alanbrado";
        //            //usr.Clave = "abrete sesamo";
        //            //usr.EMail = "alanbrado@gmail.com";
        //            //usr.Habilitado = true;
        //            //_Usuarios.Add(usr);
                    
        //        }
        //        return GetAll();
        //    }
        //}
        #endregion

        public List<DocenteCurso> GetAll()
        {
            // return new List<Usuario>(Usuarios);
            List<DocenteCurso> docenteCursos = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocenteCurso = new SqlCommand("select * from docentes_cursos", sqlConn);
                SqlDataReader drDocenteCursos = cmdDocenteCurso.ExecuteReader();
                while (drDocenteCursos.Read())
                {
                    DocenteCurso usr = new DocenteCurso();
                    usr.Dictado = (int)drDocenteCursos["id_dictado"];
                    usr.IDCurso = (int)drDocenteCursos["id_curso"];
                    usr.IDDocente = (int)drDocenteCursos["id_docente"];
                    usr.Cargo = (int)drDocenteCursos["cargo"];

                    docenteCursos.Add(usr);
                }
                drDocenteCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return docenteCursos;
        }


        public Business.Entities.DocenteCurso GetOne(int idDictado)
        {
            //return Usuarios.Find(delegate (Usuario u) { return u.IDCurso == IDCurso; });
            DocenteCurso docente = new DocenteCurso();
            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuario = new SqlCommand("select * from docentes_cursos where id_dictado = @idDictado", sqlConn);
                cmdUsuario.Parameters.Add("@id_dictado", SqlDbType.Int).Value = idDictado;
                SqlDataReader drDocenteCurso = cmdUsuario.ExecuteReader();
                if (drDocenteCurso.Read())
                {
                    docente.Dictado = (int)drDocenteCurso["id_dictado"];
                    docente.IDCurso = (int)drDocenteCurso["id_curso"];
                    docente.IDDocente = (int)drDocenteCurso["id_docente"];
                    docente.Cargo = (int)drDocenteCurso["cargo"];
                }
                drDocenteCurso.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar un docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return docente;
        }

        public void Delete(int idDictado)
        {            
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete docentes_cursos where id_dictado = @idDictado", sqlConn);
                cmdDelete.Parameters.Add("@idDictado", SqlDbType.Int).Value = idDictado;
                cmdDelete.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar un docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(DocenteCurso docenteCurso)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDocenteCurso = new SqlCommand("UPDATE docentes_cursos SET id_dictado = @Dictado, id_curso = @IDCurso, id_docente = @IDDocente, " +
                    "anio_especialidad = @cargo", sqlConn);
                cmdDocenteCurso.Parameters.Add("@id_dictado", SqlDbType.Int).Value = docenteCurso.Dictado;
                cmdDocenteCurso.Parameters.Add("@id_curso", SqlDbType.VarChar, 50).Value = docenteCurso.IDCurso;
                cmdDocenteCurso.Parameters.Add("@id_docente", SqlDbType.VarChar, 50).Value = docenteCurso.IDDocente;
                cmdDocenteCurso.Parameters.Add("@cargo", SqlDbType.Bit).Value = docenteCurso.Cargo;
                cmdDocenteCurso.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de un docente", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(DocenteCurso docenteCurso)
        {
            try
            {
                this.OpenConnection();

                //docentes_cursos SET id_dictado = @Dictado, id_curso = @IDCurso, id_docente = @IDDocente, " +
                //    "anio_especialidad = @anio_especialidad"

                SqlCommand cmdSave = new SqlCommand("Insert into docentes_cursos (id_dictado, id_curso, id_docente, " +
                    "cargo) values (@Dictado, @IDCurso, @IDDocente, @cargo", sqlConn);

                cmdSave.Parameters.Add("@Dictado", SqlDbType.VarChar, 50).Value = docenteCurso.Dictado;
                cmdSave.Parameters.Add("@IDCurso", SqlDbType.VarChar, 50).Value = docenteCurso.IDCurso;                
                cmdSave.Parameters.Add("@IDDocente", SqlDbType.VarChar, 50).Value = docenteCurso.IDDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.VarChar, 50).Value = docenteCurso.Cargo;
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

        public void Save(DocenteCurso docenteCurso)
        {
            if (docenteCurso.State == BusinessEntity.States.New)
            {
                // int NextIDCurso = 0;
                // foreach (Usuario usr in Usuarios)
                // {
                //  if (usr.IDPlan > NextIDCurso)
                // {
                //  NextIDCurso = usr.IDPlan;
                // }
                // }
                // usuario.IDCurso = NextIDCurso + 1;
                // Usuarios.Add(usuario);
                this.Insert(docenteCurso);
            }
            else if (docenteCurso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(docenteCurso.IDCurso);
            }
            else if (docenteCurso.State == BusinessEntity.States.Modified)
            {
                // Usuarios[Usuarios.FindIndex(delegate (Usuario u) { return u.IDCurso == usuario.IDCurso; })] = usuario;
                this.Update(docenteCurso);
            }
            docenteCurso.State = BusinessEntity.States.Unmodified;
        }
    }
}

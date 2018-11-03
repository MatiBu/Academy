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
    public class AlumnoInscripcionesAdapter : Adapter
    {
        //Se le va a enviar un parametro para filtrar por Inscripcion
        public List<AlumnoInscripciones> GetAll()
        {
            // return new List<Usuario>(Usuarios);
            List<AlumnoInscripciones> alumnoInscripciones = new List<AlumnoInscripciones>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnoInscripciones = new SqlCommand("select * from alumnos_inscripciones", sqlConn);
                SqlDataReader drAlumnoInscripciones = cmdAlumnoInscripciones.ExecuteReader();
                while (drAlumnoInscripciones.Read())
                {
                    AlumnoInscripciones usr = new AlumnoInscripciones();
                    usr.ID = (int)drAlumnoInscripciones["id_inscripcion"];
                    usr.Condicion = (string)drAlumnoInscripciones["condicion"];
                    usr.IDAlumno = (int)drAlumnoInscripciones["id_alumno"];
                    usr.IDCurso = (int)drAlumnoInscripciones["id_curso"];
                    usr.Nota = (int)drAlumnoInscripciones["nota"];

                    alumnoInscripciones.Add(usr);
                }
                this.CloseConnection();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de Inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return alumnoInscripciones;
        }


        public Business.Entities.AlumnoInscripciones GetOne(int idInscripcion)
        {

            AlumnoInscripciones usr = new AlumnoInscripciones();
            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuario = new SqlCommand("select * from alumnos_inscripciones where id_inscripcion = @idInscripcion", sqlConn);
                cmdUsuario.Parameters.Add("@idInscripcion", SqlDbType.Int).Value = idInscripcion;
                SqlDataReader drAlumnoInscripciones = cmdUsuario.ExecuteReader();
                if (drAlumnoInscripciones.Read())   
                {                    
                    usr.ID = (int)drAlumnoInscripciones["id_inscripcion"];
                    usr.Condicion = (string)drAlumnoInscripciones["condicion"];
                    usr.IDAlumno = (int)drAlumnoInscripciones["id_alumno"];
                    usr.IDCurso = (int)drAlumnoInscripciones["id_curso"];
                    usr.Nota = (int)drAlumnoInscripciones["nota"];
                }
                this.CloseConnection();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la Inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }

        public void Delete(int idInscripcion)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete alumnos_inscripciones where id_inscripcion = @idInscripcion", sqlConn);
                cmdDelete.Parameters.Add("@idInscripcion", SqlDbType.Int).Value = idInscripcion;
                cmdDelete.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar una comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Comision Comision)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdComision = new SqlCommand("UPDATE alumnos_inscripciones SET id_inscripcion = @id_inscripcion, condicion = @condicion, id_alumno = @id_alumno, " +
                    "id_curso = @id_curso, nota = @nota", sqlConn);
                cmdComision.Parameters.Add("@id_inscripcion", SqlDbType.Int).Value = Comision.ID;
                cmdComision.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = Comision.IDPlan;
                cmdComision.Parameters.Add("@id_alumno", SqlDbType.Int).Value = Comision.Descripcion;
                cmdComision.Parameters.Add("@id_curso", SqlDbType.Int).Value = Comision.AnioEspecialidad;
                cmdComision.Parameters.Add("@nota", SqlDbType.Int).Value = Comision.AnioEspecialidad;
                cmdComision.ExecuteNonQuery();               

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de un la Inscripcion del alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(AlumnoInscripciones Comision)
        {
            try
            {
                this.OpenConnection();
                
                SqlCommand cmdSave = new SqlCommand("Insert into comisiones (id_inscripcion, condicion, id_alumno, " +
                    "id_curso, nota) values (@id_inscripcion, @condicion, @id_alumno, @id_curso, @nota", sqlConn);

                cmdSave.Parameters.Add("@id_inscripcion", SqlDbType.Int).Value = Comision.ID;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = Comision.Condicion;
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = Comision.IDAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = Comision.IDCurso;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = Comision.Nota;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al Insertar la inscrion del alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(AlumnoInscripciones alumnoInscripciones)
        {
            if (alumnoInscripciones.State == BusinessEntity.States.New)
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
                this.Insert(alumnoInscripciones);
            }
            else if (alumnoInscripciones.State == BusinessEntity.States.Deleted)
            {
                this.Delete(alumnoInscripciones.ID);
            }
            else if (alumnoInscripciones.State == BusinessEntity.States.Modified)
            {
                // Usuarios[Usuarios.FindIndex(delegate (Usuario u) { return u.IDCurso == usuario.IDCurso; })] = usuario;
                this.Update(alumnoInscripciones);
            }
            alumnoInscripciones.State = BusinessEntity.States.Unmodified;
        }

        private void Update(AlumnoInscripciones alumnoInscripciones)
        {
            throw new NotImplementedException();
        }
    }
}

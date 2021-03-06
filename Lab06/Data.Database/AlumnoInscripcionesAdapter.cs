﻿using System;
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
                drAlumnoInscripciones.Close();
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

        public List<AlumnoInscripciones> BuscarAlumnos(int carrera, int materia, string comision)
        {
            List<AlumnoInscripciones> alumnoInscripciones = new List<AlumnoInscripciones>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnoInscripciones = new SqlCommand("select * from alumnos_inscripciones ai " +
                    "left join cursos c on c.id_curso = ai.id_curso " +
                    "left join comisiones co on co.id_comision = c.id_comision " +
                    "left join materias m on m.id_materia = c.id_materia " +
                    "left join personas p on p.id_persona = ai.id_alumno " +
                    "where c.id_materia = @idMateria and co.desc_comision = @comision", sqlConn);
                cmdAlumnoInscripciones.Parameters.Add("@idCarrera", SqlDbType.Int).Value = carrera;
                cmdAlumnoInscripciones.Parameters.Add("@idMateria", SqlDbType.Int).Value = materia;
                cmdAlumnoInscripciones.Parameters.Add("@comision", SqlDbType.VarChar).Value = comision;
                SqlDataReader drAlumnoInscripciones = cmdAlumnoInscripciones.ExecuteReader();
                while (drAlumnoInscripciones.Read())
                {
                    AlumnoInscripciones usr = new AlumnoInscripciones();
                    usr.ID = (int)drAlumnoInscripciones["id_inscripcion"];
                    usr.Condicion = (string)drAlumnoInscripciones["condicion"];
                    usr.IDAlumno = (int)drAlumnoInscripciones["id_alumno"];
                    usr.IDCurso = (int)drAlumnoInscripciones["id_curso"];
                    usr.Nota = (int)drAlumnoInscripciones["nota"];
                    usr.Curso = new Curso();
                    usr.Curso.Materia = new Materia();
                    usr.Curso.ID = (int)drAlumnoInscripciones["id_curso"];
                    usr.Curso.IDComision = (int)drAlumnoInscripciones["id_comision"];
                    usr.Curso.Materia.ID = (int)drAlumnoInscripciones["id_materia"];
                    usr.Curso.Materia.Descripcion = (string)drAlumnoInscripciones["desc_materia"];
                    usr.Alumno = new Alumno();
                    usr.Alumno.Apellido = (string)drAlumnoInscripciones["apellido"];
                    usr.Alumno.Nombre = (string)drAlumnoInscripciones["nombre"];
                    alumnoInscripciones.Add(usr);
                }
                drAlumnoInscripciones.Close();
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


        public List<AlumnoInscripciones> GetOneByAlumno(int idAlumno)
        {

            List<AlumnoInscripciones> alumnoInscripciones = new List<AlumnoInscripciones>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuario = new SqlCommand("select * from alumnos_inscripciones ai " +
                    "LEFT JOIN cursos c on c.id_curso = ai.id_curso " +
                    "LEFT JOIN materias m on m.id_materia = c.id_materia " +
                    "where ai.id_alumno = @idAlumno", sqlConn);
                cmdUsuario.Parameters.Add("@idAlumno", SqlDbType.Int).Value = idAlumno;
                SqlDataReader drAlumnoInscripciones = cmdUsuario.ExecuteReader();
                while (drAlumnoInscripciones.Read())
                {
                    AlumnoInscripciones usr = new AlumnoInscripciones();
                    usr.ID = (int)drAlumnoInscripciones["id_inscripcion"];
                    usr.Condicion = (string)drAlumnoInscripciones["condicion"];
                    usr.IDAlumno = (int)drAlumnoInscripciones["id_alumno"];
                    usr.IDCurso = (int)drAlumnoInscripciones["id_curso"];
                    usr.Nota = (int)drAlumnoInscripciones["nota"];
                    usr.Curso = new Curso();
                    usr.Curso.IDMateria = (int)drAlumnoInscripciones["id_materia"];
                    usr.Curso.Materia = new Materia();
                    usr.Curso.Materia.Descripcion = (string)drAlumnoInscripciones["desc_materia"];

                    alumnoInscripciones.Add(usr);
                }
                drAlumnoInscripciones.Close();
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
            return alumnoInscripciones;
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

        public void SaveAll(List<AlumnoInscripciones> alumnosInscripciones)
        {
            foreach (AlumnoInscripciones alumnoInscripciones in alumnosInscripciones)
            {
                try
                {
                    this.OpenConnection();

                    SqlCommand cmdComision = new SqlCommand("UPDATE alumnos_inscripciones SET condicion = @condicion, nota = @nota " +
                        "where id_inscripcion = @id_inscripcion", sqlConn);
                    cmdComision.Parameters.Add("@id_inscripcion", SqlDbType.Int).Value = alumnoInscripciones.ID;
                    cmdComision.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = alumnoInscripciones.Condicion;
                    cmdComision.Parameters.Add("@nota", SqlDbType.Int).Value = alumnoInscripciones.Nota;
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

        }

        private void Update(AlumnoInscripciones alumnoInscripciones)
        {
            throw new NotImplementedException();
        }
    }
}

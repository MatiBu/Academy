using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Business.Entities;
using static Business.Entities.Persona;

namespace Data.Database
{
    public class AlumnoAdapter : Adapter
    {
        public List<Alumno> GetAll()
        {
            List<Alumno> alumnos = new List<Alumno>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnos = new SqlCommand("select p.id_persona, p.legajo, p.nombre, p.apellido, p.email, " +
                    "p.direccion, p.telefono, p.fecha_nac, p.id_plan " +
                    "from personas p where p.tipo_persona = @tipo_alumno", sqlConn);
                cmdAlumnos.Parameters.Add("@tipo_alumno", SqlDbType.Int).Value = (int)TipoPersonas.Alumno;
                SqlDataReader drAlumnos = cmdAlumnos.ExecuteReader();
                while (drAlumnos.Read())
                {
                    Alumno alum = new Alumno();
                    alum.ID = (int)drAlumnos["id_persona"];
                    alum.Legajo = (int)drAlumnos["legajo"];
                    alum.Nombre = (string)drAlumnos["nombre"];
                    alum.Apellido = (string)drAlumnos["apellido"];
                    alum.EMail = (string)drAlumnos["email"];
                    alum.Direccion = (string)drAlumnos["direccion"];
                    alum.Telefono = (string)drAlumnos["telefono"];
                    alum.FechaNacimiento = (DateTime)drAlumnos["fecha_nac"];
                    alum.IDPlan = (int)drAlumnos["id_plan"];

                    alumnos.Add(alum);
                }
                drAlumnos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de alumnos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return alumnos;
        }

        public Alumno GetOne(int ID)
        {
            Alumno alum = new Alumno();
            try
            {
                this.OpenConnection();

                SqlCommand cmdAlumno = new SqlCommand("select * from personas p " +
                    "LEFT JOIN planes pl on pl.id_plan = p.id_plan where p.id_persona = @id", sqlConn);
                cmdAlumno.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drAlumnos = cmdAlumno.ExecuteReader();
                if (drAlumnos.Read())
                {
                    alum.ID = (int)drAlumnos["id_persona"];
                    alum.Legajo = (int)drAlumnos["legajo"];
                    alum.Nombre = (string)drAlumnos["nombre"];
                    alum.Apellido = (string)drAlumnos["apellido"];
                    alum.EMail = (string)drAlumnos["email"];
                    alum.Direccion = (string)drAlumnos["direccion"];
                    alum.Telefono = (string)drAlumnos["telefono"];
                    alum.FechaNacimiento = (DateTime)drAlumnos["fecha_nac"];
                    alum.IDPlan = (int)drAlumnos["id_plan"];
                    alum.Plan = new Plan();
                    alum.Plan.ID = (int)drAlumnos["id_plan"];
                    alum.Plan.Descripcion = (string)drAlumnos["desc_plan"];
                    alum.Plan.IDEspecialidad = (int)drAlumnos["id_especialidad"];
                    alum.IDEspecialidad = (int)drAlumnos["id_especialidad"];
                }
                drAlumnos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar un alumno por id", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return alum;
        }

        public List<Alumno> GetByApellido(string apellido)
        {
            List<Alumno> alumnos = new List<Alumno>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdAlumno = new SqlCommand("select * from personas p " +
                    "LEFT JOIN planes pl on pl.id_plan = p.id_plan "+
                    "where p.apellido like '%'+@apellido+'%'", sqlConn);
                cmdAlumno.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = apellido;
                SqlDataReader drAlumnos = cmdAlumno.ExecuteReader();
                while (drAlumnos.Read())
                {
                    Alumno alum = new Alumno();
                    alum.ID = (int)drAlumnos["id_persona"];
                    alum.Legajo = (int)drAlumnos["legajo"];
                    alum.Nombre = (string)drAlumnos["nombre"];
                    alum.Apellido = (string)drAlumnos["apellido"];
                    alum.Plan = new Plan();
                    alum.Plan.ID = (int)drAlumnos["id_plan"];
                    alum.Plan.Descripcion = (string)drAlumnos["desc_plan"];

                    alumnos.Add(alum);
                }
                drAlumnos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar un alumno por id", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return alumnos;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete personas where id_persona = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar un alumno por id", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Alumno alumno)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdAlumno = new SqlCommand("UPDATE personas SET legajo = @legajo, nombre = @nombre, apellido = @apellido, email = @email, " +
                    "direccion = @direccion, telefono = @telefono, fecha_nac = @fecha_nac, id_plan = @id_plan WHERE id_persona = @id", sqlConn);
                cmdAlumno.Parameters.Add("@id", SqlDbType.Int).Value = alumno.ID;
                cmdAlumno.Parameters.Add("@legajo", SqlDbType.Int).Value = alumno.Legajo;
                cmdAlumno.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = alumno.Nombre;
                cmdAlumno.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = alumno.Apellido;
                cmdAlumno.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = alumno.EMail;
                cmdAlumno.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = alumno.Direccion;
                cmdAlumno.Parameters.Add("@telefono", SqlDbType.Int, 50).Value = alumno.Telefono;
                cmdAlumno.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = alumno.FechaNacimiento;
                cmdAlumno.Parameters.Add("@id_plan", SqlDbType.Int, 50).Value = alumno.IDPlan;
                cmdAlumno.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de un alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Alumno alumno)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("Insert into personas (nombre, apellido, direccion, " +
                    "email, telefono, fecha_nac, legajo, tipo_persona, id_plan) values (@nombre, @apellido, @direccion, " +
                    "@email, @telefono, @fecha_nac, @legajo, @tipo_alumno, @id_plan) " +
                    "select @@identity", sqlConn);
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = alumno.Legajo;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = alumno.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = alumno.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = alumno.EMail;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = alumno.Direccion;
                cmdSave.Parameters.Add("@telefono", SqlDbType.Int, 50).Value = alumno.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = alumno.FechaNacimiento;
                cmdSave.Parameters.Add("@tipo_alumno", SqlDbType.Int).Value = (int)TipoPersonas.Alumno;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int, 50).Value = alumno.IDPlan;
                alumno.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de un alumno", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Alumno alumno)
        {
            if (alumno.State == BusinessEntity.States.New)
            {
                this.Insert(alumno);
            }
            else if (alumno.State == BusinessEntity.States.Deleted)
            {
                this.Delete(alumno.ID);
            }
            else if (alumno.State == BusinessEntity.States.Modified)
            {
                this.Update(alumno);
            }
            alumno.State = BusinessEntity.States.Unmodified;
        }
    }
}

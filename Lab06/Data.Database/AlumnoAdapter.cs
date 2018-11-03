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
    public class AlumnoAdapter : Adapter
    {

        public List<Alumno> GetAll()
        {
            // return new List<Alumno>(Alumnos);
            List<Alumno> alumnos = new List<Alumno>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnos = new SqlCommand("select * from personas where tipo_persona = 3", sqlConn);
                SqlDataReader drAlumnos = cmdAlumnos.ExecuteReader();
                while (drAlumnos.Read())
                {
                    Alumno alum = new Alumno();
                    alum.ID = (int)drAlumnos["id_persona"];
                    alum.Legajo = (int)drAlumnos["legajo"];
                    alum.Clave = (string)drAlumnos["clave"];
                    alum.Habilitado = (Boolean)drAlumnos["habilitado"];
                    alum.Nombre = (string)drAlumnos["nombre"];
                    alum.Apellido = (string)drAlumnos["apellido"];
                    alum.EMail = (string)drAlumnos["email"];
                    alum.Direccion = (string)drAlumnos["direccion"];
                    alum.Telefono = (string)drAlumnos["telefono"];
                    alum.NombreUsuario = (string)drAlumnos["nombre_usuario"];
                    alum.FechaNacimiento  = (DateTime)drAlumnos["fecha_nac"];
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

                SqlCommand cmdAlumno = new SqlCommand("select * from personas where id_persona = @id", sqlConn);
                cmdAlumno.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drAlumnos = cmdAlumno.ExecuteReader();
                if (drAlumnos.Read())
                {
                    alum.ID = (int)drAlumnos["id_persona"];
                    alum.NombreUsuario = (string)drAlumnos["nombre_usuario"];
                    alum.Clave = (string)drAlumnos["clave"];
                    alum.Habilitado = (Boolean)drAlumnos["habilitado"];
                    alum.Nombre = (string)drAlumnos["nombre"];
                    alum.Apellido = (string)drAlumnos["apellido"];
                    alum.EMail = (string)drAlumnos["email"];
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

                SqlCommand cmdAlumno = new SqlCommand("UPDATE personas SET nombre_usuario = @nombre_usuario, clave = @clave, habilitado = @habilitado, " +
                    "nombre = @nombre, apellido = @apellido, email = @email, direccion = @direccion, telefono = @telefono, fecha_nac = @fecha_nac, id_plan = @id_plan WHERE id_alumno = @id", sqlConn);
                cmdAlumno.Parameters.Add("@id", SqlDbType.Int).Value = alumno.ID;
                cmdAlumno.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = alumno.NombreUsuario;
                cmdAlumno.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = alumno.Clave;
                cmdAlumno.Parameters.Add("@habilitado", SqlDbType.Bit).Value = alumno.Habilitado;
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

                SqlCommand cmdSave = new SqlCommand("Insert into personas (nombre_alumno, clave, habilitado, " +
                    "nombre, apellido, email) values (@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @email, @direccion, @telefono, @fecha_nac, @id_plan) " +
                    "select @@identity", sqlConn);
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = alumno.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = alumno.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = alumno.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = alumno.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = alumno.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = alumno.EMail;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = alumno.Direccion;
                cmdSave.Parameters.Add("@telefono", SqlDbType.Int, 50).Value = alumno.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = alumno.FechaNacimiento;
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
                // int NextID = 0;
                // foreach (Alumno alum in Alumnos)
                // {
                //  if (alum.ID > NextID)
                // {
                //  NextID = alum.ID;
                // }
                // }
                // alumno.ID = NextID + 1;
                // Alumnos.Add(alumno);
                this.Insert(alumno);
            }
            else if (alumno.State == BusinessEntity.States.Deleted)
            {
                this.Delete(alumno.ID);
            }
            else if (alumno.State == BusinessEntity.States.Modified)
            {
                // Alumnos[Alumnos.FindIndex(delegate (Alumno u) { return u.ID == alumno.ID; })] = alumno;
                this.Update(alumno);
            }
            alumno.State = BusinessEntity.States.Unmodified;
        }
    }
}

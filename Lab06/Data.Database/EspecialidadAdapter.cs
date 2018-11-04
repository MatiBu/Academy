using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public class EspecialidadAdapter: Adapter
    {

        public List<Especialidad> GetAll()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdespecialidades = new SqlCommand("select * from especialidades", sqlConn);
                SqlDataReader drEspecialidades = cmdespecialidades.ExecuteReader();
                while (drEspecialidades.Read())
                {
                    Especialidad especialidad = new Especialidad();
                    especialidad.ID = (int)drEspecialidades["id_especialidad"];
                    especialidad.Descripcion = (string)drEspecialidades["desc_especialidad"];

                    especialidades.Add(especialidad);
                }
                drEspecialidades.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de especialidades", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return especialidades;
        }


        public Business.Entities.Especialidad GetOne(int idEspecialidad)
        {
            Especialidad especialidad = new Especialidad();
            try
            {
                this.OpenConnection();

                SqlCommand cmdEspecialidad = new SqlCommand("select * from especialidades where id_especialidad = @idEspecialidad", sqlConn);
                cmdEspecialidad.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = idEspecialidad;
                SqlDataReader drEspecialidad = cmdEspecialidad.ExecuteReader();
                if (drEspecialidad.Read())
                {

                    especialidad.ID = (int)drEspecialidad["id_especialidad"];
                    especialidad.Descripcion = (string)drEspecialidad["desc_especialidad"];
                }
                drEspecialidad.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar el Especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return especialidad;
        }

        public void Delete(int idEspecialidad)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete especialidades where id_especialidad = @idEspecialidad", sqlConn);
                cmdDelete.Parameters.Add("@idEspecialidad", SqlDbType.Int).Value = idEspecialidad;
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

        protected void Update(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdEspecialidad = new SqlCommand("UPDATE especialidades SET id_especialidad = @ID, desc_especialidad = @desc, id_especialidad = @idEsp, ", sqlConn);
                cmdEspecialidad.Parameters.Add("@ID", SqlDbType.Int).Value = especialidad.ID;
                cmdEspecialidad.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = especialidad.Descripcion;
                cmdEspecialidad.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de un especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("Insert into especialidades (id_especialidad, desc_especialidad, id_especialidad)" +
                    " values (@ID, @desc, @idEsp", sqlConn);

                cmdSave.Parameters.Add("@ID", SqlDbType.VarChar, 50).Value = especialidad.ID;
                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = especialidad.Descripcion;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de un especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Especialidad especialidad)
        {
            if (especialidad.State == BusinessEntity.States.New)
            {
                this.Insert(especialidad);
            }
            else if (especialidad.State == BusinessEntity.States.Deleted)
            {
                this.Delete(especialidad.ID);
            }
            else if (especialidad.State == BusinessEntity.States.Modified)
            {
                this.Update(especialidad);
            }
            especialidad.State = BusinessEntity.States.Unmodified;
        }
    }
}

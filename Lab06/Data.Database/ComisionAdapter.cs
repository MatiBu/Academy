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
    public class ComisionAdapter : Adapter
    {
        public List<Comision> GetAll()
        {
            // return new List<Usuario>(Usuarios);
            List<Comision> Comisions = new List<Comision>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdComision = new SqlCommand("select * from comisiones", sqlConn);
                SqlDataReader drComisions = cmdComision.ExecuteReader();
                while (drComisions.Read())
                {
                    Comision usr = new Comision();
                    usr.ID = (int)drComisions["id_comision"];
                    usr.IDPlan = (int)drComisions["id_plan"];
                    usr.Descripcion = (string)drComisions["desc_comision"];
                    usr.AnioEspecialidad = (int)drComisions["anio_especialidad"];                    

                    Comisions.Add(usr);
                }
                drComisions.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return Comisions;
        }


        public Comision GetOne(int idComision)
        {
            
            Comision comision = new Comision();
            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuario = new SqlCommand("select * from comisiones c " +
                    "left join planes p on p.id_plan = c.id_plan " +
                    "left join especialidades e on e.id_especialidad = p.id_especialidad " +
                    "where c.id_comision = @idComision", sqlConn);
                cmdUsuario.Parameters.Add("@idComision", SqlDbType.Int).Value = idComision;
                SqlDataReader drComision = cmdUsuario.ExecuteReader();
                if (drComision.Read())
                {
                    comision.ID = (int)drComision["id_comision"];
                    comision.IDPlan = (int)drComision["id_plan"];
                    comision.Descripcion = (string)drComision["desc_comision"];
                    comision.AnioEspecialidad = (int)drComision["anio_especialidad"];
                    comision.Plan = new Plan();
                    comision.Plan.Descripcion = (string)drComision["desc_plan"];
                    comision.Plan.ID = (int)drComision["id_plan"];
                    comision.Plan.IDEspecialidad = (int)drComision["id_especialidad"];
                    comision.Plan.Especialidad = new Especialidad();
                    comision.Plan.Especialidad.ID = (int)drComision["id_especialidad"]; ;
                    comision.Plan.Especialidad.Descripcion = (string)drComision["desc_especialidad"];
                }
                drComision.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar una comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return comision;
        }

        public List<Comision> GetByDescription(string desc)
        {
            List<Comision> Comisions = new List<Comision>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdComision = new SqlCommand("select * from comisiones c " +
                    "left join planes p on p.id_plan = c.id_plan " +
                    "left join especialidades e on e.id_especialidad = p.id_especialidad " +
                    "where c.desc_comision like '%'+@desc+'%'", sqlConn);
                cmdComision.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = desc;
                SqlDataReader drComisions = cmdComision.ExecuteReader();
                while (drComisions.Read())
                {
                    Comision usr = new Comision();
                    usr.ID = (int)drComisions["id_comision"];
                    usr.IDPlan = (int)drComisions["id_plan"];
                    usr.Descripcion = (string)drComisions["desc_comision"];
                    usr.AnioEspecialidad = (int)drComisions["anio_especialidad"];
                    usr.Plan = new Plan();
                    usr.Plan.Descripcion = (string)drComisions["desc_plan"];
                    usr.Plan.ID = (int)drComisions["id_plan"];
                    usr.Plan.IDEspecialidad = (int)drComisions["id_especialidad"];
                    usr.Plan.Especialidad = new Especialidad();
                    usr.Plan.Especialidad.ID = (int)drComisions["id_especialidad"]; ;
                    usr.Plan.Especialidad.Descripcion = (string)drComisions["desc_especialidad"];
                    Comisions.Add(usr);
                }
                drComisions.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return Comisions;
        }

        public void Delete(int idComision)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete comisiones where id_comision = @idComision", sqlConn);
                cmdDelete.Parameters.Add("@idComision", SqlDbType.Int).Value = idComision;
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
                OpenConnection();

                SqlCommand cmdComision = new SqlCommand("UPDATE comisiones SET id_plan = @id_plan, desc_comision = @desc_comision, " +
                    "anio_especialidad = @anio_especialidad where id_comision = @id_comision", sqlConn);
                cmdComision.Parameters.Add("@id_comision", SqlDbType.Int).Value = Comision.ID;
                cmdComision.Parameters.Add("@id_plan", SqlDbType.Int).Value = Comision.IDPlan;
                cmdComision.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = Comision.Descripcion;
                cmdComision.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = Comision.AnioEspecialidad;
                cmdComision.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de una comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Comision Comision)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("Insert into comisiones (id_plan, desc_comision, " +
                    "anio_especialidad) values (@IdPlan, @descripcion, @anioEspecialidad", sqlConn);

                cmdSave.Parameters.Add("@IdPlan", SqlDbType.Int).Value = Comision.IDPlan;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = Comision.Descripcion;
                cmdSave.Parameters.Add("@anioEspecialidad", SqlDbType.Int).Value = Comision.AnioEspecialidad;
                cmdSave.ExecuteNonQuery();

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

        public void Save(Comision Comision)
        {
            if (Comision.State == BusinessEntity.States.New)
            {
                Insert(Comision);
            }
            else if (Comision.State == BusinessEntity.States.Deleted)
            {
                Delete(Comision.ID);
            }
            else if (Comision.State == BusinessEntity.States.Modified)
            {
                Update(Comision);
            }
            Comision.State = BusinessEntity.States.Unmodified;
        }
    }
}

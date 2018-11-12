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
    public class PlanAdapter : Adapter
    {
        public List<Plan> GetAll()
        {
            // return new List<Usuario>(Usuarios);
            List<Plan> planes = new List<Plan>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdplanes = new SqlCommand("select p.*, e.* from planes p " +
                    "left join especialidades e " +
                    "on p.id_especialidad = e.id_especialidad ", sqlConn);
                SqlDataReader drPlanes = cmdplanes.ExecuteReader();
                while (drPlanes.Read())
                {
                    Plan plan = new Plan();
                    plan.ID = (int)drPlanes["id_plan"];
                    plan.Descripcion = (string)drPlanes["desc_plan"];
                    plan.IDEspecialidad = (int)drPlanes["id_especialidad"];
                    plan.Especialidad = new Especialidad();
                    plan.Especialidad.Descripcion = (string)drPlanes["desc_especialidad"];

                    planes.Add(plan);
                }
                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de planes", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return planes;
        }


        public Business.Entities.Plan GetOne(int idPlan)
        {
            //return Usuarios.Find(delegate (Usuario u) { return u.IDCurso == IDCurso; });
            Plan plan = new Plan();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPlan = new SqlCommand("select * from planes where id_plan = @id", sqlConn);
                cmdPlan.Parameters.Add("@id", SqlDbType.Int).Value = idPlan;
                SqlDataReader drPlan = cmdPlan.ExecuteReader();
                if (drPlan.Read())                {

                    plan.ID = (int)drPlan["id_plan"];
                    plan.IDEspecialidad = (int)drPlan["id_especialidad"];
                    plan.Descripcion = (string)drPlan["desc_plan"];
                }
                drPlan.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar el Plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return plan;
        }

        public void Delete(int idPlan)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete planes where id_plan = @idPlan", sqlConn);
                cmdDelete.Parameters.Add("@idPlan", SqlDbType.Int).Value = idPlan;
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

        protected void Update(Plan plan)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdPlan = new SqlCommand("UPDATE planes SET desc_plan = @desc, id_especialidad = @idEsp " + "" +
                    "where id_plan = @ID", sqlConn);
                cmdPlan.Parameters.Add("@ID", SqlDbType.Int).Value = plan.ID;
                cmdPlan.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdPlan.Parameters.Add("@idEsp", SqlDbType.Int, 50).Value = plan.Especialidad.ID;
                cmdPlan.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de un plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Plan plan)
        {
            try
            {
                this.OpenConnection();               

                SqlCommand cmdSave = new SqlCommand("Insert into planes (desc_plan, id_especialidad)" +
                    " values (@desc, @idEsp) select @@identity", sqlConn);

                //cmdSave.Parameters.Add("@ID", SqlDbType.VarChar, 50).Value = plan.ID;
                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("@idEsp", SqlDbType.VarChar, 50).Value = plan.Especialidad.ID;
                plan.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de un plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Plan plan)
        {
            if (plan.State == BusinessEntity.States.New)
            {
                // int NextIDCurso = 0;
                // foreach (Usuario usr in Usuarios)
                // {
                //  if (usr.IDCurso > NextIDCurso)
                // {
                //  NextIDCurso = usr.IDCurso;
                // }
                // }
                // usuario.IDCurso = NextIDCurso + 1;
                // Usuarios.Add(usuario);
                this.Insert(plan);
            }
            else if (plan.State == BusinessEntity.States.Deleted)
            {
                this.Delete(plan.ID);
            }
            else if (plan.State == BusinessEntity.States.Modified)
            {
                // Usuarios[Usuarios.FindIndex(delegate (Usuario u) { return u.IDCurso == usuario.IDCurso; })] = usuario;
                this.Update(plan);
            }
            plan.State = BusinessEntity.States.Unmodified;
        }
    }
}

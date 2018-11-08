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
    public class MateriaAdapter : Adapter
    {
        public List<Materia> GetAll()
        {
            // return new List<Materia>(Materias);
            List<Materia> Materias = new List<Materia>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMateria = new SqlCommand("select * from materias m " +
                    "left join planes p on p.id_plan = m.id_plan", sqlConn);
                SqlDataReader drMaterias = cmdMateria.ExecuteReader();
                while (drMaterias.Read())
                {
                    Materia mat = new Materia();
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.IDPlan = (int)drMaterias["id_plan"];
                    mat.Plan = new Plan();
                    mat.Plan.Descripcion = (string)drMaterias["desc_plan"];

                    Materias.Add(mat);
                }
                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return Materias;
        }


        public Business.Entities.Materia GetOne(int idMateria)
        {

            Materia materia = new Materia();
            try
            {
                this.OpenConnection();

                SqlCommand cmdMateria = new SqlCommand("select * from materias where id_materia = @idMateria", sqlConn);
                cmdMateria.Parameters.Add("@idMateria", SqlDbType.Int).Value = idMateria;
                SqlDataReader drMateria = cmdMateria.ExecuteReader();
                if (drMateria.Read())
                {
                    materia.ID = (int)drMateria["id_materia"];
                    materia.Descripcion = (string)drMateria["desc_materia"];
                    materia.HSSemanales = (int)drMateria["hs_semanales"];
                    materia.HSTotales = (int)drMateria["hs_totales"];
                    materia.IDPlan = (int)drMateria["id_plan"];
                }
                drMateria.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar una materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materia;
        }

        public void Delete(int idMateria)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete materias where id_materia = @idMateria", sqlConn);
                cmdDelete.Parameters.Add("@idMateria", SqlDbType.Int).Value = idMateria;
                cmdDelete.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar una materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Materia Materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdMateria = new SqlCommand("UPDATE materias SET id_plan = @id_plan, desc_materia = @desc_materia, " +
                    "hs_totales = @hs_totales, hs_semanales = @hs_semanales WHERE id_materia = @id_materia", sqlConn);
                cmdMateria.Parameters.Add("@id_materia", SqlDbType.Int).Value = Materia.ID;
                cmdMateria.Parameters.Add("@id_plan", SqlDbType.Int).Value = Materia.IDPlan;
                cmdMateria.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = Materia.Descripcion;
                cmdMateria.Parameters.Add("@hs_totales", SqlDbType.Int).Value = Materia.HSTotales;
                cmdMateria.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = Materia.HSSemanales;
                cmdMateria.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de una materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Materia Materia)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("Insert into materias (desc_materia, " +
                    "hs_semanales, hs_totales, id_plan) values (@desc_materia, @hs_semanales, @hs_totales, @id_plan)", sqlConn);
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = Materia.IDPlan;
                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = Materia.Descripcion;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = Materia.HSTotales;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = Materia.HSSemanales;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de un materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Materia Materia)
        {
            if (Materia.State == BusinessEntity.States.New)
            {
                this.Insert(Materia);
            }
            else if (Materia.State == BusinessEntity.States.Deleted)
            {
                this.Delete(Materia.ID);
            }
            else if (Materia.State == BusinessEntity.States.Modified)
            {
                // Materias[Materias.FindIndex(delegate (Materia u) { return u.IDCurso == materia.IDCurso; })] = materia;
                this.Update(Materia);
            }
            Materia.State = BusinessEntity.States.Unmodified;
        }
    }
}

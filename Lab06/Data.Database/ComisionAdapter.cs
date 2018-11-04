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
                    usr.AnioEspecialidad = (DateTime)drComisions["anio_especialidad"];                    

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


        public Business.Entities.Comision GetOne(int idComision)
        {
            
            Comision comision = new Comision();
            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuario = new SqlCommand("select * from comisiones where id_comision = @idComision", sqlConn);
                cmdUsuario.Parameters.Add("@idComision", SqlDbType.Int).Value = idComision;
                SqlDataReader drComision = cmdUsuario.ExecuteReader();
                if (drComision.Read())
                {

                    comision.ID = (int)drComision["id_comision"];
                    comision.IDPlan = (int)drComision["id_plan"];
                    comision.Descripcion = (string)drComision["desc_comision"];
                    comision.AnioEspecialidad = (DateTime)drComision["anio_especialidad"];
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
                this.OpenConnection();

                SqlCommand cmdComision = new SqlCommand("UPDATE comisiones SET id_comision = @id_comision, id_plan = @id_plan, desc_comision = @desc_comision, " +
                    "anio_especialidad = @anio_especialidad", sqlConn);
                cmdComision.Parameters.Add("@id_comision", SqlDbType.Int).Value = Comision.ID;
                cmdComision.Parameters.Add("@id_plan", SqlDbType.VarChar, 50).Value = Comision.IDPlan;
                cmdComision.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = Comision.Descripcion;
                cmdComision.Parameters.Add("@anio_especialidad", SqlDbType.Bit).Value = Comision.AnioEspecialidad;
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

                //comisiones SET id_comision = @Dictado, id_plan = @IDCurso, desc_comision = @IDDocente, " +
                //    "anio_especialidad = @anio_especialidad"

                SqlCommand cmdSave = new SqlCommand("Insert into comisiones (id_comision, id_plan, desc_comision, " +
                    "anio_especialidad) values (@ID, @IdPlan, @descripcion, @anioEspecialidad", sqlConn);

                cmdSave.Parameters.Add("@ID", SqlDbType.VarChar, 50).Value = Comision.ID;
                cmdSave.Parameters.Add("@IdPlan", SqlDbType.VarChar, 50).Value = Comision.IDPlan;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = Comision.Descripcion;
                cmdSave.Parameters.Add("@anioEspecialidad", SqlDbType.VarChar, 50).Value = Comision.AnioEspecialidad;
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
                this.Insert(Comision);
            }
            else if (Comision.State == BusinessEntity.States.Deleted)
            {
                this.Delete(Comision.ID);
            }
            else if (Comision.State == BusinessEntity.States.Modified)
            {
                // Usuarios[Usuarios.FindIndex(delegate (Usuario u) { return u.IDCurso == usuario.IDCurso; })] = usuario;
                this.Update(Comision);
            }
            Comision.State = BusinessEntity.States.Unmodified;
        }
    }
}

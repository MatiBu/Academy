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
    public class CursoAdapter : Adapter
    {
        public List<Curso> GetAll()
        {            
            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select * from cursos", sqlConn);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                while (drCursos.Read())
                {
                    Curso curso = new Curso();
                    curso.ID = (int)drCursos["id_curso"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    curso.Cupo = (int)drCursos["cupo"];
                    curso.IDComision = (int)drCursos["id_comision"];
                    curso.IDMateria = (int)drCursos["id_materia"];

                    cursos.Add(curso);
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de Cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;
        }

        public Curso GetOne(int ID)
        {
            Curso cursos = new Curso();
            try
            {
                this.OpenConnection();

                SqlCommand cmdCurso = new SqlCommand("select * from cursos where id_curso = @id", sqlConn);
                cmdCurso.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCurso.ExecuteReader();
                if (drCursos.Read())
                {
                    cursos.ID = (int)drCursos["id_curso"];
                    cursos.AnioCalendario = (int)drCursos["anio_calendario"];
                    cursos.Cupo = (int)drCursos["cupo"];
                    cursos.IDComision = (int)drCursos["id_comision"];
                    cursos.IDMateria = (int)drCursos["id_materia"];
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar un Curso por id", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete cursos where id_curso = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
                cmdDelete.Parameters.Clear();

                //falta Actualizar tablas relacionadas al id_curso

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar un Curso por id", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Curso Curso)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdCurso = new SqlCommand("UPDATE cursos SET cupo = @Cupo, AnioCalendario = @AnioCalendario, " +
                    "IDComision = @IDComision, IDMateria = @IDMateriaWHERE id_Curso = @id", sqlConn);

                cmdCurso.Parameters.Add("@id", SqlDbType.Int).Value = Curso.ID;
                //No esta este parametro en la base de datos
                //cmdCurso.Parameters.Add("@Descripcion", SqlDbType.Int, 50).Value = Curso.Descripcion;
                cmdCurso.Parameters.Add("@anio_calendario", SqlDbType.Int, 50).Value = Curso.AnioCalendario;
                cmdCurso.Parameters.Add("@Cupo", SqlDbType.VarChar, 50).Value = Curso.Cupo;                
                cmdCurso.Parameters.Add("@IDComision", SqlDbType.VarChar, 50).Value = Curso.IDComision;
                cmdCurso.Parameters.Add("@IDMateria", SqlDbType.VarChar, 50).Value = Curso.IDMateria;
                cmdCurso.ExecuteNonQuery();

                cmdCurso.Parameters.Clear();


            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de un Curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Curso Curso)
        {
            int id;            
            int idPln;
            try
            {

                this.OpenConnection();

                SqlCommand cmdCurso = new SqlCommand("Insert into especialidades (desc_especialidad) values (@desc_especialidad)" +
                    "select @@identity", sqlConn);                
                cmdCurso.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = "A definir";
                id = Decimal.ToInt32((decimal)cmdCurso.ExecuteScalar());
                cmdCurso.Parameters.Clear();

                cmdCurso.CommandText = "Insert into planes (desc_plan, id_especialidad) " +
                    "values (@descripcion, @id_especialidad) " +
                    "select @@identity";
                cmdCurso.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = "";
                cmdCurso.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = Convert.ToInt32(id);
                idPln = Decimal.ToInt32((decimal)cmdCurso.ExecuteScalar());
                cmdCurso.Parameters.Clear();

                cmdCurso.CommandText = "Insert into comisiones (desc_comision, anio_especialidad, id_plan) " +
                    " values (@desc_comision, @anio_especialidad, @id_plan) " +
                    "select @@identity";
                cmdCurso.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = "";
                cmdCurso.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = Curso.AnioCalendario;
                cmdCurso.Parameters.Add("@id_plan", SqlDbType.Int).Value = Convert.ToInt32(idPln);
                Curso.IDComision = Decimal.ToInt32((decimal)cmdCurso.ExecuteScalar());
                cmdCurso.Parameters.Clear();

                cmdCurso.CommandText = "Insert into materias (desc_materia, hs_semanales, hs_totales, id_plan)" +
                    " values (@desc_materia, @hs_semanales, @hs_totales, @id_plan) " +
                    "select @@identity";                
                cmdCurso.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = "";
                cmdCurso.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = 0;
                cmdCurso.Parameters.Add("@hs_totales", SqlDbType.Int).Value = 0;
                cmdCurso.Parameters.Add("@id_plan", SqlDbType.Int).Value = idPln;
                Curso.IDMateria = Decimal.ToInt32((decimal)cmdCurso.ExecuteScalar());
                cmdCurso.Parameters.Clear();

                cmdCurso.CommandText = "Insert into cursos(id_materia, id_comision, " +
                    "anio_calendario, cupo)" +
                    "values (@id_materia, @id_comision, @anio_calendario, @cupo) " +
                    "select @@identity";
                cmdCurso.Parameters.Add("@id_materia", SqlDbType.Int).Value = Curso.IDMateria;
                cmdCurso.Parameters.Add("@id_comision", SqlDbType.Int).Value = Curso.IDComision;
                cmdCurso.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = Curso.AnioCalendario;
                cmdCurso.Parameters.Add("@cupo", SqlDbType.Int).Value = Curso.Cupo;
                Curso.ID = Decimal.ToInt32((decimal)cmdCurso.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de un Curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Curso Curso)
        {
            if (Curso.State == BusinessEntity.States.New)
            {
                this.Insert(Curso);
            }
            else if (Curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(Curso.ID);
            }
            else if (Curso.State == BusinessEntity.States.Modified)
            {
                this.Update(Curso);
            }
            Curso.State = BusinessEntity.States.Unmodified;
        }
    }
}

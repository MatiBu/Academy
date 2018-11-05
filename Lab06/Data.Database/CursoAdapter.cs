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
            // return new List<Curso>(Cursos);
            List<Curso> curso = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select * from cursos", sqlConn);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                while (drCursos.Read())
                {
                    Curso alum = new Curso();
                    alum.ID = (int)drCursos["id_persona"];
                    alum.Descripcion = (string)drCursos["descripcion"];
                    alum.Cupo = (int)drCursos["cupo"];
                    alum.IDComision = (int)drCursos["IDComision"];
                    alum.IDMateria = (int)drCursos["IDMateria"];

                    curso.Add(alum);
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
            return curso;
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
                    cursos.Descripcion = (string)drCursos["descripcion"];
                    cursos.Cupo = (int)drCursos["cupo"];
                    cursos.AnioCalendario = (int)drCursos["anio_calendario"];
                    cursos.IDComision = (int)drCursos["IDComision"];
                    cursos.IDMateria = (int)drCursos["IDMateria"];
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

                SqlCommand cmdCurso = new SqlCommand("UPDATE cursos SET descripcion = @Descripcion, cupo = @Cupo, AnioCalendario = @AnioCalendario, " +
                    "IDComision = @IDComision, IDMateria = @IDMateriaWHERE id_Curso = @id", sqlConn);

                cmdCurso.Parameters.Add("@id", SqlDbType.Int).Value = Curso.ID;
                cmdCurso.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = Curso.Descripcion;
                cmdCurso.Parameters.Add("@Cupo", SqlDbType.VarChar, 50).Value = Curso.Cupo;
                cmdCurso.Parameters.Add("@AnioCalendario", SqlDbType.Bit).Value = Curso.AnioCalendario;
                cmdCurso.Parameters.Add("@IDComision", SqlDbType.VarChar, 50).Value = Curso.IDComision;
                cmdCurso.Parameters.Add("@IDMateria", SqlDbType.VarChar, 50).Value = Curso.IDMateria;
                cmdCurso.ExecuteNonQuery();
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
            try
            {
                this.OpenConnection();

                SqlCommand cmdCurso = new SqlCommand("Insert into cursos (IDComision, clave, habilitado, " +
                    "nombre, apellido, email) values (@id, @Descripcion, @Cupo, @AnioCalendario, @IDComision, @IDMateria) " +
                    "select @@identity", sqlConn);
                cmdCurso.Parameters.Add("@id", SqlDbType.Int).Value = Curso.ID;
                //cmdCurso.Parameters.Add("@Descripcion", SqlDbType.VarChar, 50).Value = Curso.Descripcion;
                cmdCurso.Parameters.Add("@Cupo", SqlDbType.VarChar, 50).Value = Curso.Cupo;
                cmdCurso.Parameters.Add("@AnioCalendario", SqlDbType.Bit).Value = Curso.AnioCalendario;
                cmdCurso.Parameters.Add("@IDComision", SqlDbType.VarChar, 50).Value = Curso.IDComision;
                cmdCurso.Parameters.Add("@IDMateria", SqlDbType.VarChar, 50).Value = Curso.IDMateria;
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

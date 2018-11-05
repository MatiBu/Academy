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
                    alum.ID = (int)drCursos["id_curso"];
                    alum.Cupo = (int)drCursos["cupo"];
                    alum.IDComision = (int)drCursos["id_comision"];
                    alum.IDMateria = (int)drCursos["id_materia"];

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

        public List<CursosComisionMateria> GetAllCursosComisionMateria()
        {
            List<CursosComisionMateria> curso = new List<CursosComisionMateria>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select * from cursos cu " +
                    "left join comisiones co on co.id_comision = cu.id_comision " +
                    "left join materias m on m.id_materia = cu.id_materia", sqlConn);
                SqlDataReader drCursos = cmdCursos.ExecuteReader();
                while (drCursos.Read())
                {
                    CursosComisionMateria cur = new CursosComisionMateria();
                    cur.ID = (int)drCursos["id_curso"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.IDComision = (int)drCursos["id_comision"];
                    cur.IDMateria = (int)drCursos["id_materia"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.DescripcionComision = (string)drCursos["desc_comision"];
                    cur.DescripcionMateria = (string)drCursos["desc_materia"];
                    cur.Horas = (int)drCursos["hs_semanales"];

                    curso.Add(cur);
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
                    cursos.Cupo = (int)drCursos["cupo"];
                    cursos.AnioCalendario = (int)drCursos["anio_calendario"];
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
                    "IDComision = @IDComision, IDMateria = @IDMateria WHERE id_Curso = @id", sqlConn);

                cmdCurso.Parameters.Add("@id", SqlDbType.Int).Value = Curso.ID;
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

                SqlCommand cmdCurso = new SqlCommand("Insert into cursos (id_comision, clave, habilitado, " +
                    "nombre, apellido, email) values (@id, @Cupo, @AnioCalendario, @IDComision, @IDMateria) " +
                    "select @@identity", sqlConn);
                cmdCurso.Parameters.Add("@id", SqlDbType.Int).Value = Curso.ID;
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

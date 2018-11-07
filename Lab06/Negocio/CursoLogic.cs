using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class CursoLogic : BusinessLogic
    {
        private CursoAdapter CursoData;

        public CursoLogic()
        {
            CursoData = new CursoAdapter();
        }

        public Curso GetOne(int ID)
        {
            return CursoData.GetOne(ID);
        }

        public List<Curso> GetAll()
        {
            try
            {
                return CursoData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
        }

        public List<CursosComisionMateria> GetAllCursosComisionMateria()
        {
            try
            {
                return CursoData.GetAllCursosComisionMateria();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
        }
        
        public void Save(Curso Curso)
        {
            CursoData.Save(Curso);
        }

        public void Insert(Curso Curso)
        {
            CursoData.Insert(Curso);
        }

        public void Delete(int ID)
        {
            CursoData.Delete(ID);
        }
    }
}

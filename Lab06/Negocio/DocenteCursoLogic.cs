using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class DocenteCursoLogic : BusinessLogic
    {
        private DocenteCursoAdapter DocenteCursoData;

        public DocenteCursoLogic()
        {
            DocenteCursoData = new DocenteCursoAdapter();
        }

        public DocenteCurso GetOne(int ID)
        {
            return DocenteCursoData.GetOne(ID);
        }

        public List<DocenteCurso> GetAll()
        {
            try
            {
                return DocenteCursoData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Save(DocenteCurso docenteCurso)
        {
            DocenteCursoData.Save(docenteCurso);
        }

        public void Delete(int ID)
        {
            DocenteCursoData.Delete(ID);
        }
    }
}

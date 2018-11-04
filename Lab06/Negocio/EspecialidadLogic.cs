using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class EspecialidadLogic: BusinessLogic
    {
        private EspecialidadAdapter EspecialidadData;

        public EspecialidadLogic()
        {
            EspecialidadData = new EspecialidadAdapter();
        }

        public Especialidad GetOne(int ID)
        {
            return EspecialidadData.GetOne(ID);
        }

        public List<Especialidad> GetAll()
        {
            try
            {
                return EspecialidadData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de especialidad", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Save(Especialidad docenteCurso)
        {
            EspecialidadData.Save(docenteCurso);
        }

        public void Delete(int ID)
        {
            EspecialidadData.Delete(ID);
        }
    }
}

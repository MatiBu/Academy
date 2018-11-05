using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class MateriaLogic: BusinessLogic
    {
        private MateriaAdapter MateriaData;

        public MateriaLogic()
        {
            MateriaData = new MateriaAdapter();
        }

        public Materia GetOne(int ID)
        {
            return MateriaData.GetOne(ID);
        }

        public List<Materia> GetAll()
        {
            try
            {
                return MateriaData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Save(Materia materia)
        {
            MateriaData.Save(materia);
        }

        public void Delete(int ID)
        {
            MateriaData.Delete(ID);
        }
    }
}

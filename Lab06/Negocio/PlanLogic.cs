using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
        private PlanAdapter PlanData;

        public PlanLogic()
        {
            PlanData = new PlanAdapter();
        }

        public Plan GetOne(int ID)
        {
            return PlanData.GetOne(ID);
        }

        public List<Plan> GetAll()
        {
            try
            {
                return PlanData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Save(Plan docenteCurso)
        {
            PlanData.Save(docenteCurso);
        }

        public void Delete(int ID)
        {
            PlanData.Delete(ID);
        }        
    }
}

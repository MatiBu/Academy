using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
    {
        private ComisionAdapter ComisionData;

        public ComisionLogic()
        {
            ComisionData = new ComisionAdapter();
        }

        public Comision GetOne(int ID)
        {
            return ComisionData.GetOne(ID);
        }

        public List<Comision> GetAll()
        {
            try
            {
                return ComisionData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
        }

        public List<Comision> GetByDescription(string desc)
        {
            try
            {
                return ComisionData.GetByDescription(desc);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de comisiones por descripcion", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Save(Comision comision)
        {
            ComisionData.Save(comision);
        }

        public void Delete(int ID)
        {
            ComisionData.Delete(ID);
        }
    }
}

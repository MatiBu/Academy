using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class AlumnoLogic : BusinessLogic
    {
        private AlumnoAdapter AlumnoData;

        public AlumnoLogic()
        {
            AlumnoData = new AlumnoAdapter();
        }

        public Alumno GetOne(int ID)
        {
            return AlumnoData.GetOne(ID);
        }

        public List<Alumno> GetAll()
        {
            try
            {
                return AlumnoData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de alumnos", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Save(Alumno alumno)
        {
            AlumnoData.Save(alumno);
        }

        public void Delete(int ID)
        {
            AlumnoData.Delete(ID);
        }

    }
}

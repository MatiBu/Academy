using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Business.Logic
{
    public class AlumnoInscripcionesLogic : BusinessLogic
    {
        private AlumnoInscripcionesAdapter AlumnoInscripcionesData;

        public AlumnoInscripcionesLogic()
        {
            AlumnoInscripcionesData = new AlumnoInscripcionesAdapter();
        }

        public AlumnoInscripciones GetOne(int ID)
        {
            return AlumnoInscripcionesData.GetOne(ID);
        }

        public List<AlumnoInscripciones> GetAll()
        {
            try
            {
                return AlumnoInscripcionesData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Save(AlumnoInscripciones alumnoInscripciones)
        {
            AlumnoInscripcionesData.Save(alumnoInscripciones);
        }

        public void Delete(int ID)
        {
            AlumnoInscripcionesData.Delete(ID);
        }
    }
}

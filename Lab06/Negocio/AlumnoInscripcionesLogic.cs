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

        public List<AlumnoInscripciones> GetOneByAlumno(int ID)
        {
            return AlumnoInscripcionesData.GetOneByAlumno(ID);
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
                new Exception("Error al recuperar lista de alumnos", Ex);
                throw ExcepcionManejada;
            }
        }

        public List<AlumnoInscripciones> BuscarAlumnos(int carrera, int materia, string comision)
        {
            try
            {
                return AlumnoInscripcionesData.BuscarAlumnos(carrera, materia, comision);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de alumnos", Ex);
                throw ExcepcionManejada;
            }
        }

        public void Save(AlumnoInscripciones alumnoInscripciones)
        {
            AlumnoInscripcionesData.Save(alumnoInscripciones);
        }

        public void SaveAll(List<AlumnoInscripciones> alumnosInscripciones)
        {
            AlumnoInscripcionesData.SaveAll(alumnosInscripciones);
        }

        public void Delete(int ID)
        {
            AlumnoInscripcionesData.Delete(ID);
        }
    }
}

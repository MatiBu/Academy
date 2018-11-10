using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Alumno: Usuario
    {
        private int _IDEspecialidad;
        private Especialidad _Especialidad;
        private List<Materia> _Materias;

        public int IDEspecialidad { get => _IDEspecialidad; set => _IDEspecialidad = value; }
        public Especialidad Especialidad { get => _Especialidad; set => _Especialidad = value; }
        public List<Materia> Materias { get => _Materias; set => _Materias = value; }
    }
}

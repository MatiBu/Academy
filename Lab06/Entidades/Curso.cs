using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Curso : BusinessEntity
    {
        private int _AnioCalendario;
        private int _Cupo;
        private int _IDComision;
        private int _IDMateria;
        private Comision _Comision;
        private Materia _Materia;

        public int AnioCalendario { get => _AnioCalendario; set => _AnioCalendario = value; }
        public int Cupo { get => _Cupo; set => _Cupo = value; }
        public int IDComision { get => _IDComision; set => _IDComision = value; }
        public int IDMateria { get => _IDMateria; set => _IDMateria = value; }
        public Comision Comision { get => _Comision; set => _Comision = value; }
        public Materia Materia { get => _Materia; set => _Materia = value; }
    }
}

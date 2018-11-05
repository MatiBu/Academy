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
        private string _DescripcionComision;
        private string _DescripcionMateria;

        public int AnioCalendario { get => _AnioCalendario; set => _AnioCalendario = value; }
        public int Cupo { get => _Cupo; set => _Cupo = value; }
        public int IDComision { get => _IDComision; set => _IDComision = value; }
        public int IDMateria { get => _IDMateria; set => _IDMateria = value; }
        public string DescripcionComision { get => _DescripcionComision; set => _DescripcionComision = value; }
        public string DescripcionMateria { get => _DescripcionMateria; set => _DescripcionMateria = value; }
    }
}

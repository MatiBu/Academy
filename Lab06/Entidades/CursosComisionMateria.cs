using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class CursosComisionMateria : BusinessEntity
    {
        private int _AnioCalendario;
        private int _Cupo;
        private int _IDComision;
        private int _IDMateria;
        private string __DescripcionComision;
        private string __DescripcionMateria;
        private int __Horas;

        public int AnioCalendario { get => _AnioCalendario; set => _AnioCalendario = value; }
        public int Cupo { get => _Cupo; set => _Cupo = value; }
        public int IDComision { get => _IDComision; set => _IDComision = value; }
        public int IDMateria { get => _IDMateria; set => _IDMateria = value; }
        public string DescripcionComision { get => __DescripcionComision; set => __DescripcionComision = value; }
        public string DescripcionMateria { get => __DescripcionMateria; set => __DescripcionMateria = value; }
        public int Horas { get => __Horas; set => __Horas = value; }
    }
}

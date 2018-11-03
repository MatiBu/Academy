using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Modulo: BusinessEntity
    {
        private string _Descripcion;
        private string _Ejecuta;

        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Ejecuta { get => _Ejecuta; set => _Ejecuta = value; }
    }
}

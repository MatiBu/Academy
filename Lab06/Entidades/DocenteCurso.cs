using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class DocenteCurso: BusinessEntity
    {
        private int _Dictado;
        private int _Cargo;
        private int _IDCurso;
        private int _IDDocente;

        public int Dictado { get => _Dictado; set => _Dictado = value; }
        public int IDCurso { get => _IDCurso; set => _IDCurso = value; }
        public int IDDocente { get => _IDDocente; set => _IDDocente = value; }
        public int Cargo { get => _Cargo; set => _Cargo = value; }        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Usuario : Persona

    {
        private string _NombreUsuario;
        private string _Clave;
        private bool _Habilitado;

        public string NombreUsuario { get => _NombreUsuario; set => _NombreUsuario = value; }
        public string Clave { get => _Clave; set => _Clave = value; }
        public bool Habilitado { get => _Habilitado; set => _Habilitado = value; }
    }

    public enum FormModes
    {
        Alta,
        Baja,
        Modificacion
    }



}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Persona : BusinessEntity
    {
        private string _Apellido;
        private string _Direccion;
        private string _EMail;
        private DateTime _FechaNacimiento;
        private int _IDPlan;
        private int _Legajo;
        private string _Nombre;
        private string _Telefono;
        private TipoPersonas _TipoPersona;

        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string EMail { get => _EMail; set => _EMail = value; }
        public DateTime FechaNacimiento { get => _FechaNacimiento; set => _FechaNacimiento = value; }
        public int IDPlan { get => _IDPlan; set => _IDPlan = value; }
        public int Legajo { get => _Legajo; set => _Legajo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public TipoPersonas TipoPersona { get => _TipoPersona; set => _TipoPersona = value; }

        public enum TipoPersonas
        {
            Alumno,
            Usuario,
            Docente
        }
    }
}

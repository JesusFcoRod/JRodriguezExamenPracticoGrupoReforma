using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Edad { get; set; }
        public string Correo { get; set; }
        public string HabilidadPrimaria { get; set; }
        public string HabilidadSecundaria { get; set; }
        public int idTipo { get; set; }

        public List<object> Personas { get; set; }
    }
}

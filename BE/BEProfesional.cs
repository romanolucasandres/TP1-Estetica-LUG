using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEProfesional: BEPersona
    {
        public string Titulo { get; set; }

        public BEProfesional(string ape)
        {

            Apellido = ape;
        }
        public BEProfesional() { }

        public override string ToString()
        {
            return Apellido;
        }
    }
}

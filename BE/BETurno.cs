using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BE
{
    public class BETurno : Entidad
    {
        private BECliente cliente;
        private BEProfesional profesional;
        private BETratamiento tratamiento;

        
        #region Propiedades
        //relacion 1 a 1
        public BECliente Cliente { get => cliente; set => cliente = value; }
        public BEProfesional Profesional { get => profesional; set => profesional = value; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Consultorio { get; set; }

        public BETratamiento Tratamiento { get =>tratamiento; set =>tratamiento = value; }

        public decimal Total { get; set; }

        #endregion
        public void CalcularTotal()
        {
            
          Total = Tratamiento.Costo;
            
        }



        

    }
    public enum Consultorios
    {
        C101, C102, C103, C104
    };
}

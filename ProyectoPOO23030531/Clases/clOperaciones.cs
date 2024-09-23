using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPOO23030531
{
    internal class clOperaciones
    {
        // Como es (características, campos)
        private decimal valor1;
        private decimal valor2;

        public decimal Valor1 { get => valor1; set => valor1 = value; }
        public decimal Valor2 { get => valor2; set => valor2 = value; }

        public clOperaciones(decimal valor1, decimal valor2)
        {
            this.valor1 = valor1;
            this.valor2 = valor2;
        }
        public clOperaciones()
        {

        }
        // Propiedades get, set

        // Constructores

        // Lo que hace (acción)
        public decimal suma()
        {
            return (valor1 + valor2);
        }
        public decimal resta() { return (valor1 - valor2);
        }
        public decimal multiplicacion() { return (valor1 * valor2); 
        }
        public decimal division() {return (valor1 / valor2);
        }
        

    }
}

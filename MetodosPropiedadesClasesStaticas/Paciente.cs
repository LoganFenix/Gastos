
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosPropiedadesClasesStaticas
{
    class Paciente
    {
        private string nombre;
        public string Nombre
        {

            get { return nombre; }
            set { nombre = value; }

        }

        private string apellido;
        public string Apelido
        {


            get { return apellido; }
            set { apellido = value; }
        }

        public string Informacion(string valor1, string valor2)
        {
            string mensaje = "Su nombre es: " + valor1 + "Y su diagnostico es " + valor2;


            return mensaje;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosPropiedadesClasesStaticas
{
    class Program
    {
        static void Main(string[] args)
        {

            Paciente pa = new Paciente();
            string nombre = "leo";
            string diag= "fiebre";


            Console.WriteLine("Mensaje Inicial");
            Console.WriteLine(pa.Informacion(nombre, diag));
            Console.ReadLine();
        }
    }
}

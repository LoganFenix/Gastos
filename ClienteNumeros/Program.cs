using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteNumeros
{
    class Program
    {
        static void Main(string[] args)
        {

            Numeros.Primos np = new Numeros.Primos();
            np.PrimoEncontrado += esribeprimoencontrado;
            Console.WriteLine(np.VerificarSiesNumeroPrimo(7));
            Console.WriteLine(np.CuentaPrimos(1, 10).ToString());
            Console.Write("Presiona <enter> para continuar");
            Console.ReadLine();


        }


        static void esribeprimoencontrado(int primo)
        {

            Console.WriteLine(primo);
    
        }







    }
}

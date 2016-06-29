using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeros
{
   public class Primos
    {
       public delegate void PrimoEncontradoEventHandler(int primo);

       public event PrimoEncontradoEventHandler PrimoEncontrado;


       public bool VerificarSiesNumeroPrimo(int n)
       {

           bool EsPrimo = true;

           for (int i = 2; i < n; i++)
           {
               var r = n % i;

               if (r == 0)
               {
                   EsPrimo = false;
               }

           }

           return EsPrimo;

       }

       public int CuentaPrimos(int rangoInicial, int rangoFinal)
       {

           int Contador = 0;
           for (int  i = rangoInicial; i <= rangoFinal; i++)
           {
               if (VerificarSiesNumeroPrimo(i))
               {
                   Contador++;
                   if (PrimoEncontrado != null)
                   {
                       PrimoEncontrado(i);

                   }
               }
           }

           return Contador;

       }




    }
}

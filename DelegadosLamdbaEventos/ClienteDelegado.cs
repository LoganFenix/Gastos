using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegadosLamdbaEventos
{
    delegate void Escribemensaje(string mensaje);
    class ClienteDelegado
    {

        //public int Divide(int A, int B, out bool error)
        public Escribemensaje direcciondelmetodo;
        public int Divide(int A, int B)
        {


            int C = 0;

            if (B == 0)
            {

                //throw new Exception("Hay una division entre cero");
                //error = true;
                //Escribe("División entre Cero");
                if (direcciondelmetodo != null)
                {
                    direcciondelmetodo("División entre cero");
                }

            }
            else
            {
                C = A / B;
            }

            return C;

        }

        //dirección: Se conoce como el método Call Back...
        public int Divide(int A, int B, Action<string> direccion)
        {


            int C = 0;

            if (B == 0)
            {

               
                if (direccion != null)
                {
                    direccion("División entre cero");
                }

            }
            else
            {
                C = A / B;
            }

            return C;

        }

        public int DivideConFunc(int A, int B, Func<string, bool> direccion)
        {


            int C = 0;

            if (B == 0)
            {


                if (direccion != null)
                {
                    var Resultado = direccion("División entre cero");

                }

            }
            else
            {
                C = A / B;
            }

            return C;

        }




        
    }
}

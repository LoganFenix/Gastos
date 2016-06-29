using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegadosLamdbaEventos
{
    class Ejemplos
    {

        public void EjemploDelegadoPersonalizadoconFUnc()
        {
            ClienteDelegado c = new ClienteDelegado();
            Func<string, bool> Direccion;
            Direccion = ErrorDivision;
            Console.WriteLine(c.DivideConFunc(4, 0, Direccion));
        }

        public void EjemploDelegadoPersonalizado()
        {
            ClienteDelegado c = new ClienteDelegado();
            Action<string> Direccion;
            Direccion = Escribe;
            Console.WriteLine(c.Divide(4, 0, Direccion));
        }

        public void EjemploDelegado()
        {
            ClienteDelegado c = new ClienteDelegado();
            c.direcciondelmetodo = Escribe;
            
           


            Console.WriteLine(c.Divide(4, 0));


        }


        public void EjemploDelegadoAnonimo()
        {
            ClienteDelegado c = new ClienteDelegado();
            c.direcciondelmetodo = Escribe;
            c.direcciondelmetodo += Escribe2;
            //Delegado anonimo
            c.direcciondelmetodo += delegate(string mensaje)
            {
                Console.WriteLine("Delegado Anónimo: {0}", mensaje);
            };



            Console.WriteLine(c.Divide(4, 0));


        }


        public void EjemploLambda()
        {
            ClienteDelegado c = new ClienteDelegado();
            c.direcciondelmetodo = Escribe;
            c.direcciondelmetodo += Escribe2;
            //Delegado anonimo
            c.direcciondelmetodo += (mensaje) =>
            {
                Console.WriteLine("Con operador lamda: {0}", mensaje);
            };
            Console.WriteLine(c.Divide(4, 0));


        }


        public void EjemploLambdaConunaExpresion()
        {
            ClienteDelegado c = new ClienteDelegado();
            c.direcciondelmetodo = Escribe;
            c.direcciondelmetodo += Escribe2;
            //Delegado anonimo
            c.direcciondelmetodo += mensaje =>
            Console.WriteLine("Con operador lamda una expresi+on: {0}", mensaje);
            Console.WriteLine(c.Divide(4, 0));


        }

        #region método de escritura
        void Escribe(string mensaje)
        {

            Console.WriteLine(mensaje);


        }

        void Escribe2(string mensaje)
        {

            Console.WriteLine("Escribe 2 {0}", mensaje);


        }
        #endregion

        bool ErrorDivision(string Mensaje)
        {


            Console.WriteLine(Mensaje);

            return true;
        }



    }
}

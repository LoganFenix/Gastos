using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {



            var file = new FileStream("./Miarchivo.bin", FileMode.OpenOrCreate);

            Console.WriteLine("Antes de procesar sincrono");
            ProcesarArchivo(file);
            Console.WriteLine("Despues de procesar sincrono");

            Console.WriteLine("Antes de procesar asincrono");
            ProcesarArchivoAsync(file);
            Console.WriteLine("Despues de procesar asincrono");

           
             Console.ReadLine();
           
        }

        private static void ProcesarArchivo(FileStream file)
        {
            var msg = "Hola Mundo";
            var bytes = Encoding.UTF8.GetBytes(msg);
            for (int i = 0; i < 10000000; i++)
            {
                file.Write(bytes, 0, bytes.Length);
            }
        }

        private static async void ProcesarArchivoAsync(FileStream file)
        {
            var msg = "Hola Mundo";
            var bytes = Encoding.UTF8.GetBytes(msg);
            Console.WriteLine("Escribiendo...");
            for (int i = 0; i < 10000; i++)
            {
                await file.WriteAsync(bytes, 0, bytes.Length);
            }
            file.Close();
            Console.WriteLine("Ya escribio");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librerias
{
    class Program
    {
        static void Main(string[] args)
        {

            FileHelper fh = new FileHelper();

            var respuesta =fh.GetFileSystemObjects("./");

            foreach (var item in respuesta)
            {
                Console.WriteLine("Name: " + item.Name + "- Tipo: " + item.FileType);
            }

            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librerias
{
    public class FileHelper
    {

        public List<FileObjectInfo> GetFileSystemObjects(string path)
        {


            List<string> lista = new List<string>
            (Directory.EnumerateFileSystemEntries(path));

            DirectoryInfo di = new DirectoryInfo(path);
            var listaInfo = di.EnumerateFileSystemInfos();
            var fileObjects = new List<FileObjectInfo>();

            foreach (var fso in listaInfo)
            {

                FileObjectType  tipo = FileObjectType.Directory;

                if (fso.Attributes == FileAttributes.Archive)

                    tipo = FileObjectType.File;

                    fileObjects.Add(new FileObjectInfo() { Path = fso.FullName, Name = fso.Name, FileType = tipo });

             

            }

            return fileObjects;


        }
    }
}

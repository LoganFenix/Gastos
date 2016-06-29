using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Modelos.Imagenes
{
    public class ImagenesDTO
    {
        [Key]
        public Guid IdImagen { get; set; }
        public Guid IdProducto { get; set; }
        public string UrlImagenChica { get; set; }
        public string UrlImagenGrande { get; set; }
        public bool Esportada { get; set; }
      

        public HttpPostedFileWrapper ImagenSubida { get; set; }
        public bool ImagenEliminada { get; set; }

    }
}

using Modelos.Imagenes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace Modelos
{
    public class ProductosDTO
    {
        [Key]
        public Guid IdProducto { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre para el producto")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese el tipo de gasto")]
        public Guid IdTipoGasto { get; set; }
        public string NombreTipoGasto { get; set; }
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Video { get; set; }
        public IEnumerable<ImagenesDTO> ListaImagenes { get;set;}
        public IEnumerable<TiposDeGastosDTO> ListaTipoGastos { get; set; }
    }
}

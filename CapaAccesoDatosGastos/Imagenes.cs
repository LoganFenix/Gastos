//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaAccesoDatosGastos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Imagenes
    {
        public System.Guid IdImagen { get; set; }
        public System.Guid IdProducto { get; set; }
        public string UrlImagenChica { get; set; }
        public string UrlImagenGrande { get; set; }
        public Nullable<bool> Esportada { get; set; }
        public string UsuarioAlta { get; set; }
        public System.DateTime FechaAlta { get; set; }
     
    
        public virtual Productos Productos { get; set; }
    }
}

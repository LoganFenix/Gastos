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
    
    public partial class Productos
    {
        public Productos()
        {
            this.Imagenes = new HashSet<Imagenes>();
        }
    
        public System.Guid IdProducto { get; set; }
        public string Nombre { get; set; }
        public System.Guid IdTipoGasto { get; set; }
        public string Descripcion { get; set; }
        public string Video { get; set; }
        public System.DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
    
        public virtual ICollection<Imagenes> Imagenes { get; set; }
        public virtual TiposdeGastos TiposdeGastos { get; set; }
    }
}
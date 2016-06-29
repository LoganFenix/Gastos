using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatosGastos.Producto
{
    public interface IProductos
    {
        void AgregarProductos(ProductosDTO ProductosDTO);
        ProductosDTO ObtenerProducto(Guid IdProducto);
        List<ProductosDTO> ListaProductos();
        void ActualizarProducto(ProductosDTO ActualizarProducto);
        void EliminarProducto(Guid IdProducto);
        void AgregarImagenPredeterminada(ProductosDTO ProductosDTO);
    }
}

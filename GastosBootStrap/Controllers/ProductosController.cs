using CapaAccesoDatosGastos;
using CapaAccesoDatosGastos.Producto;
using Metodos;
using Modelos;
using Modelos.Imagenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GastosBootStrap.Controllers
{

   
    public class ProductosController : Controller
    {


        IProductos _productos;
        ITiposdeGastos _tipogasto;

        public ProductosController(IProductos productos, ITiposdeGastos tiposdegastos)
        {
            _productos = productos;
            _tipogasto = tiposdegastos;
        }

        public ProductosController()
            : this(new ProductosDatos(), new TipoGastos())
        {

        }



        // GET: Productos
        public ActionResult Index()
        {
            var productos = _productos.ListaProductos();

            return View(productos);
        }



        [HttpGet]
        public ActionResult Agregar()
        {
            var productos = new ProductosDTO();
            productos.ListaTipoGastos = _tipogasto.ObtenerTiposGastos(new Guid());
            return View(productos);
        }

        [HttpPost]
        public ActionResult Agregar(ProductosDTO ProductosDTO)
        {
            if (ModelState.IsValid)
            {

                var guardarimagen = new GuardarImagen();

                if (ProductosDTO.ListaImagenes == null)
                {
                    _productos.AgregarImagenPredeterminada(ProductosDTO);
                }
                else
                {
                    foreach (var imagen in ProductosDTO.ListaImagenes)
                    {
                        string fileName = Guid.NewGuid().ToString();

                        imagen.UrlImagenChica = guardarimagen.ResizeAndSave(fileName, imagen.ImagenSubida.InputStream, Tamanos.Miniatura, false);
                        imagen.UrlImagenGrande = guardarimagen.ResizeAndSave(fileName, imagen.ImagenSubida.InputStream, Tamanos.Mediana, false);
                    }
                }

                _productos.AgregarProductos(ProductosDTO);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Editar(Guid id)
        {
            var producto = _productos.ObtenerProducto(id);
            producto.ListaTipoGastos = _tipogasto.ObtenerTiposGastos(producto.IdTipoGasto);
            return View(producto);
        }


        [HttpPost]
        public ActionResult Editar(ProductosDTO productosDTO)
        {
            if (ModelState.IsValid)
            {

                _productos.ActualizarProducto(productosDTO);
                return RedirectToAction("Index");

            }
            return View();


        }

        

        [HttpGet]
        public ActionResult Eliminar(Guid id)
        {
            var producto = _productos.ObtenerProducto(id);
            return View(producto);

        }

        [HttpPost]
        public ActionResult Eliminar(Guid id, FormCollection collection)
        {

            _productos.EliminarProducto(id);

            return RedirectToAction("Index");

        }

        public ActionResult VistaPrevia(Guid id)
        {

            var productosDTO = _productos.ObtenerProducto(id);

            return View(productosDTO);
           
        }

        public ActionResult GuardarTipo(string NombreTipo)
        {

            _tipogasto.AgregarTipo(NombreTipo);
            var productos = new ProductosDTO();
            productos.ListaTipoGastos = _tipogasto.ObtenerTiposGastos(new Guid());
            return PartialView("ListaTiposGasto", productos);

        }

    }
}
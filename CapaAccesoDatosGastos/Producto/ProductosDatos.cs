using Metodos;
//using CapaAccesoDatosGastos.DatosImagenes;
using Modelos;
using Modelos.Imagenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatosGastos.Producto
{
    public class ProductosDatos:IProductos
    {
        public void AgregarProductos(ProductosDTO ProductosDTO)
        {
           using (ControlPersonalEntities2 contexto = new ControlPersonalEntities2())
           {

               var producto = new Productos();

              
               

               producto.FechaAlta = DateTime.Now;
               producto.UsuarioAlta = "";
               producto.IdProducto = Guid.NewGuid();
               producto.IdTipoGasto = ProductosDTO.IdTipoGasto;
               producto.Nombre = ProductosDTO.Nombre;
               producto.Video = ProductosDTO.Video;
               producto.Descripcion = ProductosDTO.Descripcion;
               producto.Video = ProductosDTO.Video;
               


               if (ProductosDTO.ListaImagenes != null)
               {
                   foreach (var imagen in ProductosDTO.ListaImagenes)
                   {
                       producto.Imagenes.Add(new Imagenes()
                       {
                           IdImagen = Guid.NewGuid(),
                           IdProducto = producto.IdProducto,
                           UrlImagenChica = imagen.UrlImagenChica,
                           UrlImagenGrande = imagen.UrlImagenGrande,
                           Esportada = imagen.Esportada,
                           UsuarioAlta = "",
                           FechaAlta = DateTime.Now

                       });
                   }
               }


               contexto.Productos.Add(producto);
               contexto.SaveChanges();


           }
        }

        public ProductosDTO ObtenerProducto(Guid IdProducto)
        {
            using (ControlPersonalEntities2 contexto = new ControlPersonalEntities2())
            {
                var producto = contexto.Productos.FirstOrDefault(x => x.IdProducto == IdProducto);
                var listaimagenes = contexto.Imagenes.Where(x => x.IdProducto == IdProducto).ToList();
                List<ImagenesDTO> imagenes = new List<ImagenesDTO>();

                if (listaimagenes != null)
                {
                    foreach (Imagenes imagen in listaimagenes)
                    {
                        ImagenesDTO datos = new ImagenesDTO();
                        datos.IdImagen = imagen.IdImagen;
                        datos.IdProducto = imagen.IdProducto;
                        datos.Esportada = imagen.Esportada.Value;
                        datos.UrlImagenChica = imagen.UrlImagenChica;
                        datos.UrlImagenGrande = imagen.UrlImagenGrande;
                      
                        imagenes.Add(datos);

                    }
                }



            

                if (producto != null)
                {
                    return new ProductosDTO()
                    {
                        IdProducto = producto.IdProducto,
                        IdTipoGasto = producto.IdTipoGasto,
                        Nombre = producto.Nombre,
                        NombreTipoGasto = producto.TiposdeGastos.DescripcionGasto,
                        Descripcion = producto.Descripcion,
                        Video = producto.Video,

                    
                        ListaImagenes = imagenes,
                       
                        
                    };
                }
                else
                {

                    return new ProductosDTO();

                }

            }
        }

        public List<ProductosDTO> ListaProductos()
        {
            using (ControlPersonalEntities2 contexto = new ControlPersonalEntities2())
            {
                var listaproductos = new List<ProductosDTO>();

                var productos =
                    (from x in contexto.Productos
                     
                   
                     select x).OrderBy(x => x.IdProducto).ToList();


                foreach (var producto in productos)
                {


                    ProductosDTO lista = new ProductosDTO();

                    lista.IdProducto = producto.IdProducto;
                    lista.NombreTipoGasto = producto.TiposdeGastos.DescripcionGasto;
                    lista.Nombre = producto.Nombre;

                    List<ImagenesDTO> ListallenaImagenes = new List<ImagenesDTO>();

                    if (contexto.Imagenes.Where(x => x.IdProducto == producto.IdProducto).Count() > 0)
                    {
                        var imagenes = contexto.Imagenes.Where(x => x.IdProducto == producto.IdProducto).ToList();
                       

                        foreach (Imagenes imagen in imagenes)
                        {

                            ImagenesDTO datos = new ImagenesDTO();

                            datos.Esportada = imagen.Esportada.HasValue? imagen.Esportada.Value:false;
                            datos.IdImagen = imagen.IdImagen;
                            datos.IdProducto = imagen.IdProducto;
                            datos.UrlImagenChica = imagen.UrlImagenChica;
                            ListallenaImagenes.Add(datos);

                        }



                    }

                    lista.ListaImagenes = ListallenaImagenes;
                    listaproductos.Add(lista);

                    
                }

                

                return listaproductos;

            }
        }

        public void ActualizarProducto(ProductosDTO ActualizarProducto)
        {
            using (ControlPersonalEntities2 contexto = new ControlPersonalEntities2())
            {

                if (ActualizarProducto.ListaImagenes != null && ActualizarProducto.ListaImagenes.Any())
                {
                    foreach (var imagen in ActualizarProducto.ListaImagenes)
                    {

                        string fileName = Guid.NewGuid().ToString();

                        if (!imagen.ImagenEliminada && imagen.ImagenSubida != null)
                        {

                            imagen.UrlImagenChica = new GuardarImagen().ResizeAndSave(fileName, imagen.ImagenSubida.InputStream, Tamanos.Miniatura, false);
                            imagen.UrlImagenGrande = new GuardarImagen().ResizeAndSave(fileName, imagen.ImagenSubida.InputStream, Tamanos.Mediana, false);


                            ActualizarProducto.ListaImagenes.ToList().Add(new ImagenesDTO()
                            {
                                UrlImagenChica = imagen.UrlImagenChica,
                                UrlImagenGrande = imagen.UrlImagenGrande
                            });
                        }
                    }
                }


                var producto = contexto.Productos.FirstOrDefault(x => x.IdProducto == ActualizarProducto.IdProducto);

                if (producto != null)
                {
                    producto.IdTipoGasto = ActualizarProducto.IdTipoGasto;
                    producto.Nombre = ActualizarProducto.Nombre;
                    producto.Video = ActualizarProducto.Video;



                    if (ActualizarProducto.ListaImagenes != null)
                    {

                        List<ImagenesDTO> imagenesagregar = new List<ImagenesDTO>();



                        foreach (var imagen in ActualizarProducto.ListaImagenes)
                        {
                            var imagenes = contexto.Imagenes.Any(x => x.IdImagen == imagen.IdImagen);
                            if (imagenes == false)
                            {

                                Imagenes datos = new Imagenes();
                                datos.IdImagen = Guid.NewGuid();
                                datos.IdProducto = producto.IdProducto;
                                datos.Esportada = imagen.Esportada;
                                datos.UrlImagenChica = imagen.UrlImagenChica;
                                datos.UrlImagenGrande = imagen.UrlImagenGrande;
                                datos.UsuarioAlta = "";
                                datos.FechaAlta = DateTime.Now;
                               
                                contexto.Imagenes.Add(datos);
                                contexto.SaveChanges();


                                ImagenesDTO datosimagen = new ImagenesDTO();

                                datosimagen.IdImagen = datos.IdImagen;
                                datosimagen.IdProducto = datos.IdProducto;
                                imagenesagregar.Add(datosimagen);

                            }

                            else
                            {

                                var imagenediatada = contexto.Imagenes.FirstOrDefault(x => x.IdImagen == imagen.IdImagen);

                                imagenediatada.Esportada = imagen.Esportada;
                                imagenediatada.UrlImagenChica = imagen.UrlImagenChica;
                                imagenediatada.UrlImagenGrande = imagen.UrlImagenGrande;
                              
                                
                                contexto.SaveChanges();



                                ImagenesDTO datosimagen = new ImagenesDTO();

                                datosimagen.IdImagen = imagenediatada.IdImagen;
                                datosimagen.IdProducto = imagenediatada.IdProducto;
                                imagenesagregar.Add(datosimagen);

                            }

                        }


                        



                        Guid[] numimag = imagenesagregar.Select(x => x.IdImagen).ToArray();
                        var imagenesaeliminar = contexto.Imagenes.Where(x => !numimag.Contains(x.IdImagen) && x.IdProducto == producto.IdProducto).ToList();


                        foreach (var imagen in imagenesaeliminar)
                        {

                            var eliminarImagen = contexto.Imagenes.FirstOrDefault(r => r.IdImagen == imagen.IdImagen && imagen.IdProducto == imagen.IdProducto);
                            if (eliminarImagen != null)
                            {
                                contexto.Imagenes.Remove(eliminarImagen);

                            }


                        }
                        
                    }

                    else
                    {

                        if (contexto.Imagenes.Where(x => x.IdProducto == producto.IdProducto).Count() > 0)
                        {
                            var imagenesaeliminar = contexto.Imagenes.Where(x => x.IdProducto == producto.IdProducto).ToList();


                            foreach (var imagen in imagenesaeliminar)
                            {

                                var eliminarImagen = contexto.Imagenes.FirstOrDefault(r => r.IdImagen == imagen.IdImagen);
                                if (eliminarImagen != null)
                                {
                                    contexto.Imagenes.Remove(eliminarImagen);

                                }


                            }
                        }
                    }




                   
                    contexto.SaveChanges();
                }
            }
        }

        public void EliminarProducto(Guid IdProducto)
        {
            using (ControlPersonalEntities2 contexto = new ControlPersonalEntities2())
            {
                var producto = contexto.Productos.FirstOrDefault(x => x.IdProducto == IdProducto);

                if (producto != null)
                {

                    var imagenes = contexto.Imagenes.Where(x => x.IdProducto == IdProducto);

                    foreach (Imagenes borrarimagen in imagenes)
                    {
                        contexto.Imagenes.Remove(borrarimagen);
                    }



                    contexto.Productos.Remove(producto);
                    contexto.SaveChanges();
                }


            }
        }


        public void AgregarImagenPredeterminada(ProductosDTO ProductosDTO)
        {
            if (ProductosDTO.ListaImagenes == null)
            {
                //Agregar una imagen default
                ProductosDTO.ListaImagenes = new List<ImagenesDTO>()
                {
                    new ImagenesDTO()
                    {
                        UrlImagenChica  = "~/content/imagenes/imagennodisponible_min.jpg",
                        UrlImagenGrande = "~/content/imagenes/imagennodisponible.jpg",
                        Esportada = true
                    },
                    new ImagenesDTO()
                    {
                        UrlImagenChica = "~/content/imagenes/imagennodisponible_min.jpg",
                        UrlImagenGrande = "~/content/imagenes/imagennodisponible.jpg",
                        Esportada = false
                    }
                };
            }
        }





    }
}

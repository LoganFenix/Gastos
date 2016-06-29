using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatosGastos
{
    public class TipoGastos : ITiposdeGastos
    {
        public void AgregarTipogastos(Modelos.TiposDeGastosDTO tipogastosDTO)
        {
            try
            {

                using (ControlPersonalEntities2 contexto = new ControlPersonalEntities2())
                {
                    var nuevoTipogasto = new TiposdeGastos();

                    nuevoTipogasto.DescripcionGasto = tipogastosDTO.DescripcionGasto;
                    nuevoTipogasto.UsuarioAlta = "";
                    nuevoTipogasto.FechaAlta = DateTime.Now;
                    nuevoTipogasto.IdTipoGasto = Guid.NewGuid();
                    contexto.TiposdeGastos.Add(nuevoTipogasto);
                    contexto.SaveChanges();
                   
                }
            }

            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                      .SelectMany(x => x.ValidationErrors)
                      .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);

            }
            catch (DbUpdateException ex)
            {

                //HandleDbUpdateException(ex);

                string mesage = ex.Message;

            }
        }

      
        public Modelos.TiposDeGastosDTO ObtenerTipoGasto(Guid IdTipogasto)
        {
            using (ControlPersonalEntities2 contexto = new ControlPersonalEntities2())
            {
                var tipogasto = contexto.TiposdeGastos.FirstOrDefault(x => x.IdTipoGasto == IdTipogasto);
                
                if (tipogasto != null)
                { 
                return new TiposDeGastosDTO()
                {
                    IdTipoGasto = tipogasto.IdTipoGasto,
                    DescripcionGasto = tipogasto.DescripcionGasto
                };
                }
                else
                {

                    return new TiposDeGastosDTO();

                }

            }
        }

        public List<TiposDeGastosDTO> ObtenerTiposGastos(int currentPage, int ResultadosporPagina, string CampoBusqueda)
        {
            using (ControlPersonalEntities2 contexto = new ControlPersonalEntities2())
            {
                var listatipogastos = new List<TiposDeGastosDTO>();


                var tiposgastos = new List<TiposdeGastos>();


                if (currentPage < 1) currentPage = 1;
                    tiposgastos =
                    (from x in contexto.TiposdeGastos
                     where
                    (String.IsNullOrEmpty(CampoBusqueda) || x.DescripcionGasto.ToUpper().Contains(CampoBusqueda.ToUpper()))
                     select x).OrderBy(x => x.DescripcionGasto).Skip((currentPage - 1) * ResultadosporPagina)
                     .Take(ResultadosporPagina).ToList();




                foreach (var tipogasto in tiposgastos)
                {

                    listatipogastos.Add(new TiposDeGastosDTO()
                        {

                            IdTipoGasto = tipogasto.IdTipoGasto,
                            DescripcionGasto = tipogasto.DescripcionGasto,
                        });
                }
                    
                return listatipogastos;

            }
        }


        public List<TiposDeGastosDTO> ObtenerTiposGastos(Guid IdTipoGasto)
        {
            using (ControlPersonalEntities2 contexto = new ControlPersonalEntities2())
            {
                var listatipogastos = new List<TiposDeGastosDTO>();


                var tiposgastos = new List<TiposdeGastos>();

                    
                    tiposgastos =
                    (from x in contexto.TiposdeGastos
                     select x).OrderBy(x => x.IdTipoGasto == IdTipoGasto).ToList();

                foreach (var tipogasto in tiposgastos)
                {

                    listatipogastos.Add(new TiposDeGastosDTO()
                    {

                        IdTipoGasto = tipogasto.IdTipoGasto,
                        DescripcionGasto = tipogasto.DescripcionGasto,
                    });
                }

                return listatipogastos;

            }
        }



        public int ContarTiposGastos(int Datosporpagina, string CampoBusqueda)
        {
            using (ControlPersonalEntities2 contexto = new ControlPersonalEntities2())
            {
                var listatipogastos = new List<TiposDeGastosDTO>();

              
                var tiposgastos =
                    (from x in contexto.TiposdeGastos
                     where
                    (String.IsNullOrEmpty(CampoBusqueda) || x.DescripcionGasto.ToUpper().Contains(CampoBusqueda.ToUpper()))
                     select x).OrderBy(x => x.DescripcionGasto).ToList();

                int contar = tiposgastos.Count();
                decimal residuo = 0;

                if (contar == 1 && contar < 4)
                {
                    residuo = 0;
                }
                else
                {
                    residuo = contar %= Datosporpagina;
                }

            

                if (residuo > 0)
                {
                    return (tiposgastos.Count() / Datosporpagina) + 1;
                }
                else
                {
                    if (contar == 1 && contar < 4)
                    {
                        return 1;
                    }
                    return tiposgastos.Count() / Datosporpagina;
                }

            }
        }




        public void ActualizarTipoGasto(Modelos.TiposDeGastosDTO tipodegastosdto)
        {
            using (ControlPersonalEntities2 contexto = new ControlPersonalEntities2())
            {
                var tipogasto = contexto.TiposdeGastos.FirstOrDefault(x => x.IdTipoGasto == tipodegastosdto.IdTipoGasto);

                if (tipogasto != null)
                {
                    tipogasto.DescripcionGasto = tipodegastosdto.DescripcionGasto;
                    contexto.SaveChanges();
                }
            }
        }

        public void EliminarTipoGasto(Guid IdTipogasto)
        {
            using (ControlPersonalEntities2 contexto = new ControlPersonalEntities2())
            {
                var tipogasto = contexto.TiposdeGastos.FirstOrDefault(x => x.IdTipoGasto == IdTipogasto);

                if (tipogasto != null)
                {
                    contexto.TiposdeGastos.Remove(tipogasto);
                    contexto.SaveChanges();
                }
               

            }
        }




        public TiposDeGastosDTO ObtenerDatosBusqueda(int pagina, int resultadoporpagina, string textodebusqueda)
        {

         
            var tiposgastos = ObtenerTiposGastos(pagina, resultadoporpagina, textodebusqueda);

            TiposDeGastosDTO datos = new TiposDeGastosDTO();

            datos.ListaTiposGasto = tiposgastos;
            datos.ConteoPagina = ContarTiposGastos(3, textodebusqueda);
            datos.paginasadescontar = ContarTiposGastos(3, textodebusqueda);
            datos.Indice = pagina;


            return datos;



        }


        public List<string> Atucompletado(string campo)
        {
           using (ControlPersonalEntities2 contexto = new ControlPersonalEntities2())
           {

               var prueba =contexto.TiposdeGastos.Where(x => x.DescripcionGasto.StartsWith(campo)).Select(x => x.DescripcionGasto).ToList();
               int  a = prueba.Count();
               return prueba;




           }
        }


        public void AgregarTipo(String tipogastos)
        {
            try
            {

                using (ControlPersonalEntities2 contexto = new ControlPersonalEntities2())
                {
                    var nuevoTipogasto = new TiposdeGastos();

                    nuevoTipogasto.DescripcionGasto = tipogastos;
                    nuevoTipogasto.UsuarioAlta = "";
                    nuevoTipogasto.FechaAlta = DateTime.Now;
                    nuevoTipogasto.IdTipoGasto = Guid.NewGuid();
                    contexto.TiposdeGastos.Add(nuevoTipogasto);
                    contexto.SaveChanges();

                }
            }

            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                      .SelectMany(x => x.ValidationErrors)
                      .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);

            }
            catch (DbUpdateException ex)
            {

                //HandleDbUpdateException(ex);

                string mesage = ex.Message;

            }
        }

    }
}

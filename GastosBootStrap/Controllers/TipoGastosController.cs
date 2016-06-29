using CapaAccesoDatosGastos;
using GastosBootStrap.ReportesXML.Clases;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GastosBootStrap.Controllers
{
    public class TipoGastosController : Controller
    {
        ITiposdeGastos _tiposgastos;

        public TipoGastosController(ITiposdeGastos tiposgastos)
        {
            _tiposgastos = tiposgastos;
        }

        public TipoGastosController() : this(new TipoGastos())
        {
            
        }
       
        public ActionResult Index(string CurrentFilter, string SearchString, int pagina =1)
        {
            var tiposgastos = _tiposgastos.ObtenerDatosBusqueda(pagina, 3, SearchString);

            return View(tiposgastos);
        }

        public ActionResult ListaTiposGasto(string CurrentFilter, string SearchString, int id = 1)
        {
            ViewBag.CurrentFilter = SearchString;
            var tiposgastos = _tiposgastos.ObtenerDatosBusqueda(id, 3, SearchString);
            return PartialView(tiposgastos);

        }



        public ActionResult Buscar(string SearchString)
        {

            var tiposgastos = _tiposgastos.ObtenerDatosBusqueda(1, 3, SearchString);
            return PartialView("ListaTiposGasto", tiposgastos);
        }

        [HttpGet]
        public ActionResult Agregar()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Agregar(TiposDeGastosDTO tiposgastosDTO)
        {
            if (ModelState.IsValid)
            {
                _tiposgastos.AgregarTipogastos(tiposgastosDTO);

                return RedirectToAction("Index");
            }

            return View();
        }

        

        [HttpGet]
        public ActionResult Editar(Guid id)
        {
            var tipogasto = _tiposgastos.ObtenerTipoGasto(id);
            return View(tipogasto);
        }

        [HttpPost]
        public ActionResult Editar(TiposDeGastosDTO tiposgastosDTO)
        {
             if (ModelState.IsValid)
            {

                _tiposgastos.ActualizarTipoGasto(tiposgastosDTO);
                return RedirectToAction("Index");

            }
            return View();

           
        }


        [HttpGet]
        public ActionResult Eliminar(Guid id)
        {
            var tipogasto = _tiposgastos.ObtenerTipoGasto(id);
            return View(tipogasto);

        }

        [HttpPost]
        public ActionResult Eliminar(Guid id, FormCollection collection)
        {

            _tiposgastos.EliminarTipoGasto(id);

            return RedirectToAction("Index");

        }

        public ActionResult pruebaguardar(TiposDeGastosDTO tiposgastosDTO)
        {
            return View();
        }


      
        public ActionResult ReporteTiposGasto()
        {
            string nombre = "CR" + DateTime.Now.ToShortDateString().Replace("/", "-") + "_" + DateTime.Now.ToShortTimeString().Replace(".", "_").Replace(":", "_");
            var workbook = ReporteTipoGastosXML.GenerarReporteAclaraciones();
            return new ExcelResult(workbook, nombre);


        }

        public JsonResult Autocompletado(string term)
        {


            var lista =_tiposgastos.Atucompletado(term);
            return Json(lista, JsonRequestBehavior.AllowGet);

        }

       
    }
}
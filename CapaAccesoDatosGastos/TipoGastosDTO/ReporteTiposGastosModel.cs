using Modelos.TipoGastosModelos;
using System.Collections.Generic;
using System.Linq;

namespace CapaAccesoDatosGastos.TipoGastosDTO
{
    public class ReporteTiposGastosModel
    {
        public static List<ReporteTiposdeGastoDTO> ObtenerDatos()
        {
            using (ControlPersonalEntities2 contexto = new ControlPersonalEntities2())
            {

                List<ReporteTiposdeGastoDTO> llenar = new List<ReporteTiposdeGastoDTO>();



                var tiposgasto = contexto.TiposdeGastos.ToList();

                foreach (var tipos in tiposgasto)
                {

                    var datos = new ReporteTiposdeGastoDTO();

                    datos.Nombre = tipos.DescripcionGasto;

                    llenar.Add(datos);

                }


                return llenar;




            }


        }
    }
}

using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CapaAccesoDatosGastos
{
    public interface ITiposdeGastos
    {

        void AgregarTipogastos(TiposDeGastosDTO tipogastosDTO);
        TiposDeGastosDTO ObtenerTipoGasto(Guid IdConsola);
        List<TiposDeGastosDTO> ObtenerTiposGastos(int pagina, int resultadoporpagina, string textodebusqueda);
        List<TiposDeGastosDTO> ObtenerTiposGastos(Guid IdTipoGasto);
        void ActualizarTipoGasto(TiposDeGastosDTO tipodegastosdto);
        void EliminarTipoGasto(Guid IdConsola);
        int ContarTiposGastos(int PageCount, string Busqueda);
        TiposDeGastosDTO ObtenerDatosBusqueda(int pagina, int resultadoporpagina, string textodebusqueda);
        List<string> Atucompletado(string campo);
        void AgregarTipo(string tipo);


    }
}

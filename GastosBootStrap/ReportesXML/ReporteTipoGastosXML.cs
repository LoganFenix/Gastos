using CapaAccesoDatosGastos.TipoGastosDTO;
using ClosedXML.Excel;

namespace GastosBootStrap
{
    public class ReporteTipoGastosXML
    {

        public static XLWorkbook GenerarReporteAclaraciones()
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Tipos de Gasto");


            // Columnas
            worksheet.Cell("A1").Value = "Nombre";
          

            //Filtros
            worksheet.Range("A1:A1")
                     .Style.Font.SetBold(true)
                     .Font.SetFontSize(14)
                     .Fill.SetBackgroundColor(XLColor.BlueGreen);

            //Datos
            worksheet.Cell("A2").Value = ReporteTiposGastosModel.ObtenerDatos();
            worksheet.RangeUsed().SetAutoFilter();
            worksheet.Columns().AdjustToContents();
            return workbook;
        }
    }
}
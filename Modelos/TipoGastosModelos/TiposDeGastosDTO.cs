using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
   public class TiposDeGastosDTO
   {

        [Key]
        public Guid IdTipoGasto { get; set; }
        [Required(ErrorMessage="Ingrese un nombre para el tipo")]
        public string DescripcionGasto { get; set; }
        public List<TiposDeGastosDTO> ListaTiposGasto { get; set; }
        public int ConteoPagina { get; set; }
        public int paginasadescontar { get; set; }
        public int Indice { get; set; }
    }
}

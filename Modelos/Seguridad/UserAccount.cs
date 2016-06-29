using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Modelos.Seguridad
{
    public class UserAccount
    {
        [Key]
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "Correo Requerido")]
        //[RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        //ErrorMessage = "Formato de Correo incorrecto. Ejemplo:maria@gnail.com")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Nombre de Usuario Requerido")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Se requiere una contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage=("Favor de confirmar la contraseña"))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string[] Roles { get; set; }

       

          

     

     
    }
}

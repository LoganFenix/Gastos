using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace EmoticonPlatzi.Models
{
    public class EmoPicture
    {
        public int Id { get; set; }
        [Display(Name="Nombre")]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000, ErrorMessage ="La ruta supera el tamaño establecido")]
        public string Path { get; set; }
        public virtual ObservableCollection<EmoFace> Faces { get; set; }
    }
}
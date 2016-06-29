using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmoticonPlatzi.Models
{
    public class Home
    {
        public int Id { get; set; }
        public string WelcomeMessage { get; set; }
        public string Footermessage { get; set; } = "Hecho por Phinder";
    }
}
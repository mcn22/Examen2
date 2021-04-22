using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinalProgramacionAvanzada.Utility
{
    public class SendGridOptions
    {
        public const string Section = "Email:SendGridOptions";
        public string Key { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
    }
}

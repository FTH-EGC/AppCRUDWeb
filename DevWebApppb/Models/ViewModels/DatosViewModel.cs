using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevWebApppb.Models;


namespace DevWebApppb.Models.ViewModels
{
    public class DatosViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Edad { get; set; }
        public Nullable<bool> IsActive { get; set; }

    }
}
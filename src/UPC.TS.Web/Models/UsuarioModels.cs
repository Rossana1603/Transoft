using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UPC.TS.Web.Models
{
    public class UsuarioModels
    {
        public int CODUSU { get; set; }
        [Display(Name = "Ingrese contraseña")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string CLAUSU { get; set; }
        [Display(Name = "Repita contraseña")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string CLAUSU_REP { get; set; }
        public string ESTREG { get; set; }
        [Display(Name="Ingrese correo electronico")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Correo invalido")]
        public string LOGUSU { get; set; }
    }
}
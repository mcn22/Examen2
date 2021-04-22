using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelFinalProgramacionAvanzada.Models
{
    public class Usuario : IdentityUser
    {

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [MaxLength(50, ErrorMessage = "El máximo es de 50 caracteres")]
        public string Nombre { get; set; }

        [DisplayName("Apellido")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [MaxLength(50, ErrorMessage = "El máximo es de 50 caracteres")]
        public string Apellido{ get; set; }

        [NotMapped]
        public string Role { get; set; }

        public int? HotelId { get; set; }

        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }
    }
}

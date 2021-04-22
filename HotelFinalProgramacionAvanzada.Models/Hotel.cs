using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelFinalProgramacionAvanzada.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }

        [DisplayName("Nombre del hotel")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [MaxLength(150, ErrorMessage = "El máximo es de 150 caracteres")]
        public string Nombre { get; set; }

        [DisplayName("Descripción")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Descripcion { get; set; }

        [DisplayName("UrlImagen")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string UrlImagen { get; set; }

        [DisplayName("Dirección")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Direccion { get; set; }

        [DisplayName("Ciudad")]
        [Required]
        [MaxLength(30, ErrorMessage = "El máximo es de 30 caracteres")]
        public string Ciudad { get; set; }

        [Required]
        [DisplayName("Teléfono")]
        [MaxLength(50, ErrorMessage = "El máximo es de 50 caracteres")]
        public string Telefono { get; set; }
    } 
}

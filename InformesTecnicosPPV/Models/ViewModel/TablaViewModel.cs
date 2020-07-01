using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InformesTecnicosPPV.Models.ViewModel
{
    public class TablaViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Razon Social")]
        public string RazonSocial { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre de Fantasia")]
        public string NombreFantasia { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Cuit")]
        public string Cuit { get; set; }

        [Required]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Responsable")]
        public string Responsable { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Fecha { get; set; }
    }
}
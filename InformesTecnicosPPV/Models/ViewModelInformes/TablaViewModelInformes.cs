using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InformesTecnicosPPV.Models.ViewModelInformes
{
    public class TablaViewModelInformes
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Informe")]
        public string NombreInforme { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Fecha { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Vencimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Vencimiento { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Archivo")]
        public string ContentType { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tipo Informe")]
        public virtual ICollection<TipoInforme> TipoInforme { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Cliente")]
        public virtual Cliente Cliente { get; set; }
    }
}
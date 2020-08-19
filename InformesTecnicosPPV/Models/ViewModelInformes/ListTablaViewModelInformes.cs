using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InformesTecnicosPPV.Models.ViewModelInformes
{
    public class ListTablaViewModelInformes
    {
        public int Id { get; set; }
        public string NombreInforme { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? Vencimiento { get; set; }
        public byte[] Manual { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public int IdCliente { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<TipoInforme> TipoInforme { get; set; }
    }
}
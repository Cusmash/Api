using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonApiGuate.DTOs
{
    public class OperacionesCajeroesDTO
    {
        public long Id { get; set; }
        public string Concepto { get; set; }
        public string TipoPago { get; set; }
        public double? Monto { get; set; }
        public DateTime DateToperacion { get; set; }
        public long CorteId { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public double? CobroTag { get; set; }
        public string NoReferencia { get; set; }
        public bool StatusCancelacion { get; set; }

        public virtual CortesCajeroesDTO Corte { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MonApiGuate.DTOs
{
    public class CortesCajeroesDTO
    {

        public long Id { get; set; }
        public string NumCorte { get; set; }
        public DateTime DateTapertura { get; set; }
        public DateTime? DateTcierre { get; set; }
        public double? MontoTotal { get; set; }
        public string Comentario { get; set; }
        public string IdCajero { get; set; }

        public virtual List<OperacionesCajeroesDTO> OperacionesCajeroes { get; set; }
    }
}

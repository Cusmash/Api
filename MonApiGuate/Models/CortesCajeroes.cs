using System;
using System.Collections.Generic;

namespace MonApiGuate.Models
{
    public partial class CortesCajeroes
    {
        public CortesCajeroes()
        {
            OperacionesCajeroes = new HashSet<OperacionesCajeroes>();
        }

        public long Id { get; set; }
        public string NumCorte { get; set; }
        public DateTime DateTapertura { get; set; }
        public DateTime? DateTcierre { get; set; }
        public double? MontoTotal { get; set; }
        public string Comentario { get; set; }
        public string IdCajero { get; set; }

        public virtual ICollection<OperacionesCajeroes> OperacionesCajeroes { get; set; }
    }
}

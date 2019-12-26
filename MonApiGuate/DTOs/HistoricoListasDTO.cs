using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonApiGuate.DTOs
{
    public class HistoricoListasDTO
    {
        public long Id { get; set; }
        public string Extension { get; set; }
        public string Tamaño { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Tipo { get; set; }
    }
}

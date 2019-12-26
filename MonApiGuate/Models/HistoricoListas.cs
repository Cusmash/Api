using System;
using System.Collections.Generic;

namespace MonApiGuate.Models
{
    public partial class HistoricoListas
    {
        public long Id { get; set; }
        public string Extension { get; set; }
        public string Tamaño { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Tipo { get; set; }
    }
}

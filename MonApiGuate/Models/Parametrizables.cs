using System;
using System.Collections.Generic;

namespace MonApiGuate.Models
{
    public partial class Parametrizables
    {
        public int Id { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public int Extension { get; set; }
        public string Destinoresidente { get; set; }
        public short Cruzes { get; set; }
        public short Minutos { get; set; }
    }
}

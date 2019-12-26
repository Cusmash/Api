using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonApiGuate.DTOs
{
    public class ParametrizablesDTO
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

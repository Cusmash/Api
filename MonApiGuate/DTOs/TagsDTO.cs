using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonApiGuate.DTOs
{
    public class TagsDTO
    {
        public long Id { get; set; }
        public string NumTag { get; set; }
        public string SaldoTag { get; set; }
        public bool StatusTag { get; set; }
        public bool StatusResidente { get; set; }
        public DateTime DateTtag { get; set; }
        public long CuentaId { get; set; }
        public string IdCajero { get; set; }

        public virtual CuentasTelepeajesDTO Cuenta { get; set; }
    }
}

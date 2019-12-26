using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonApiGuate.DTOs
{
    public class CuentasTelepeajesDTO
    {
        public long Id { get; set; }
        public string NumCuenta { get; set; }
        public string SaldoCuenta { get; set; }
        public string TypeCuenta { get; set; }
        public bool StatusCuenta { get; set; }
        public bool StatusResidenteCuenta { get; set; }
        public DateTime DateTcuenta { get; set; }
        public long ClienteId { get; set; }
        public string IdCajero { get; set; }

        public virtual ClientesDTO Cliente { get; set; }
        public virtual List<TagsDTO> Tags { get; set; }
    }
}

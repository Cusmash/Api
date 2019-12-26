﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonApiGuate.DTOs
{
    public class ClientesDTO
    {

        public long Id { get; set; }
        public string NumCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string EmailCliente { get; set; }
        public string AddressCliente { get; set; }
        public string PhoneCliente { get; set; }
        public bool StatusCliente { get; set; }
        public DateTime DateTcliente { get; set; }
        public string IdCajero { get; set; }
        public string Empresa { get; set; }
        public string Cp { get; set; }
        public string Pais { get; set; }
        public string City { get; set; }
        public string Departamento { get; set; }
        public string Nit { get; set; }
        public string PhoneOffice { get; set; }

        public virtual List<CuentasTelepeajesDTO> CuentasTelepeajes { get; set; }
    }
}
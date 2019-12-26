using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonApiGuate.DTOs
{
    public class HistoricoDTO
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        public string Delegacion { get; set; }
        public string Plaza { get; set; }
        public string Cuerpo { get; set; }
        public string Carril { get; set; }
        public DateTime Fecha { get; set; }
        public string Clase { get; set; }
        public string Evento { get; set; }
        public double Saldo { get; set; }
        public string Operador { get; set; }
        public string SaldoAnterior { get; set; }
        public string SaldoActualizado { get; set; }
    }
}

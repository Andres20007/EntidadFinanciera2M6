using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadFinanciera2M6.Models
{
    public class Transaccion
    {
        public int TransaccionId { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;

        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public int? CuentaOrigenId { get; set; }
        public int? CuentaDestinoId { get; set; }

        public Cuenta CuentaOrigen { get; set; }
        public Cuenta CuentaDestino { get; set; }
    }
}

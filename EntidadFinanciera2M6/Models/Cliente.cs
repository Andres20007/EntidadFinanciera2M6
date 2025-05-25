using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadFinanciera2M6.Models
{
    public class Cliente
    {
        
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }

        public List <Cuenta> Cuentas { get; set;} = new List<Cuenta>();

    }
}

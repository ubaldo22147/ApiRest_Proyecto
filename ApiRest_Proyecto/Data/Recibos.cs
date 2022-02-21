using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest_Proyecto.Data
{
    public class Recibos
    {
        [Key]
        public int Id { get; set; }
        public string Proveedor { get; set; }
        public decimal Monto { get; set; }
        public string Moneda { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
    }
}

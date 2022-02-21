using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest_Proyecto.Models
{
    public class UserLogin
    {
        [Key]

        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty;
    }
}

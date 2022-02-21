using System.ComponentModel.DataAnnotations;

namespace ApiRest_Proyecto.Data
{
    public class UserModel
    {
        [Key]

        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty;
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest_Proyecto.Data
{
    public class AdministracionContext :DbContext
    {
        public AdministracionContext(DbContextOptions<AdministracionContext> options):base(options)
        {
            
        }

        public DbSet<Recibos> Recibos { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}

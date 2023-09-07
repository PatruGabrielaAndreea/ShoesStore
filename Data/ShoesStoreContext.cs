using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShoesStore.Models;

namespace ShoesStore.Data
{
    public class ShoesStoreContext : IdentityDbContext<IdentityUser>
    {
        public ShoesStoreContext (DbContextOptions<ShoesStoreContext> options)
            : base(options)
        {
        }

        public DbSet<ShoesStore.Models.Brand> Brand { get; set; } = default!;

        public DbSet<ShoesStore.Models.Comanda> Comanda { get; set; }

        public DbSet<ShoesStore.Models.CosCumparaturi> CosCumparaturi { get; set; }

        public DbSet<ShoesStore.Models.Detalii_Produs> Detalii_Produs { get; set; }

        public DbSet<ShoesStore.Models.Produs> Produs { get; set; }

        public DbSet<ShoesStore.Models.User> User { get; set; }
    }
}

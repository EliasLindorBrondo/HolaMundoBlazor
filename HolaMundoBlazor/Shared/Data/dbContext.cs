
using HolaMundoBlazor.BD.Data.Entidades;
using HolaMundoBlazor.BD.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaMundoBlazor.BD.Data
{
    public class Jscontext : DbContext
    {
        public DbSet<Pais> Paises { get; set; }

        public DbSet<Provincia> Provincias { get; set; }
        public Jscontext(DbContextOptions<Jscontext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFks = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership
                 && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFks)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }

    }
}

using Microsoft.EntityFrameworkCore;
using WebApiFinalTitoMatias.Models;

namespace WebApiFinalTitoMatias.Data
{
    public class DbHospitalContext : DbContext
    {
        public DbHospitalContext() { }
        public DbHospitalContext (DbContextOptions<DbHospitalContext> options) : base(options) { }

        public virtual DbSet <Doctor> Doctores { get; set; }
        public virtual DbSet<Hospital> Hospitales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>().HasKey(e => e.Doctor_No).IsClustered(false);
            modelBuilder.Entity<Doctor>().Property(e => e.Apellido).HasColumnType("varchar(50)").IsRequired();
            modelBuilder.Entity<Doctor>().Property(e => e.Especialidad).HasColumnType("varchar(50)").IsRequired();

            modelBuilder.Entity<Hospital>().HasKey(e => e.Hospital_Cod).IsClustered(false);
            modelBuilder.Entity<Hospital>().Property(e => e.Nombre).HasColumnType("varchar(50)").IsRequired();
            modelBuilder.Entity<Hospital>().Property(e => e.Direccion).HasColumnType("varchar(50)").IsRequired();
            modelBuilder.Entity<Hospital>().Property(e => e.Telefono).HasColumnType("varchar(50)").IsRequired();
        }
    }
}

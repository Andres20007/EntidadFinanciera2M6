using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadFinanciera2M6.Models;

namespace EntidadFinanciera2M6.Data
{
    /// <summary>
    /// Contexto de base de datos para la entidad financiera
    /// </summary>
    public class EntidadFinancieraContext : DbContext
    {
        // Propiedades DbSet para las entidades
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }

        /// <summary>
        /// Configura la conexión a la base de datos
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=DESKTOP-S3R9TOH\SQLEXPRESS;Database=EntidadFinanciera2M6;Trusted_Connection=True;TrustServerCertificate=True;",
                    options => options.EnableRetryOnFailure(
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null));
            }
        }

        /// <summary>
        /// Configura el modelo de datos y sus relaciones
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de filtros globales
            modelBuilder.Entity<Cuenta>().HasQueryFilter(c => c.Activa);

            // Configuración de índices
            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.Identificacion)
                .IsUnique();

            modelBuilder.Entity<Cuenta>()
                .HasIndex(c => c.NumeroCuenta)
                .IsUnique();

            // Configuración de relaciones
            modelBuilder.Entity<Cuenta>()
                .HasOne(c => c.Cliente)
                .WithMany(c => c.Cuentas)
                .HasForeignKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaccion>()
                .HasOne(t => t.CuentaOrigen)
                .WithMany()
                .HasForeignKey(t => t.CuentaOrigenId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaccion>()
                .HasOne(t => t.CuentaDestino)
                .WithMany()
                .HasForeignKey(t => t.CuentaDestinoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

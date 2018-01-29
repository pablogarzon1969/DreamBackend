using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Data.Context
{
    public class ContextDB : DbContext
    {
        public ContextDB()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();
            String logFileConnection = configuration["ConnectionStrings:DefaultConnection"];
            optionsBuilder.UseSqlServer(logFileConnection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ciudad>()
           .HasOne(d => d.pais)
           .WithMany()
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Hotel>()
         .HasOne(d => d.empresa)
         .WithMany()
         .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Usuario>()
            .HasOne(d => d.rol)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Permiso>()
             .HasOne(d => d.rol)
             .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Rol>()
           .HasOne(d => d.aplicacion)
           .WithMany()
          .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsuarioRol>()
           .HasOne(d => d.rol)
           .WithMany()
          .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsuarioRol>()
             .HasOne(d => d.usuario)
             .WithMany()
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReservaHabitaciones>()
         .HasOne(d => d.Ciudad)
         .WithMany()
         .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReservaHabitaciones>()
       .HasOne(d => d.Hotel)
       .WithMany()
       .OnDelete(DeleteBehavior.Restrict);

        }

        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<TipoNovedad> TipoNovedades { get; set; }
        public virtual DbSet<Aplicacion> Aplicaciones { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<UsuarioRol> UsuarioRoles { get; set; }
        public virtual DbSet<Permiso> Permisos { get; set; }
        public virtual DbSet<PermisoRecurso> PerfilRecursos { get; set; }

        public virtual DbSet<TipoIdentificacion> TipoIdentificacion { get; set; }
        public virtual DbSet<TipoEmpresa> TipoEmpresa { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<ReservaHabitaciones> ReservaHabitaciones { get; set; }
        public virtual DbSet<ReservaHabitacionCierre> ReservaHabitacionCierre { get; set; }
        public virtual DbSet<ReservaHabitacionCierreVoucher> ReservaHabitacionCierreVoucher { get; set; }

        public virtual DbSet<HabitacionesDisponibles> HabitacionesDisponibles { get; set; }

    }
}
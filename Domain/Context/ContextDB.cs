using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Context
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Aplicacion> Aplicaciones { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<PermisoRecurso> PerfilRecursos { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<UsuarioRol> UsuarioRoles { get; set; }
    }
}
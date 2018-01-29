using Data.Context;
using Entities;
using System;

namespace Data
{
    public class UnitOfWork : IDisposable
    {
        private ContextDB Context;
        private GenericRepository<Usuario> clienteRepository;
        private GenericRepository<Aplicacion> aplicacionRepository;
        private GenericRepository<Rol> rolRepository;
        private GenericRepository<Permiso> permisoRepository;
        private GenericRepository<PermisoRecurso> permisoRecursoRepository;
        private GenericRepository<TipoNovedad> tipoNovedadRecursoRepository;
        private GenericRepository<Pais> paisRecursoRepository;
        private GenericRepository<Ciudad> ciudadRecursoRepository;
        private GenericRepository<HabitacionesDisponibles> habitacionDispobleRespository;
        private GenericRepository<Hotel> hotelRespository;
        private GenericRepository<Empresa> empresaRespository;
        private GenericRepository<TipoEmpresa> tipoEmpresaRecursoRepository;


        private GenericRepository<ReservaHabitaciones> reservaHabitacionesRepository;


        public UnitOfWork()
        {
            Context = new ContextDB();
        }
   

        public GenericRepository<Usuario> UsuarioRepository
        {
            get
            {
                if (this.clienteRepository == null)
                {
                    this.clienteRepository = new GenericRepository<Usuario>(Context);
                }
                return clienteRepository;
            }
        }

        public GenericRepository<Aplicacion> AplicacionRepository
        {
            get
            {
                if (this.aplicacionRepository == null)
                {
                    this.aplicacionRepository = new GenericRepository<Aplicacion>(Context);
                }
                return aplicacionRepository;
            }
        }

        public GenericRepository<Rol> RolRepository
        {
            get
            {
                if (this.rolRepository == null)
                {
                    this.rolRepository = new GenericRepository<Rol>(Context);
                }
                return rolRepository;
            }
        }

        public GenericRepository<Permiso> PermisoRepository
        {
            get
            {
                if (this.permisoRepository == null)
                {
                    this.permisoRepository = new GenericRepository<Permiso>(Context);
                }
                return permisoRepository;
            }
        }

        public GenericRepository<PermisoRecurso> PerfilRecursoRepository
        {
            get
            {
                if (this.permisoRecursoRepository == null)
                {
                    this.permisoRecursoRepository = new GenericRepository<PermisoRecurso>(Context);
                }
                return permisoRecursoRepository;
            }
        }

        public GenericRepository<TipoNovedad> TipoNovedadRecursoRepository
        {
            get
            {
                if (this.tipoNovedadRecursoRepository == null)
                {
                    this.tipoNovedadRecursoRepository = new GenericRepository<TipoNovedad>(Context);
                }
                return tipoNovedadRecursoRepository;
            }
        }

        public GenericRepository<TipoEmpresa> TipoEmpresaRecursoRepository
        {
            get
            {
                if (this.tipoEmpresaRecursoRepository == null)
                {
                    this.tipoEmpresaRecursoRepository = new GenericRepository<TipoEmpresa>(Context);
                }
                return tipoEmpresaRecursoRepository;
            }
        }

        public GenericRepository<Pais> PaisRecursoRepository
        {
            get
            {
                if (this.paisRecursoRepository == null)
                {
                    this.paisRecursoRepository = new GenericRepository<Pais>(Context);
                }
                return paisRecursoRepository;
            }
        }

        public GenericRepository<Ciudad> CiudadRecursoRepository
        {
            get
            {
                if (this.ciudadRecursoRepository == null)
                {
                    this.ciudadRecursoRepository = new GenericRepository<Ciudad>(Context);
                }
                return ciudadRecursoRepository;
            }
        }

        public GenericRepository<HabitacionesDisponibles> HabitacionDispobleRespository
        {
            get
            {
                if (this.habitacionDispobleRespository == null)
                {
                    this.habitacionDispobleRespository = new GenericRepository<HabitacionesDisponibles>(Context);
                }
                return habitacionDispobleRespository;
            }
        }

        public GenericRepository<Hotel> HotelRespository
        {
            get
            {
                if (this.hotelRespository == null)
                {
                    this.hotelRespository = new GenericRepository<Hotel>(Context);
                }
                return hotelRespository;
            }
        }

        public GenericRepository<Empresa> EmpresaRespository
        {
            get
            {
                if (this.empresaRespository == null)
                {
                    this.empresaRespository = new GenericRepository<Empresa>(Context);
                }
                return empresaRespository;
            }
        }

        public GenericRepository<ReservaHabitaciones> ReservaHabitacionesRepository
        {
            get
            {
                if (this.reservaHabitacionesRepository == null)
                {
                    this.reservaHabitacionesRepository = new GenericRepository<ReservaHabitaciones>(Context);
                }
                return reservaHabitacionesRepository;
            }
        }



        public void Save()
        {
            Context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}

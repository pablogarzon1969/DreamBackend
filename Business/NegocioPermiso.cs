using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    /// <summary>
    /// Permite gestionar las operaciones de crud del perfil
    /// </summary>
    public class NegocioPermiso 
    {

        private UnitOfWork unit;

        public NegocioPermiso()
        {
            unit = new UnitOfWork();
        }

        /// <summary>
        /// Permite obtener los permisos que hacen parte del modulo de autorizacion
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Permiso> ObtenerPermisos()
        {
            IEnumerable<Permiso> permisos;
            return permisos = unit.PermisoRepository.Get().AsEnumerable();
        }

        /// <summary>
        /// Permite crear el permiso que tendran el usuario
        /// </summary>
        /// <param name="perfil"></param>
        /// <returns></returns>
        public Permiso CrearPerfil(Permiso permiso)
        {
            unit.PermisoRepository.Insert(permiso);
            unit.Save();
            return permiso;
        }

        /// <summary>
        /// Permite eliminar el perfil que utilizara la autorizacion
        /// </summary>
        /// <param name="id"></param>
        public void EliminarPermiso(Int32 id)
        {
            var rol = unit.PermisoRepository.GetByID(id);
            if (rol != null)
            {
                unit.PermisoRepository.Delete(rol);
                unit.Save();
            }
        }
        /// <summary>
        /// Permite actualizar la informacion correspondiente al permiso creado para el modulo de autorizacion
        /// </summary>
        /// <param name="perfil"></param>
        /// <returns></returns>
        public String ActualizarPerffil(Permiso permiso)
        {
            String msg;
            var permisoconsulta = unit.PermisoRepository.GetByID(permiso.Id);

            if (permisoconsulta == null)
            {
                msg = "Permiso no encontrado";
            }
            else
            {
                permisoconsulta.NombrePermiso = permiso.NombrePermiso;
                permisoconsulta.Activo = permiso.Activo;

                unit.PermisoRepository.Update(permisoconsulta);
                unit.Save();
                msg = "Dato Guardado satifactoriamente";
            }
            return msg;
        }
    }
}

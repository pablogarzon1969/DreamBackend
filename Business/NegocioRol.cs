using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    /// <summary>
    /// Permite gestionar las operaciones de crud en el rol
    /// </summary>
    public class NegocioRol
    {
        private UnitOfWork unit;

        public NegocioRol()
        {
            unit = new UnitOfWork();
        }

        /// <summary>
        /// Permite obtener los roles que hacen parte del modulo de autorizacion
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Rol> GetRolsByApplication(Int32 IdApplication)
        {
            IEnumerable<Rol> rol;
            return rol = unit.RolRepository.Get(x => x.aplicacion.Id == IdApplication);
        }

        /// <summary>
        /// Permite crear el rol que tendran el usuario
        /// </summary>
        /// <param name="rol"></param>
        /// <returns></returns>
        public Rol CreateRol(Rol rol)
        {
            unit.RolRepository.Insert(rol);
            unit.Save();
            return rol;
        }

        /// <summary>
        /// Permite eliminar el rol que utilizara la autorizacion
        /// </summary>
        /// <param name="id"></param>
        public void DeleteRol(Int32 id)
        {
            var rol = unit.RolRepository.GetByID(id);
            if (rol != null)
            {
                unit.RolRepository.Delete(rol);
                unit.Save();
            }
        }
        /// <summary>
        /// Permite actualizar la informacion correspondiente al rol creado para el modulo de autorizacion
        /// </summary>
        /// <param name="rol"></param>
        /// <returns></returns>
        public String UpdateRol(Rol rol)
        {
            String msg;
            var rolconsulta = unit.RolRepository.GetByID(rol.Id);

            if (rolconsulta == null)
            {
                msg = "El Rol no encontrada";
            }
            else
            {
                rolconsulta.NombreRol = rol.NombreRol;
                rolconsulta.Activo = rol.Activo;

                unit.RolRepository.Update(rolconsulta);
                unit.Save();
                msg = "Dato Guardado satifactoriamente";
            }
            return msg;
        }
    }
}

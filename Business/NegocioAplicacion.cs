using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    /// <summary>
    /// Permite gestionar las operaciones de crud en la aplicacion
    /// </summary>
    public class NegocioAplicacion
    {
        private UnitOfWork unit;

        public NegocioAplicacion()
        {
            unit = new UnitOfWork();
        }

        /// <summary>
        /// Permite obtener las aplicaciones que hacen parte del modulo de autorizacion
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Aplicacion> GetApplications()
        {
            IEnumerable<Aplicacion> aplicacion;
            return aplicacion = unit.AplicacionRepository.Get().AsEnumerable();
        }

        /// <summary>
        /// Permite obtener las aplicion por el id
        /// </summary>
        /// <param name="IdApplication"></param>
        /// <returns></returns>
        public Aplicacion GetApplicationById(Int32 IdApplication)
        {
            var application = unit.AplicacionRepository.FindSingleBy(x => x.Id == IdApplication);
            if (application == null)
                return null;
            return application;
        }

        /// <summary>
        /// Permite crear la aplicacion que utilizara la autorizacion
        /// </summary>
        /// <param name="aplicacion"></param>
        /// <returns></returns>
        public Aplicacion ApplicationCreate(Aplicacion aplicacion)
        {
            unit.AplicacionRepository.Insert(aplicacion);
            unit.Save();
            return aplicacion;
        }

        /// <summary>
        /// Permite eliminar la aplicacion que utilizara la autorizacion
        /// </summary>
        /// <param name="id"></param>
        public void DeleteApplication(Int32 id)
        {
            var application = unit.AplicacionRepository.GetByID(id);
            if (application != null)
            {
                unit.AplicacionRepository.Delete(application);
                unit.Save();
            }
        }
        /// <summary>
        /// Permite actualizar la informacion correspondiente a la aplicacion creada para el modulo de autorizacion
        /// </summary>
        /// <param name="aplicacion"></param>
        /// <returns></returns>
        public String UpdateApplication(Aplicacion application)
        {
            String msg;
            var aplicacionconsulta = unit.AplicacionRepository.GetByID(application.Id);

            if (aplicacionconsulta == null)
            {
                msg = "Aplicacion no encontrada";
            }
            else
            {
                aplicacionconsulta.NombreAplicacion = application.NombreAplicacion;
                aplicacionconsulta.Activo = application.Activo;

                unit.AplicacionRepository.Update(aplicacionconsulta);
                unit.Save();
                msg = "Dato Guardado satifactoriamente";
            }
            return msg;
        }
    }
}

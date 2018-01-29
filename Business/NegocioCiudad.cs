using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    /// <summary>
    /// 
    /// </summary>
    public class NegocioCiudad
    {
        private UnitOfWork unit;

        /// <summary>
        /// 
        /// </summary>
        public NegocioCiudad()
        {
            unit = new UnitOfWork();
        }


        /// <summary>
        /// Permite obtener los paises
        /// </summary>
        /// <returns></returns>
        //public IEnumerable<Ciudad> GetCitiesByCountry(Int32 IdCountry)
        //{
        //    IEnumerable<Ciudad> countries;
        //    return countries = unit.CiudadRecursoRepository.Get(x => x.pais.Id == IdCountry);
        //}



        /// <summary>
        /// Permite obtener las ciudades por pais
        /// </summary>
        /// <returns></returns>
        public IEnumerable<dynamic> GetCitiesByCountry(Int32 IdCountry)
        {
            var cities = from fpcity in unit.CiudadRecursoRepository.Get()

                         where fpcity.paisId == IdCountry
                         select new
                         {
                             Id = fpcity.Id,
                             name = fpcity.Nombre,
                             active = fpcity.Activo
                         };
            return cities.ToList();
        }


        /// <summary>
        /// Permite crear la ciudad
        /// </summary>
        /// <param name="typeNovelty"></param>
        /// <returns></returns>
        public Ciudad CityCreate(Ciudad city)
        {
            unit.CiudadRecursoRepository.Insert(city);
            unit.Save();
            return city;
        }

        /// <summary>
        /// Permite eliminar la ciudad
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCity(Int32 id)
        {
            var city = unit.CiudadRecursoRepository.GetByID(id);
            if (city != null)
            {
                unit.CiudadRecursoRepository.Delete(city);
                unit.Save();
            }
        }

        /// <summary>
        /// Permite actualizar la informacion correspondiente a la ciudad
        /// </summary>
        /// <param name="typeNoveltie"></param>
        /// <returns></returns>
        public String UpdateCity(Ciudad city)
        {
            String msg;
            var citySearch = unit.CiudadRecursoRepository.GetByID(city.Id);

            if (citySearch == null)
            {
                msg = "La ciudad no se encuentra";
            }
            else
            {
                citySearch.Nombre = city.Nombre;
                citySearch.Activo = city.Activo;
                citySearch.Id = city.Id;
                unit.CiudadRecursoRepository.Update(citySearch);
                unit.Save();
                msg = "Dato Guardado satifactoriamente";
            }
            return msg;
        }
    }
}

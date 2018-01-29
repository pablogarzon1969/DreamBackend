using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class NegocioPais
    {
        private UnitOfWork unit;

        public NegocioPais()
        {
            unit = new UnitOfWork();
        }

        /// <summary>
        /// Permite obtener los paises
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Pais> GetCountries()
        {
            IEnumerable<Pais> countries;
            return countries = unit.PaisRecursoRepository.Get().AsEnumerable();
        }

        public Pais GetCountryById(Int32 Id)
        {
            var country = unit.PaisRecursoRepository.FindSingleBy(x => x.Id == Id);
            if (country == null)
                return null;
            return country;
        }

        /// <summary>
        /// Permite crear el pais
        /// </summary>
        /// <param name="typeNovelty"></param>
        /// <returns></returns>
        public Pais CountryCreate(Pais country) 
        {
            unit.PaisRecursoRepository.Insert(country);
            unit.Save();
            return country;
        }

        /// <summary>
        /// Permite eliminar el pais
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCountry(Int32 id)
        {
            var country = unit.PaisRecursoRepository.GetByID(id);
            if (country != null)
            {
                unit.PaisRecursoRepository.Delete(country);
                unit.Save();
            }
        }

        /// <summary>
        /// Permite actualizar la informacion correspondiente al pais
        /// </summary>
        /// <param name="typeNoveltie"></param>
        /// <returns></returns>
        public String UpdateCountry(Pais country)
        {
            String msg;
            var countrySearch = unit.PaisRecursoRepository.GetByID(country.Id);

            if (countrySearch == null)
            {
                msg = "El pais no se encuentra";
            }
            else
            {
                countrySearch.Nombre = country.Nombre;
                countrySearch.Activo = country.Activo;
                countrySearch.Id = country.Id;
                unit.PaisRecursoRepository.Update(countrySearch);
                unit.Save();
                msg = "Dato Guardado satifactoriamente";
            }
            return msg;
        }
    }
}

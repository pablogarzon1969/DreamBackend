using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business;
using Microsoft.Extensions.Configuration;
using Entities;

namespace Dream.Controllers
{
    //[Produces("application/json")]
    [Route("api/Country")]
    public class CountryController : Controller
    {

        NegocioPais businessCountry;
        private readonly IConfiguration _Iconfiguration;
        public CountryController(IConfiguration iconfiguration)
        {
            businessCountry = new NegocioPais();
            _Iconfiguration = iconfiguration;
        }

        /// <summary>
        /// Permite obtener los paises
        /// </summary>
        /// <returns>las informacion de los paises</returns>
        [HttpGet]
        public IEnumerable<Pais> GetTCountries()
        {
            return businessCountry.GetCountries();
        }

        /// <summary>
        /// Permite obtener el pais por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>la informaicon del pais</returns>
        [HttpGet("{id}", Name = "GetCountryById")]
        public Pais GetCountryById(int id)
        {
            return businessCountry.GetCountryById(id);
        }

        /// <summary>
        /// Permite realizar la creacion del pais
        /// </summary>
        /// <param name="Entcountry"></param>
        [HttpPost]
        public void Post([FromBody]dynamic Entcountry)
        {
            if (Entcountry != null)
            {
                var name = Entcountry.name.Value;
                var active = Entcountry.active.Value;
                Pais country = new Pais
                {
                     Activo = active,
                     Nombre = name
                };

                businessCountry.CountryCreate(country);
            }
        }

        /// <summary>
        /// Permite actualziar la informacion del pais
        /// </summary>
        /// <param name="Entcountry"></param>
        [HttpPut]
        public void Put([FromBody]dynamic Entcountry)
        {
            if (Entcountry != null)
            {
                var name = Entcountry.name.Value;
                var active = Entcountry.active.Value;
                var id = Entcountry.id.Value;
                Pais country = new Pais
                {
                    Activo = active,
                    Nombre = name,
                    Id=Convert.ToInt32(id)
                };
                businessCountry.UpdateCountry(country);
            }
        }

        /// <summary>
        /// Pemite eliminar el pais seleccionado
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(Int32 id)
        {
            businessCountry.DeleteCountry(id);
        }
    }
}

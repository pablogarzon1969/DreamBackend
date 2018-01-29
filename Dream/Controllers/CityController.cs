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
    [Produces("application/json")]
    [Route("api/City")]
    public class CityController : Controller
    {
        NegocioCiudad businessCity;
        private readonly IConfiguration _Iconfiguration;
        public CityController(IConfiguration iconfiguration)
        {
            businessCity = new NegocioCiudad();
            _Iconfiguration = iconfiguration;
        }

        /// <summary>
        /// Permite obtener las ciudades por el pais
        /// </summary>
        /// <param name="idCountry"></param>
        /// <returns>las ciudades por pais</returns>
        [HttpGet]
        public IEnumerable<dynamic> GetTCitiesByCountry(Int32 idCountry)
        {
            return businessCity.GetCitiesByCountry(idCountry);
        }

        /// <summary>
        /// Permite crea la ciudad
        /// </summary>
        /// <param name="Entcity"></param>
        [HttpPost]
        public void Post([FromBody]dynamic Entcity)
        {
            if (Entcity != null)
            {
                var name = Entcity.name.Value;
                var active = Entcity.active.Value;
                var idCountry = Entcity.idCountry.Value;
                Ciudad city = new Ciudad
                {
                    Activo = active,
                    Nombre = name,
                    paisId= Convert.ToInt32(idCountry)
                };

                businessCity.CityCreate(city);
            }
        }

        /// <summary>
        /// Permite actualzar la informacion de la ciudad
        /// </summary>
        /// <param name="Entcity"></param>
        [HttpPut]
        public void Put([FromBody]dynamic Entcity)
        {
            if (Entcity != null)
            {
                var name = Entcity.name.Value;
                var active = Entcity.active.Value;
                var id = Entcity.id.Value;
                Ciudad city = new Ciudad
                {
                    Id = Convert.ToInt32(id),
                    Activo = active,
                    Nombre = name,
                    
                };
                businessCity.UpdateCity(city);
            }
        }

        /// <summary>
        /// Permite eliminar la ciudad seleccionada
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(Int32 id)
        {
            businessCity.DeleteCity(id);
        }
    }
}

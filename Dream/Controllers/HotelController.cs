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
    [Route("api/Hotel")]
    public class HotelController : Controller
    {

        NegocioHotel businessHotel;
        private readonly IConfiguration _Iconfiguration;
        public HotelController(IConfiguration iconfiguration)
        {
            businessHotel = new NegocioHotel();
            _Iconfiguration = iconfiguration;
        }

        [HttpGet]
        public IEnumerable<dynamic> GetHotelsByCity(Int32 idCity)
        {
            return businessHotel.GetHotelsByCity(idCity);
        }

        //GET: api/Rol/5
        [HttpGet("{id}")]
        public IEnumerable<dynamic> Get(Int32 id)
        {
            return businessHotel.GetHotelByUser(id);
        }

        // POST: api/Hotel
        [HttpPost]
        public void Post([FromBody]dynamic Enthotel)
        {
            if (Enthotel != null)
            {
                var name = Enthotel.name.Value;
                var idCity = Enthotel.idCity.Value;
                var idEmpresa = Enthotel.idEmpresa.Value;
                Hotel hotel = new Hotel
                {
                    IdCiudad = Convert.ToInt32(idCity),
                    Nombre = name,
                    IdEmpresa = Convert.ToInt32(idEmpresa)
                };

                businessHotel.HotelCreate(hotel);
            }
        }


        /// <summary>
        /// Permite actualzar la informacion del hotel
        /// </summary>
        /// <param name="Enthotel"></param>
        [HttpPut]
        public void Put([FromBody]dynamic Enthotel)
        {
            if (Enthotel != null)
            {
                var name = Enthotel.name.Value;
                var id = Enthotel.id.Value;
                Hotel hotel = new Hotel
                {
                    Id = Convert.ToInt32(id),
                    Nombre = name,
                };
                businessHotel.UpdateHotel(hotel);
            }
        }

    }
}

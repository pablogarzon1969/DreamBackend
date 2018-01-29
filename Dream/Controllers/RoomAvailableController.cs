using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Business;
using Entities;

namespace Dream.Controllers
{
    [Produces("application/json")]
    //[Route("api/RoomAvailable")]
    public class RoomAvailableController : Controller
    {

        NegocioHabitacionDisponible businessRoomAvailable;
        private readonly IConfiguration _Iconfiguration;
        public RoomAvailableController(IConfiguration iconfiguration)
        {
            businessRoomAvailable = new NegocioHabitacionDisponible();
            _Iconfiguration = iconfiguration;
        }

        [HttpGet]
        [Route("RoomAvailable")]
        public IEnumerable<HabitacionesDisponibles> GetRoomsAvailables()
        {
            return businessRoomAvailable.GetRoomsAvailables();
        }


        [HttpGet]
        [Route("RoomAvailable/Hotel/user/{idUser}")]
        public IEnumerable<dynamic> GetRoomsAvailablesHotelByUser(Int32 idUser)
        {
            return businessRoomAvailable.GetRoomsAvailablesHotelByUser(idUser);
        }


        [HttpGet]
        [Route("RoomAvailable/Hotel/{idHotel}")]
        public HabitacionesDisponibles GetRoomsAvailablesByHotel(Int32 idHotel)
        {
            return businessRoomAvailable.GetRoomsAvailablesByHotel(idHotel);
        }

        [HttpGet]
        [Route("TotalRoomAvailable/Hotel/{idHotel}")]
        public int? GetTotalRoomsAvailablesByHotel(Int32 idHotel)
        {
            int? total = 0;
            foreach(HabitacionesDisponibles habitaciondisponible in businessRoomAvailable.GetTotalRoomsAvailablesByHotel(idHotel))
            {

                total = habitaciondisponible.TotalHabitacionesDisponibles;
            }
            return total;
        }


        [HttpGet]
        [Route("ValidatedRoomAvailable/Hotel/{idHotel}")]
        public Boolean GetValidatedRoomAvailableHotelByDay(int idHotel)
        {
            return businessRoomAvailable.GetValidatedRoomAvailableHotelByDay(idHotel);
        }

        [HttpPost]
        [Route("RoomAvailable")]
        public void Post([FromBody]dynamic EntroomAvailable)
        {
            if (EntroomAvailable != null)
            {
                var TotalHabitacionesDisponibles = EntroomAvailable.totalHabitacionesDisponibles.Value;
                var idHotel = EntroomAvailable.idHotel.Value;
                HabitacionesDisponibles roomAvailable = new HabitacionesDisponibles
                {
                     
                      TotalHabitacionesDisponibles = Convert.ToInt32(TotalHabitacionesDisponibles),
                       IdHotel=Convert.ToInt32(idHotel)
                };

                businessRoomAvailable.RoomAvailableCreate(roomAvailable);
            }
        }


        [HttpPut]
        [Route("RoomAvailable")]
        public void Put([FromBody]dynamic EntroomAvailable)
        {
            var id = EntroomAvailable.id.Value;
            var totalHabitacionesDisponibles = EntroomAvailable.totalHabitacionesDisponibles.Value;
            var fecha = EntroomAvailable.fecha.Value;
            HabitacionesDisponibles roomAvailable = new HabitacionesDisponibles
            {

                TotalHabitacionesDisponibles = Convert.ToInt32(totalHabitacionesDisponibles),
                Id = Convert.ToInt32(id),
                Fecha= Convert.ToDateTime(fecha)
            };
            businessRoomAvailable.UpdateRoomAvailable(roomAvailable);
        }

        [HttpDelete]
        [Route("RoomAvailable/{id}")]
        public void Delete(Int32 id)
        {
            businessRoomAvailable.DeleteRoomAvailable(id);
        }
    }
}

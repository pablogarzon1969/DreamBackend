using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Dream.Controllers
{
    [Produces("application/json")]
    //  [Route("api/BookHotelRoom")]
    public class BookHotelRoomController : Controller
    {
        NegocioReservaHotelHabitacion businessBookRoom;
        NegocioHabitacionDisponible businessRoomAvailable;
        private readonly IConfiguration _Iconfiguration;
        public BookHotelRoomController(IConfiguration iconfiguration)
        {
            businessBookRoom = new NegocioReservaHotelHabitacion();
            businessRoomAvailable = new NegocioHabitacionDisponible();
            _Iconfiguration = iconfiguration;
        }

        [HttpGet]
        [Route("BookRoom")]
        public IEnumerable<ReservaHabitaciones> GetBooksRoom()
        {
            return businessBookRoom.GetBookRoomHotel();
        }

        [HttpGet]
        [Route("BookRoom/Hotel/{idHotel}")]
        public IEnumerable<ReservaHabitaciones> GetBookRoomByHotel(Int32 idHotel)
        {
            return businessBookRoom.GetBookRoomByHotel(idHotel);
        }

        [HttpGet]
        [Route("TotalBookRoom/Hotel/{idHotel}")]
        public int GetTotalBookRoomByHotel(Int32 idHotel)
        {
            return businessBookRoom.GetTotalBookRoomByHotel(idHotel);
        }

        [HttpGet]
        [Route("ValidatedBookRoom/{idHotel}")]
        public Boolean GetValidatedBookRoom(int idHotel)
        {
            return businessBookRoom.GetValidatedBookRoom(idHotel);
        }

        [HttpPost]
        [Route("BookRoom")]
        public string Post([FromBody]dynamic EntbookRoom)
        {
            int? totalHabitacionesDisponibles = 0;
            int idHabitacion = 0;
            if (EntbookRoom != null)
            {
                var NumeroHabitacionReserva = EntbookRoom.numeroHabitacionReservada.Value;
                var NumeroPasajeros = EntbookRoom.numeroPasajeros.Value;
                var idHotel = EntbookRoom.idHotel.Value;
                var idCiudad = EntbookRoom.idCity.Value;
                var Mascota = EntbookRoom.mascota.Value;
                var Fecha = DateTime.Now;
                ReservaHabitaciones bookRoom = new ReservaHabitaciones
                {

                    NumeroHabitacionReservada = Convert.ToInt32(NumeroHabitacionReserva),
                    IdHotel = Convert.ToInt32(idHotel),
                    IdCiudad = Convert.ToInt32(idCiudad),
                    NumeroPasajeros = Convert.ToInt32(NumeroPasajeros),
                    Mascota = Convert.ToBoolean(Mascota),
                    Fecha = Convert.ToDateTime(Fecha)
                };

                businessBookRoom.BookRoomCreate(bookRoom);
                foreach (HabitacionesDisponibles habitacionDisplonible in businessRoomAvailable.GetTotalRoomsAvailablesByHotel(Convert.ToInt32(idHotel)))
                {
                    totalHabitacionesDisponibles = habitacionDisplonible.TotalHabitacionesDisponibles;
                    idHabitacion = habitacionDisplonible.Id;


                }

                HabitacionesDisponibles habitacionDisponible = new HabitacionesDisponibles { TotalHabitacionesDisponibles = totalHabitacionesDisponibles - Convert.ToInt32(NumeroHabitacionReserva), Id = idHabitacion, IdHotel = Convert.ToInt32(idHotel) };
                businessRoomAvailable.UpdateRoomAvailable(habitacionDisponible);



            }
            return "Registro creado con exito";
        }


        [HttpPut]
        [Route("BookRoom")]
        public void Put([FromBody]ReservaHabitaciones bookRoom)
        {
            businessBookRoom.UpdateBookRoom(bookRoom);
        }

        [HttpDelete]
        [Route("BookRoom/{id}")]
        public void Delete(Int32 id)
        {
            businessBookRoom.DeleteBookRoom(id);
        }
    }
}

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
   public class NegocioReservaHotelHabitacion
    {
        private UnitOfWork unit;

        public NegocioReservaHotelHabitacion()
        {
            unit = new UnitOfWork();
        }

        /// <summary>
        /// Permite obtener las  reservas de habitaciones
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ReservaHabitaciones> GetBookRoomHotel()
        {
            IEnumerable<ReservaHabitaciones> bookRoomHotel;
            return bookRoomHotel = unit.ReservaHabitacionesRepository.Get().AsEnumerable();
        }

        public Boolean GetValidatedBookRoom(int idHotel)
        {
            var bookRoomsExit = unit.ReservaHabitacionesRepository.FindSingleBy(x => Convert.ToDateTime(x.Fecha).ToString("dd/MM/yyyy") == DateTime.Now.ToShortDateString() && x.IdHotel == idHotel);
            if (bookRoomsExit != null)
                return true;
            return false;
        }

        public IEnumerable<ReservaHabitaciones> GetBookRoomByHotel(Int32 IdHotel)
        {
            var bookRooms = unit.ReservaHabitacionesRepository.Get(x => x.IdHotel == IdHotel);
            if (bookRooms == null)
                return null;
            return bookRooms.AsEnumerable();
        }

        public int GetTotalBookRoomByHotel(Int32 IdHotel)
        {
            var bookRooms = unit.ReservaHabitacionesRepository.Get(x => x.IdHotel == IdHotel).Count();
            return bookRooms;
        }


        /// <summary>
        /// Permite crear la Reserva de Habitacion
        /// </summary>
        /// <param name="roomAvailable"></param>
        /// <returns></returns>
        public ReservaHabitaciones BookRoomCreate(ReservaHabitaciones bookRoom)
        {
            bookRoom.Fecha = DateTime.Now;
            unit.ReservaHabitacionesRepository.Insert(bookRoom);
            unit.Save();
            return bookRoom;
        }

        /// <summary>
        /// Permite eliminar la  reserva de habitacion
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBookRoom(Int32 id)
        {
            var bookRoom = unit.ReservaHabitacionesRepository.GetByID(id);
            if (bookRoom != null)
            {
                unit.ReservaHabitacionesRepository.Delete(bookRoom);
                unit.Save();
            }
        }
        /// <summary>
        /// Permite actualizar la informacion correspondiente a la reserva de la  habitacion del hotel
        /// </summary>
        /// <param name="aplicacion"></param>
        /// <returns></returns>
        public String UpdateBookRoom(ReservaHabitaciones bookRoom)
        {
            String msg;
            var bookRoomSearch = unit.ReservaHabitacionesRepository.GetByID(bookRoom.Id);

            if (bookRoomSearch == null)
            {
                msg = "Reserva de Habitacion no encontrada";
            }
            else
            {
                bookRoomSearch.IdCiudad = bookRoom.IdCiudad;
                bookRoomSearch.Fecha = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                bookRoomSearch.IdHotel = bookRoom.IdHotel;
                bookRoomSearch.NumeroHabitacionReservada = bookRoom.NumeroHabitacionReservada;
                bookRoomSearch.NumeroPasajeros = bookRoom.NumeroPasajeros;
                bookRoomSearch.Mascota = bookRoom.Mascota;

                unit.ReservaHabitacionesRepository.Update(bookRoomSearch);
                unit.Save();
                msg = "Dato Guardado satifactoriamente";
            }
            return msg;
        }
    }
}

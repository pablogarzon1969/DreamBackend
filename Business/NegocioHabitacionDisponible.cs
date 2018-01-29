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
    public class NegocioHabitacionDisponible
    {
        private UnitOfWork unit;

        public NegocioHabitacionDisponible()
        {
            unit = new UnitOfWork();
        }

        /// <summary>
        /// Permite obtener las habitaciones disponibles
        /// </summary>
        /// <returns></returns>
        public IEnumerable<HabitacionesDisponibles> GetRoomsAvailables()
        {
            IEnumerable<HabitacionesDisponibles> roomsAvailables;
            return roomsAvailables = unit.HabitacionDispobleRespository.Get().AsEnumerable();
        }

 

        public HabitacionesDisponibles GetRoomsAvailablesByHotel(Int32 IdHotel)
        {
            var roomsAvailables = unit.HabitacionDispobleRespository.FindSingleBy(x => x.IdHotel == IdHotel);
            if (roomsAvailables == null)
                return null;
            return roomsAvailables;
        }


        public IEnumerable<dynamic> GetRoomsAvailablesHotelByUser(int idUser)
        {
            var roomAvailables = from fusuario in unit.UsuarioRepository.Get()
                                 join fempresa in unit.EmpresaRespository.Get() on fusuario.empresaId equals fempresa.Id
                                 join fhotel in unit.HotelRespository.Get() on fempresa.Id equals fhotel.IdEmpresa
                                 join fhabitaciondisponible in unit.HabitacionDispobleRespository.Get() on fhotel.Id equals fhabitaciondisponible.IdHotel
                                 join ftipoempresa in unit.TipoEmpresaRecursoRepository.Get() on fempresa.IdTipoEmpresa equals ftipoempresa.Id
                                 where fusuario.Id == idUser
                                 select new
                                 {
                                     Id = fhabitaciondisponible.Id,
                                     Fecha = fhabitaciondisponible.Fecha,
                                     IdHotel = fhabitaciondisponible.IdHotel,
                                     TotalHabitacionesDisponibles = fhabitaciondisponible.TotalHabitacionesDisponibles
                                 };
            return roomAvailables.ToList();
        }


        public IEnumerable<HabitacionesDisponibles> GetTotalRoomsAvailablesByHotel(Int32 IdHotel)
        {

           var roomsAvailables = unit.HabitacionDispobleRespository.Get(x => x.IdHotel == IdHotel && Convert.ToDateTime(x.Fecha).ToString("dd/MM/yyyy") == DateTime.Now.ToShortDateString());
            return roomsAvailables.ToList();
        }

        public Boolean GetValidatedRoomAvailableHotelByDay(int idHotel)
        {
            var validatedRoomAvailableHotel = unit.HabitacionDispobleRespository.Get(x => Convert.ToDateTime(x.Fecha).ToString("dd/MM/yyyy") == DateTime.Now.ToShortDateString() && x.IdHotel == idHotel);
            if (validatedRoomAvailableHotel != null)
                return true;
            return false;
        }

        /// <summary>
        /// Permite crear la habitacion
        /// </summary>
        /// <param name="roomAvailable"></param>
        /// <returns></returns>
        public HabitacionesDisponibles RoomAvailableCreate(HabitacionesDisponibles roomAvailable)
        {
            roomAvailable.Fecha = DateTime.Now;
            unit.HabitacionDispobleRespository.Insert(roomAvailable);
            unit.Save();
            return roomAvailable;
        }

        /// <summary>
        /// Permite eliminar la habitacion disponible
        /// </summary>
        /// <param name="id"></param>
        public void DeleteRoomAvailable(Int32 id)
        {
            var roomAvailable = unit.HabitacionDispobleRespository.GetByID(id);
            if (roomAvailable != null)
            {
                unit.HabitacionDispobleRespository.Delete(roomAvailable);
                unit.Save();
            }
        }
        /// <summary>
        /// Permite actualizar la informacion correspondiente a la habitacion del hotel
        /// </summary>
        /// <param name="aplicacion"></param>
        /// <returns></returns>
        public String UpdateRoomAvailable(HabitacionesDisponibles roomAvailable)
        {
            String msg;
            var roomAvailableSearch = unit.HabitacionDispobleRespository.GetByID(roomAvailable.Id);

            if (roomAvailableSearch == null)
            {
                msg = "Habitacion no encontrada";
            }
            else
            {
                roomAvailableSearch.TotalHabitacionesDisponibles = roomAvailable.TotalHabitacionesDisponibles;
                roomAvailableSearch.Fecha = Convert.ToDateTime(roomAvailable.Fecha);
               // roomAvailableSearch.IdHotel = roomAvailable.IdHotel;

                unit.HabitacionDispobleRespository.Update(roomAvailableSearch);
                unit.Save();
                msg = "Dato Guardado satifactoriamente";
            }
            return msg;
        }
    }
}

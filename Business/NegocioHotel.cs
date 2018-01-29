using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class NegocioHotel
    {
        private UnitOfWork unit;

        /// <summary>
        /// 
        /// </summary>
        public NegocioHotel()
        {
            unit = new UnitOfWork();
        }

        /// <summary>
        /// Permite obtener el hotel por el id del usuario
        /// </summary>
        /// <returns></returns>
        public IEnumerable<dynamic> GetHotelByUser(int id)
        {
            var hotel = from fhotel in unit.HotelRespository.Get()
                             join fempresa in unit.EmpresaRespository.Get() on fhotel.IdEmpresa equals fempresa.Id
                             join fusuario in unit.UsuarioRepository.Get() on fempresa.Id equals fusuario.empresaId
                             where fusuario.Id == id
                             select new
                             {
                                 idHotel = fhotel.Id,
                                 nameHotel = fhotel.Nombre,
                                 nameEnterprise = fempresa.Nombre
                                
                             };
            return hotel.ToList();

        }

        /// <summary>
        /// Permite mostrar los hoteles por ciudad
        /// </summary>
        /// <param name="IdCountry"></param>
        /// <returns></returns>
        public IEnumerable<dynamic> GetHotelsByCity(Int32 IdCity)
        {
            var hotels = from fhotel in unit.HotelRespository.Get()

                         where fhotel.IdCiudad == IdCity
                         select new
                         {
                             Id = fhotel.Id,
                             name = fhotel.Nombre,
                         };
            return hotels.ToList();
        }

        /// <summary>
        /// Permite crear el hotel
        /// </summary>
        /// <param name="typeNovelty"></param>
        /// <returns></returns>
        public Hotel HotelCreate(Hotel hotel)
        {
            unit.HotelRespository.Insert(hotel);
            unit.Save();
            return hotel;
        }



        /// <summary>
        /// Permite actualizar la informacion correspondiente al hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        public String UpdateHotel(Hotel hotel)
        {
            String msg;
            var hotelSearch = unit.HotelRespository.GetByID(hotel.Id);

            if (hotelSearch == null)
            {
                msg = "El Hotel no se encuentra";
            }
            else
            {
                hotelSearch.Nombre = hotel.Nombre;
                hotelSearch.Id = hotel.Id;
                unit.HotelRespository.Update(hotelSearch);
                unit.Save();
                msg = "Dato Guardado satifactoriamente";
            }
            return msg;
        }
    }
}

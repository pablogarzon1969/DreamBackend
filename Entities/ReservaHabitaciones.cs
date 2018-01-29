using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public partial class ReservaHabitaciones
    {
        public ReservaHabitaciones()
        {
        }

        [Key]
        public Int32 Id { get; set; }
        public Int32 IdHotel { get; set; }
        public Int32 IdCiudad { get; set; }
        public Int32 NumeroHabitacionReservada { get; set; }
        public Int32 NumeroPasajeros { get; set; }
        public DateTime Fecha { get; set; }
        public Boolean Mascota { get; set; }

        [ForeignKey("IdCiudad")]
        public Ciudad Ciudad { get; set; }
        [ForeignKey("IdHotel")]
        public Hotel Hotel { get; set; }
    }
}

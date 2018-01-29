using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public partial class HabitacionesDisponibles
    {
        public Int32 Id { get; set; }
        public Int32? TotalHabitacionesDisponibles { get; set; }
        public Int32? IdHotel { get; set; }
        public DateTime? Fecha { get; set; }

        [ForeignKey("IdHotel")]
        public Hotel Hotel{ get; set; }
    }
}

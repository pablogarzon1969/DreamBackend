using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public partial class ReservaHabitacionCierre
    {
        public ReservaHabitacionCierre()
        {
        }

        [Key]
        public int Id { get; set; }
        public int IdReservaHabitacion { get; set; }

        [ForeignKey("IdReservaHabitacion")]
        public ReservaHabitaciones ReservaHabitacion { get; set; }
    }
}

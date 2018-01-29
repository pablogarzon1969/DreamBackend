using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public partial class ReservaHabitacionCierreVoucher
    {
        [Key]
        public Int32 Id { get; set; }
        public Int32 IdReservaHabitacionCierre { get; set; }
        public String NumeroVoucher { get; set; }

        [ForeignKey("IdReservaHabitacionCierre")]
        public ReservaHabitacionCierre ReservaHabitacionCierre{ get; set; }
    }
}

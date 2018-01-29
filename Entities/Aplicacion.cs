using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Aplicacion
    {
        [Key]
        public Int32 Id
        {
            get; set;
        }
        [Required]
        [MaxLength(100)]
        public String NombreAplicacion
        {
            get; set;
        }
        [Required]
        public Boolean Activo
        {
            get; set;
        }
    }
}

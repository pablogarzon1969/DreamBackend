using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Pais
    {
        [Key]
        public Int32 Id
        {
            get; set;
        }
        [Required]
        [MaxLength(100)]
        public String Nombre
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

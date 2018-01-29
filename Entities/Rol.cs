using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Rol
    {
        [Key]
        public Int32 Id
        {
            get; set;
        }

        public int aplicacionId
        {
            get; set;
        }

        [Required]
        [MaxLength(100)]
        public String NombreRol
        {
            get; set;
        }

        [Required]
        public Boolean Activo
        {
            get; set;
        }

        [ForeignKey("aplicacionId")]
        public virtual Aplicacion aplicacion
        {
            get; set;
        }
    }
}

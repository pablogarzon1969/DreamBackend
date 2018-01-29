using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Permiso
    {
        [Key]
        public Int32 Id
        {
            get; set;
        }

        [MaxLength(100)]
        [Required]
        public String NombrePermiso
        {
            get; set;
        }
        [Required]
        public Boolean Activo
        {
            get; set;
        }

        public int rolId
        {
            get; set;
        }

        [ForeignKey("rolId")]
        public virtual Rol rol
        {
            get; set;
        }

    }
}

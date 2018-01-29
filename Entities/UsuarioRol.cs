using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class UsuarioRol
    {
        [Key]
        public Int32 Id
        {
            get; set;
        }

        [Required]
        public Int64 usuarioId
        {
            get; set;
        }

        [ForeignKey("usuarioId")]
        public virtual Usuario usuario
        {
            get; set;
        }

        [Required]
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

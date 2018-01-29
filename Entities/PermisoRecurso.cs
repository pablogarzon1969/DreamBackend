using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class PermisoRecurso
    {
        [Key]
        public Int32 Id
        {
            get; set;
        }
        public Boolean Consultar
        {
            get; set;
        }
        public Boolean Crear
        {
            get; set;
        }

        public Boolean Editar
        {
            get; set;
        }

        public Boolean Eliminar
        {
            get; set;
        }

        public int permisoId
        {
            get; set;
        }

        [ForeignKey("permisoId")]
        public virtual Permiso permiso
        {
            get; set;
        }

    }
}

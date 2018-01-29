using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public partial class TipoEmpresa
    {
        public TipoEmpresa()
        {
        }

        [Key]
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public Boolean Activo { get; set; }

    }
}

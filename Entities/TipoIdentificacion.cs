using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public partial class TipoIdentificacion
    {
        public TipoIdentificacion()
        {
        }

        [Key]
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public String Siglas { get; set; }
        public String Codigo { get; set; }
        public Boolean Activo { get; set; }
    }
}

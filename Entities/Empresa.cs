using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public partial class Empresa
    {
        public Empresa()
        {
        }

        public Int32 Id { get; set; }
        public Int32 IdTipoEmpresa { get; set; }
        public String Nit { get; set; }
        public Int32 DigitoVerificación { get; set; }
        public String Nombre { get; set; }
        public String Mision { get; set; }
        public String Vision { get; set; }
        public String Lema { get; set; }
        public String PathLogo { get; set; }
        public String Representante { get; set; }
        public String Contactos { get; set; }
        public Boolean Activo { get; set; }
        public String Telefono { get; set; }


        [ForeignKey("IdTipoEmpresa")]
        public TipoEmpresa TipoEmpresa { get; set; }

    }
}

using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public partial class Hotel
    {
        public Hotel()
        {
        }

        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public Int32 IdCiudad { get; set; }
        public Int32 IdEmpresa { get; set; }


        [ForeignKey("IdEmpresa")]
        public virtual Empresa empresa
        {
            get; set;
        }

        [ForeignKey("IdCiudad")]
        public virtual Ciudad Ciudad
        {
            get; set;
        }
    }
}

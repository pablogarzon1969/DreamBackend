using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Usuario
    {
        [Key]
        public Int64 Id
        {
            get; set;
        }

        public int rolId
        {
            get; set;
        }

        public int empresaId
        {
            get; set;
        }

        [MaxLength(100)]
        public String Username
        {
            get; set;
        }

        [NotMapped]
        public String Password { get; set; }

        public byte[] PasswordSalt { get; set; }

        public byte[] PasswordHash { get; set; }


        [ForeignKey("rolId")]
        public virtual Rol rol
        {
            get; set;
        }


        [ForeignKey("empresaId")]
        public virtual Empresa empresa
        {
            get; set;
        }
    }
}


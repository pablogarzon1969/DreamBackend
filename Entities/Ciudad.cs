using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class Ciudad
    {
        [Key]
        public Int32 Id
        {
            get; set;
        }
        public int paisId
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

        [ForeignKey("paisId")]
        public virtual Pais pais
        {
            get; set;
        }
    }
}

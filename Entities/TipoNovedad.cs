using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class TipoNovedad
    {
        [Key]
        public int IdTipoNovedad { get; set; }
        [Required]
        [MaxLength(100)]
        public string Descripcion { get; set; }
        public bool? Activa { get; set; }
    }
}

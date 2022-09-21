using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ********************************
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingSystem.EntidadesDeNegocio
{
    public class RopaFoto
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Ropa")]
        [Required(ErrorMessage = "Ropa es obligatorio")]
        [Display(Name = "Ropa")]
        public int IdRopa { get; set; }
        [Required(ErrorMessage = "Url es obligatorio")]
        [StringLength(200, ErrorMessage = "Maximo 200 caracteres")]
        public string Url { get; set; }
        public Ropa? Ropa { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
       
        public byte Estatus { get; set; }
    }
    public enum Estatus_RopaFoto
    {
        ACTIVO = 1,
        INACTIVO = 2
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ********************************
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingSystem.EntidadesDeNegocio
{
    public class Ropa
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Marca")]
        [Required(ErrorMessage = "Marca es obligatorio")]
        [Display(Name = "Marca")]
        public int IdMarca { get; set; }

        [Required(ErrorMessage = "CodigoBarra es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string CodigoBarra { get; set; }

        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "PrecioCompra es obligatorio")]
        [StringLength(25, ErrorMessage = "Maximo 25 caracteres")]
        public decimal PrecioCompra { get; set; }

        [Required(ErrorMessage = "PrecioVenta es obligatorio")]
        [Range(0.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal PrecioVenta { get; set; }

        [Required(ErrorMessage = "Existencia es obligatorio")]
        [Range(0.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public int Existencia { get; set; }

        [Required(ErrorMessage = "Estatus es obligatorio")]
        public byte Estatus { get; set; }

        [Required(ErrorMessage = "Talla es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string Talla { get; set; }

        [Required(ErrorMessage = "Color es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string Color { get; set; }


        [StringLength(25, ErrorMessage = "Maximo 25 caracteres")]
        public string? Estilo { get; set; }

        
        [StringLength(25, ErrorMessage = "Maximo 25 caracteres")]
        public string? Descripcion { get; set; }

        
        [StringLength(25, ErrorMessage = "Maximo 25 caracteres")]

        public string? TipoTela { get; set; }
       
        public Marca? Marca { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }

    }
    public enum Estatus_Ropa
    {
        ACTIVO = 1,
        INACTIVO = 2
    }
}


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


        [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
        public string? CodigoBarra { get; set; }

        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(60, ErrorMessage = "Maximo 60 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Existencia es obligatorio")]
        [Display(Name = "Existencia")]
        public int Existencia { get; set; }

        [Required(ErrorMessage = "Estatus es obligatorio")]
        public byte Estatus { get; set; }


        [Required(ErrorMessage = "Talla es obligatorio")]
        [StringLength(10, ErrorMessage = "Maximo 10 caracteres")]
        public string Talla { get; set; }


        [Required(ErrorMessage = "Color es obligatorio")]
        [StringLength(60, ErrorMessage = "Maximo 60 caracteres")]
        public string Color { get; set; }



        [StringLength(60, ErrorMessage = "Maximo 60 caracteres")]
        public string? Estilo { get; set; }



        [StringLength(200, ErrorMessage = "Maximo 200 caracteres")]
        public string? Descripcion { get; set; }

        [StringLength(60, ErrorMessage = "Maximo 60 caracteres")]
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
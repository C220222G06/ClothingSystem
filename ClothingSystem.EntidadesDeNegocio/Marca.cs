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
    public class Marca
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string Nombre { get; set; }

        public byte Estatus { get; set; }
        [StringLength(200, ErrorMessage = "Maximo 200 caracteres")]
        public string? Descripcion { get; set; }
        [StringLength(60, ErrorMessage = "Maximo 60 caracteres")]
        public string? PaisOrigen { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
        public List<Ropa>? Ropa { get; set; }
    }
    public enum Estatus_Marca
    {
        ACTIVO = 1,
        INACTIVO = 2
    }
}

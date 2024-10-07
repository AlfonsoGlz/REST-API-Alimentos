using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RESTAPI_Alimentos.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Alimentos = new HashSet<Alimento>();
        }

        public int IdCategoria { get; set; }

        [MaxLength(20, ErrorMessage = "El campo debe tener maximo 20 caracteres")]
        [Required]
        public string NombreCategoria { get; set; } = null!;

        public virtual ICollection<Alimento> Alimentos { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoDeDadosTw.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Evento = new HashSet<Evento>();
        }

        [Key]
        public int IdCategoria { get; set; }
        [Required]
        [StringLength(100)]
        public string NomeCategoria { get; set; }
        [Required]
        [MaxLength(1)]
        public byte[] StatusCategoria { get; set; }

        [InverseProperty("IdCategoriaNavigation")]
        public virtual ICollection<Evento> Evento { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoDeDadosTw.Models
{
    public partial class Sala
    {
        public Sala()
        {
            Evento = new HashSet<Evento>();
        }

        [Key]
        public int IdSala { get; set; }
        [Required]
        [StringLength(255)]
        public string NomeSala { get; set; }
        [Required]
        [StringLength(255)]
        public string DescricaoSala { get; set; }

        [InverseProperty("IdSalaNavigation")]
        public virtual ICollection<Evento> Evento { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoDeDadosTw.Models
{
    public partial class Comunidade
    {
        [Key]
        public int IdComunidade { get; set; }
        public int? IdUsuario { get; set; }
        [Required]
        [StringLength(100)]
        public string NomeComunidade { get; set; }
        [Required]
        [StringLength(100)]
        public string NomeResponsavelComunidade { get; set; }
        [Required]
        [StringLength(100)]
        public string ContatoComunidade { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Comunidade))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}

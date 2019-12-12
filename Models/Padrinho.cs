using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoDeDadosTw.Models
{
    public partial class Padrinho
    {
        [Key]
        public int IdPadrinho { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdEvento { get; set; }

        [ForeignKey(nameof(IdEvento))]
        [InverseProperty(nameof(Evento.Padrinho))]
        public virtual Evento IdEventoNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Padrinho))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}

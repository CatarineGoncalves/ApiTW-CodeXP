using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoDeDadosTw.Models
{
    public partial class Evento
    {
        public Evento()
        {
            Padrinho = new HashSet<Padrinho>();
        }

        [Key]
        public int IdEvento { get; set; }
        public int? IdUpload { get; set; }
        [Required]
        [StringLength(255)]
        public string NomeEvento { get; set; }
        [Column(TypeName = "date")]
        public DateTime DataEvento { get; set; }
        [Required]
        [StringLength(255)]
        public string LocalizacaoEvento { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime HoraEvento { get; set; }
        [Required]
        [StringLength(255)]
        public string DescricaoEvento { get; set; }
        public int? IdSala { get; set; }
        [Required]
        [MaxLength(1)]
        public byte[] LibrasEvento { get; set; }
        [Required]
        [MaxLength(1)]
        public byte[] AlimentacaoEvento { get; set; }
        [Required]
        [StringLength(255)]
        public string RestricaoAlimentacao { get; set; }
        [Required]
        [MaxLength(1)]
        public byte[] StatusEvento { get; set; }
        [Required]
        [MaxLength(1)]
        public byte[] CondicaoEvento { get; set; }
        public int IdCategoria { get; set; }
        public int IdUsuario { get; set; }

        [ForeignKey(nameof(IdCategoria))]
        [InverseProperty(nameof(Categoria.Evento))]
        public virtual Categoria IdCategoriaNavigation { get; set; }
        [ForeignKey(nameof(IdSala))]
        [InverseProperty(nameof(Sala.Evento))]
        public virtual Sala IdSalaNavigation { get; set; }
        [ForeignKey(nameof(IdUpload))]
        [InverseProperty(nameof(Uploadtw.Evento))]
        public virtual Uploadtw IdUploadNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Evento))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
        [InverseProperty("IdEventoNavigation")]
        public virtual ICollection<Padrinho> Padrinho { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoDeDadosTw.Models
{
    [Table("UPLOADTw")]
    public partial class Uploadtw
    {
        public Uploadtw()
        {
            Evento = new HashSet<Evento>();
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        public int IdUpload { get; set; }
        [StringLength(255)]
        public string ImgUser { get; set; }
        [StringLength(255)]
        public string ImgEvento { get; set; }
        [StringLength(255)]
        public string ImgSala { get; set; }

        [InverseProperty("IdUploadNavigation")]
        public virtual ICollection<Evento> Evento { get; set; }
        [InverseProperty("UploadNavigation")]
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}

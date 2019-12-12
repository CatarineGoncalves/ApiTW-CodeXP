using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoDeDadosTw.Models
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        public int IdTipoUsuario { get; set; }
        [Required]
        [StringLength(255)]
        public string NomeTipoUsuario { get; set; }

        [InverseProperty("IdTipoUsuarioNavigation")]
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}

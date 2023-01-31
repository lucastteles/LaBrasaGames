using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LaBrasa.Domain.Enum.Enumeradores;

namespace Labrasa.Application.DTOs
{
    public class UsuarioDTO
    {
        public Guid IdIdentity { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o sobrenome")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Informe o seu endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Informe o seu gênero")]
        public GeneroEnum Genero { get; set; }

        [Required(ErrorMessage = "Informe a sua idade")]
        public int Idade { get; set; }
    }
}

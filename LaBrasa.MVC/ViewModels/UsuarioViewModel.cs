using static LaBrasa.Domain.Enum.Enumeradores;

namespace LaBrasa.MVC.ViewModels
{
    public class UsuarioViewModel
    {  
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Idade { get; set; }

        public string Genero { get; set; }

        public string Endereco { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }
    }
}

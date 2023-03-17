using LaBrasa.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LaBrasa.Domain.Enum.Enumeradores;

namespace LaBrasa.Domain.Entidade
{
    public sealed class Usuario
    {
        public Guid IdIdentity { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Endereco { get; private set; }
        public GeneroEnum Genero { get; private set; }
        public int Idade { get; private set; }


        public Usuario(string nome, string sobrenome, string endereco, GeneroEnum genero, int idade)
        {
            ValidateDomain(nome, sobrenome, endereco, genero, idade);
        }

        public void Update(string nome, string sobrenome, string endereco, GeneroEnum genero, int idade)
        {
            ValidateDomain(nome, sobrenome, endereco, genero, idade);

        }


        private void ValidateDomain(string nome, string sobrenome, string endereco, GeneroEnum genero, int idade)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome inválido. Nome é obrigatório");

            DomainExceptionValidation.When(nome.Length < 3, "Nome inválido, minimo 3 caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(sobrenome), "Sobrenome inválido. Sobrenome é obrigatório");

            DomainExceptionValidation.When(sobrenome.Length < 5, "Sobrenome inválido, minimo 5 caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(endereco), "Endereço inválido. Endereço é obrigatório");

            DomainExceptionValidation.When(endereco.Length < 10, "Endereço inválido, minimo 10 caracteres");

            DomainExceptionValidation.When(idade < 0, "Idade inválida");




            Nome = nome;
            Sobrenome = sobrenome;
            Endereco = endereco;
            Genero = genero;
            Idade = idade;
        }
    }
}

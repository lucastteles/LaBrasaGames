using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaBrasa.Domain.Entidade
{
    public class Email
    {
        public string origem { get; set; }
        public string destino { get; set; }
        public string assunto { get; set; }
        public string mensagem { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }
    }
}

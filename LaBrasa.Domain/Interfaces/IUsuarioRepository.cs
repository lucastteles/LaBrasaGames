using LaBrasa.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaBrasa.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> ObterUsuarios();

        Task<IEnumerable<Usuario>> ObterUsuarioPorNome(string nome);
        Task<Usuario> ObterPorId(Guid id); 
        Task<Usuario> AdicionarUsuario(Usuario usuario);
        Task<Usuario> Atualizar(Usuario usuario);
        Task<Usuario> Remover(Usuario usuario);
    }
}

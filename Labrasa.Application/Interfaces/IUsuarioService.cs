using Labrasa.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labrasa.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> ObterUsuario(); 
        Task<UsuarioDTO> ObterPorId(Guid id);
        Task Adicionar(UsuarioDTO usuarioDTO);
        Task Atualizar(UsuarioDTO usuarioDTO);
        Task Remover(Guid id);
    }
}

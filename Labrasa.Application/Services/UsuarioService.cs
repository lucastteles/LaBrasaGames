using AutoMapper;
using Labrasa.Application.DTOs;
using Labrasa.Application.Interfaces;
using LaBrasa.Domain.Entidade;
using LaBrasa.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labrasa.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;

        }

        public async Task<IEnumerable<UsuarioDTO>> ObterUsuario()
        {
            var usuarioEntity = await _usuarioRepository.ObterUsuarios();
            return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarioEntity);
        }

        public async Task<UsuarioDTO> ObterPorId(Guid id)
        {
            var usuarioEntity = await _usuarioRepository.ObterPorId(id);
            return _mapper.Map<UsuarioDTO>(usuarioEntity);
        }

        public async Task Adicionar(UsuarioDTO usuarioDTO)
        {
            var usuarioEntity = _mapper.Map<Usuario>(usuarioDTO);
            await _usuarioRepository.AdicionarUsuario(usuarioEntity);
        }

        public async Task Atualizar(UsuarioDTO usuarioDTO)
        {
            var usuarioEntity = _mapper.Map<Usuario>(usuarioDTO);
            await _usuarioRepository.Atualizar(usuarioEntity);
        }

        public async Task Remover(Guid id)
        {
            var usuarioEntity = _usuarioRepository.ObterPorId(id).Result;
            await _usuarioRepository.Remover(usuarioEntity);
        }

        public async Task<IEnumerable<UsuarioDTO>> ObterUsuarioPorNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return new List<UsuarioDTO>();

            var usuarioEntity = await _usuarioRepository.ObterUsuarioPorNome(nome);
            return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarioEntity);
        }
    }
}

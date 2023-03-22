using LaBrasa.Domain.Entidade;
using LaBrasa.Domain.Interfaces;
using LaBrasa.Infra.Data.Context;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaBrasa.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        ApplicationDbContext _usuarioContext;
        IdentityDbContext _identityDbContext;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _usuarioContext = context;
        }

        public async Task<Usuario> Atualizar(Usuario usuario)
        {
            _usuarioContext.Update(usuario);
            await _usuarioContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> AdicionarUsuario(Usuario usuario)
        {
            _usuarioContext.Add(usuario);
            await _usuarioContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<Usuario> ObterPorId(Guid id)
        {
            return await _usuarioContext.Usuario.FindAsync(id);
        }

        public async Task<IEnumerable<Usuario>> ObterUsuarios()
        {
            return await _usuarioContext.Usuario.ToListAsync();
        }

        public async Task<Usuario> Remover(Usuario usuario)
        {
            _usuarioContext.Remove(usuario);
            await _usuarioContext.SaveChangesAsync(); 
            return usuario;
        }

        public async Task<IEnumerable<Usuario>> ObterUsuarioPorNome(string nome)
        {
            return await _usuarioContext.Usuario
                 .Where(p => p.Nome.ToLower()////////******/ 
                 .Contains(nome.ToLower()))
                 .ToListAsync();
            //return await _usuarioContext.Usuario
            // .Where(p => p.Genero.ToString()
            // .ToLower() == genero.ToLower())
            // .ToListAsync();
        }

        //return await _usuarioContext.Usuario
        //     .Where(p => p.Nome.ToLower()
        //     .Contains(nome.ToLower()))
        //     .ToListAsync();
    }

}




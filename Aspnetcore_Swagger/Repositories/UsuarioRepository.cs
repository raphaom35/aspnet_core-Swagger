using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Repositories
{
    public static class UsuarioRepository
    {
        public static Usuario Get(string nome, string senha, DataContext context)
        {
            var usuarios = context.Usuarios.Where(e =>
                                    e.Nome.ToLower() == nome.ToLower() &&
                                    e.Senha == senha).FirstOrDefault();

            return usuarios;
        }
    }
}

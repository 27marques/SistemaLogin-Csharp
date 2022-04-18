using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    public class UsuarioController 
    {
        public static Usuario InserirUsuario(
            int Id,
            string Nome,
            string Email,
            string Senha
        )
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new Exception("Nome inválido");
            }

            if (String.IsNullOrEmpty(Email))
            {
                throw new Exception("E-mail inválido");
            }

            if (String.IsNullOrEmpty(Senha))
            {
                throw new Exception("Senha inválido");
            }

            else
            {
                Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
            }

            return new Usuario(Nome, Email, Senha);
        }
    }
}
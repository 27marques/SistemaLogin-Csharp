using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Models;

namespace Controllers
{
    public class SenhaController
    {
        public static Senha InserirSenha(
            string Nome,
            int CategoriaId,
            string Url,
            string Usuario,
            string SenhaEncrypt,
            string Procedimento
        )
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new Exception("O nome é obrigatório.");
            }
            try {
                CategoriaController.GetCategoria(CategoriaId);
            }
            catch
            {
                throw new Exception("Categoria inválida");
            }
            
            Regex rx = new Regex(
                "https?:\\/\\/(?:www\\.|(?!www))[a-zA-Z0-9][a-zA-Z0-9-]+"
                + "[a-zA-Z0-9]\\.[^\\s]{2,}|www\\.[a-zA-Z0-9][a-zA-Z0-9-]+"
                + "[a-zA-Z0-9]\\.[^\\s]{2,}|https?:\\/\\/(?:www\\.|(?!www))"
                + "[a-zA-Z0-9]+\\.[^\\s]{2,}|www\\.[a-zA-Z0-9]+\\.[^\\s]{2,}"
            );

 		    if (String.IsNullOrEmpty(Url) || !rx.IsMatch(Url))
            {
                throw new Exception("A url é inválida.");
            }
            
            if (String.IsNullOrEmpty(Usuario))
            {
                throw new Exception("O usuário é obrigatória.");
            }
            if (String.IsNullOrEmpty(SenhaEncrypt))
            {
                throw new Exception("A senha é obrigatória.");
            }
            if (SenhaEncrypt.Length < 8) 
            {
                throw new Exception("A senha deve ter no mínimo 8 caracteres.");
            }

            return new Senha(Nome, CategoriaId, Url, Usuario, SenhaEncrypt, Procedimento);
        }

        public static Senha AlterarSenha(
            int Id,
            string Nome,
            int CategoriaId,
            string Url,
            string Usuario,
            string SenhaEncrypt,
            string Procedimento
        )
        {
            Senha senha = Senha.GetSenha(Id);

            if (!String.IsNullOrEmpty(Nome))
            {
                senha.Nome = Nome;
            }
            try {
                CategoriaController.GetCategoria(CategoriaId);
            }
            catch
            {
                throw new Exception("Categoria inválida");
            }
            Regex rx = new Regex(
                "https?:\\/\\/(?:www\\.|(?!www))[a-zA-Z0-9][a-zA-Z0-9-]+"
                + "[a-zA-Z0-9]\\.[^\\s]{2,}|www\\.[a-zA-Z0-9][a-zA-Z0-9-]+"
                + "[a-zA-Z0-9]\\.[^\\s]{2,}|https?:\\/\\/(?:www\\.|(?!www))"
                + "[a-zA-Z0-9]+\\.[^\\s]{2,}|www\\.[a-zA-Z0-9]+\\.[^\\s]{2,}"
            );
            if (!String.IsNullOrEmpty(Url)) 
            {
                senha.Url = Url;
            }
            if (!String.IsNullOrEmpty(Usuario)) 
            {
                senha.Usuario = Usuario;
            }
            if (SenhaEncrypt.Length < 8)
            {
                throw new Exception("A senha deve ter no mínimo 8 caracteres.");
            }
            else
            {
                SenhaEncrypt = BCrypt.Net.BCrypt.HashPassword(SenhaEncrypt);
            }
            if (!String.IsNullOrEmpty(Procedimento)) 
            {
                senha.Procedimento = Procedimento;
            }
            Models.Senha.AlterarSenha(Id, Nome, CategoriaId, Url, Usuario, SenhaEncrypt, Procedimento);
            return senha;
               
        }

        public static Senha RemoverSenha(
            int Id
        )
        {
            try
            {
                Senha senha = Senha.GetSenha(Id);
                Models.Senha.RemoverSenha(senha);
                return senha;
            }
            catch
            {
                throw new Exception("Senha não encontrada.");
            } 
        }

        public static IEnumerable<Senha> VisualizarSenha()
        {
            return Models.Senha.GetSenhas();
        }

        public static Senha GetSenha(int Id)
        {
            Senha senha = (
                from Senha in Senha.GetSenhas()
                    where Senha.Id == Id
                    select Senha
            ).First();

            if (senha == null)
            {
                throw new Exception("Senha não encontrada");
            }

            return senha;
        }
    
    }
}

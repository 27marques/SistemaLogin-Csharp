using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Models;

namespace Controllers
{
    public class CategoriaController 
    {
        public static Categoria IncluirCategoria(
            string Nome,
            string Descricao
        )
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new Exception("Nome é obrigatório");
            }

            return new Categoria(Nome, Descricao);
        }

        public static Categoria AlterarCategoria(
            int Id,
            string Nome,
            string Descricao
        )
        {
            Categoria categoria = GetCategoria(Id);

            if (!String.IsNullOrEmpty(Nome))
            {
                categoria.Nome = Nome;
            }
            categoria.Descricao = Descricao;
            Models.Categoria.AlterarCategoria(Id, Nome, Descricao);

            return categoria;
        }

        public static Categoria ExcluirCategoria(
            int Id
        )
        {
            Categoria categoria = GetCategoria(Id);
            Models.Categoria.RemoverCategoria(categoria);
            return categoria;
        }
        public static IEnumerable<Categoria> VisualizarCategoria()
        {
            return Models.Categoria.GetCategorias();
        }

        public static Categoria GetCategoria(
            int Id
        )
        {
            IEnumerable<Categoria> categoriaModels = Models.Categoria.GetCategorias();
            IEnumerable<Categoria> categorias = from Categoria in categoriaModels
                                        where Categoria.Id == Id
                                        select Categoria;
            Categoria categoria = categorias.First();

            if (categoria == null)
            {
                throw new Exception("Categoria não encontrada");
            }

            return categoria;
        }
    }
}

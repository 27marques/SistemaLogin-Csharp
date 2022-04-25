using System;
using System.Collections.Generic;
using System.Linq;
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
        public static List<Categoria> VisualizarCategoria()
        {
            return Models.Categoria.GetCategoria();
        }

        public static Categoria GetCategoria(
            int Id
        )
        {
            List<Categoria> categoriaModels = Models.Categoria.GetCategoria();
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

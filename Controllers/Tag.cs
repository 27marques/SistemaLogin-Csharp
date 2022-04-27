using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    public class TagController 
    {
        public static Tag IncluirTag(
            string Descricao
        )
        {
            if (String.IsNullOrEmpty(Descricao)) 
            {
                throw new Exception("ID é obrigatório");
            }

            return new Tag(Descricao);
        }

        public static Tag AlterarTag(
            int Id,
            string Descricao
        )
        {
            Tag tag = GetTag(Id);

            if (!String.IsNullOrEmpty(Descricao)) {
                tag.Id = Id;
            }
            tag.Descricao = Descricao;

            return tag;
        }

        public static Tag ExcluirTag(
            int Id
        )
        {
            Tag tag = GetTag(Id);
            Models.Tag.RemoverTag(tag);
            return tag;
        }

        public static IEnumerable<Tag> VisualizarTags()
        {
            return Models.Tag.GetTags();  
        }

        public static Tag GetTag(
            int Id
        )
        {
            IEnumerable<Tag> tagsModels = Models.Tag.GetTags();
            IEnumerable<Tag> tags = from Tag in tagsModels
                            where Tag.Id == Id
                            select Tag;
            Tag tag = tags.First();
            
            if (tag == null)
            {
                throw new Exception("Tag não encontrada");
            }

            return tag;
        }
    }
}

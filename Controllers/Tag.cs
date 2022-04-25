using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    public class TagController 
    {
        public static Tag IncluirTag(
            int Id,
            string Descricao
        )
        {
            if (String.IsNullOrEmpty(Id)) {
                throw new Exception("ID é obrigatório");
            }

            return new Tag(Id, Descricao);
        }

        public static Tag AlterarTag(
            int Id,
            string Descricao
        )
        {
            Tag tag = GetTag(Id);

            if (!String.IsNullOrEmpty(Id)) {
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

        public static List<Tag> VisualizarTags()
        {
            return Models.Tag.GetTags();  
        }

        public static Tag GetTag(
            int Id
        )
        {
            List<Tag> tagsModels = Models.Tag.GetTags();
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

using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    public class SenhaTagController
    {
        public static SenhaTag InserirSenhaTag(
            int TagId,
            int SenhaId
        )
        {
            TagController.GetTag(TagId);
            SenhaController.GetSenha(SenhaId);

            return new SenhaTag(TagId, SenhaId);
        }

        public static SenhaTag GetSenhaTag(
            int SenhaId,
            int TagId
        )
        {
            return SenhaTag.GetSenhaTag(SenhaId, TagId);
        }

        public static IEnumerable<SenhaTag> GetSenhaTags()  
        {
            return SenhaTag.GetSenhaTags();
        }
    }
}

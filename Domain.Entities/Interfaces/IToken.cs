using Rgm.Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rgm.BusinessEntities.Entities;

namespace Rgm.Domain.Entities.Interfaces
{
    public interface IToken : IGeneric<TokenEntity>
    {
        TokenEntity GerarToken(string Login, string Senha, string appLogin, string appSenha, string appSecrect);
    }
}


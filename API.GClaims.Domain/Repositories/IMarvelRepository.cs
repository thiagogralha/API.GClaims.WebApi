using API.GClaims.Domain.Entities;
using API.GClaims.Domain.ValueObjects.Marvel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.GClaims.Domain.Repositories
{
    public interface IMarvelRepository
    {
        Task<List<MarvelVO>> ConsultaPersonagemMarvelAsync(MarvelEntity marvel);
    }
}

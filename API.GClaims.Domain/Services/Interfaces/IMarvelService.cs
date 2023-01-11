using API.GClaims.Domain.Entities;
using API.GClaims.Domain.ValueObjects.Marvel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.GClaims.Domain.Services.Interfaces
{
    public interface IMarvelService
    {
        Task<List<MarvelVO>> ConsultaPersonagemMarvelAsync(MarvelEntity marvel);
        Task<List<string>> AdicionarPersonagemMarvelAsync(FavoritoMarvelEntity marvel);
        bool RemoverPersonagemMarvel(FavoritoMarvelEntity marvel);
        List<string> ListarPersonagemMarvel(ListarFavoritoMarvelEntity marvel);
    }
}

using API.GClaims.Application;
using API.GClaims.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace API.GClaims.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarvelController : BaseController
    {

        private readonly MarvelApplication _marvelApplication;

        public MarvelController(MarvelApplication marvelApplication)
        {
            _marvelApplication = marvelApplication;
        }

        [HttpGet]
        [Route("consulta-personagem-marvel")]
        public async Task<IActionResult> ConsultaPersonagemMarvel(string name, int limit, int offset, string orderBy)
        {
            var dto = new MarvelDTO
            {
                name = name,
                limit = limit,
                offset = offset,
                orderBy = orderBy
            };

            var result = await _marvelApplication.ConsultaPersonagemMarvelAsync(dto);

            return CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("adicionar-personagem-favoritos")]
        public async Task<IActionResult> AdicionarPersonagemMarvel([FromBody] FavoritoMarvelDTO dto)
        {
            var result = await _marvelApplication.AdicionarPersonagemMarvelAsync(dto);           

            return CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("remover-personagem-favoritos")]
        public IActionResult RemoverPersonagemMarvel([FromBody] FavoritoMarvelDTO dto)
        {
            var result = _marvelApplication.RemoverPersonagemMarvel(dto);

            return CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("listar-personagem-favoritos/{ordernacaoDTO}")]
        public IActionResult ListarPersonagemMarvel(ListarFavoritoMarvelDTO.OrdernacaoDTO ordernacaoDTO)
        {
            var dto = new ListarFavoritoMarvelDTO
            {
                Ordenacao = ordernacaoDTO
            };

            var result = _marvelApplication.ListarPersonagemMarvel(dto);

            return CreateResponse(HttpStatusCode.OK, result);
        }

    }
}

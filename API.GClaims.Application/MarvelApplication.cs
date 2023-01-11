using API.GClaims.Domain.Exceptions;
using API.GClaims.Domain.Services.Interfaces;
using API.GClaims.Domain.ValueObjects.Marvel;
using API.GClaims.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.GClaims.Application
{
    public class MarvelApplication
    {
        private readonly IMarvelService _marvelService;

        public MarvelApplication(IMarvelService marvelService)
        {
            _marvelService = marvelService;
        }

        public async Task<List<MarvelVO>> ConsultaPersonagemMarvelAsync(MarvelDTO marvel)
        {
            try
            {
                return await _marvelService.ConsultaPersonagemMarvelAsync(marvel);
            }
            catch (Exception ex)
            {
                throw new Exception(UniversalErrorCode.U000.Code);
            }
        }

        public async Task<List<string>> AdicionarPersonagemMarvelAsync(FavoritoMarvelDTO marvel)
        {
            try
            {
                if (!marvel.Validate())
                    throw new ArgumentNullException(UniversalErrorCode.U000.Code);

                return await _marvelService.AdicionarPersonagemMarvelAsync(marvel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool RemoverPersonagemMarvel(FavoritoMarvelDTO marvel)
        {
            try
            {
                if (!marvel.Validate())
                    throw new ArgumentNullException(UniversalErrorCode.U000.Code);

                return _marvelService.RemoverPersonagemMarvel(marvel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<string> ListarPersonagemMarvel(ListarFavoritoMarvelDTO marvel)
        {
            try
            {
                return _marvelService.ListarPersonagemMarvel(marvel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

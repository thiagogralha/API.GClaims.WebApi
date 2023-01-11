using API.GClaims.Domain.Entities;
using API.GClaims.Domain.Repositories;
using API.GClaims.Domain.Services.Interfaces;
using API.GClaims.Domain.ValueObjects.Marvel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.GClaims.Domain.Services
{
    public class MarvelService : IMarvelService
    {
        private readonly IMarvelRepository _marvelRepository;
        public static List<string> listaDePersonagensFavoritos = new();

        public MarvelService(IMarvelRepository marvelRepository)
        {
            _marvelRepository = marvelRepository;
        }

        public async Task<List<MarvelVO>> ConsultaPersonagemMarvelAsync(MarvelEntity marvel)
        {
            if (marvel.limit == 0)
                marvel.limit = 10;

            var personagem = await _marvelRepository.ConsultaPersonagemMarvelAsync(marvel);

            return personagem;
        }

        public async Task<List<string>> AdicionarPersonagemMarvelAsync(FavoritoMarvelEntity marvel)
        {
            if (listaDePersonagensFavoritos.Count >= 5)
                throw new ArgumentNullException("Limite de 5 personagens atingido!");

            var consultaPersonagem = new MarvelEntity
            {
                name = marvel.name,
                limit = 1
            };

            var personagem = await _marvelRepository.ConsultaPersonagemMarvelAsync(consultaPersonagem);

            if (personagem.Count > 0)
                listaDePersonagensFavoritos.Add(personagem[0].name);

            return listaDePersonagensFavoritos;
        }

        public bool RemoverPersonagemMarvel(FavoritoMarvelEntity marvel)
        {          

            listaDePersonagensFavoritos.Remove(marvel.name);
            return true;
        }

        public List<string> ListarPersonagemMarvel(ListarFavoritoMarvelEntity marvel)
        {
            if (marvel.Ordenacao == ListarFavoritoMarvelEntity.OrdernacaoEntity.Desc)
                return listaDePersonagensFavoritos.OrderByDescending(x => x).ToList();

            return listaDePersonagensFavoritos.OrderBy(x => x).ToList();
        }
    }
}

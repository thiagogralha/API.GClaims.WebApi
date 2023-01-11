using API.GClaims.Domain.Entities;
using API.GClaims.Domain.Repositories;
using API.GClaims.Domain.ValueObjects.Marvel;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API.GClaims.Data.SqlServer.Repositories
{
    public class MarvelRepository : IMarvelRepository
    {
        private readonly IConfiguration configuration;
        private readonly HttpClient _httpClient;

        public MarvelRepository(IConfiguration configuration)
        {
            this.configuration = configuration;

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(configuration["MARVELAPI:URL_API"])
            };
        }

        public async Task<List<MarvelVO>> ConsultaPersonagemMarvelAsync(MarvelEntity client)
        {
            List<MarvelVO> personagens = new List<MarvelVO>();
            SetRequestHeaders();

            string ts = DateTime.Now.Ticks.ToString();
            string publicKey = configuration["MARVELAPI:PUBLICKEY"];

            string hash = GerarHash(ts, publicKey,
                   configuration["MARVELAPI:PRIVATEKEY"]);

            var filtroNome = string.Empty;
            if (!string.IsNullOrWhiteSpace(client.name))
                filtroNome = $"name={Uri.EscapeUriString(client.name)}";           

            var fullEndpoint = _httpClient.BaseAddress + 
                    $"characters?" +
                    $"ts={ts}&" +
                    $"apikey={publicKey}&" +
                    $"hash={hash}&" +
                    $"orderBy={client.orderBy}&" +
                    $"limit={client.limit}&" +
                    $"offset={client.offset}&" +
                    filtroNome;

            var response = await _httpClient.GetAsync(fullEndpoint);

            response.EnsureSuccessStatusCode();

            string result =
                response.Content.ReadAsStringAsync().Result;


            dynamic resultado = JsonConvert.DeserializeObject(result);

            if (resultado.data.count == 0)
                return new List<MarvelVO>();

            foreach (var item in resultado.data.results)
            {
                personagens.Add(new MarvelVO
                {
                    name = item.name,
                    personagemId = item.id

                });
            }

            return personagens;
        }

        private void SetRequestHeaders()
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

        }

        private string GerarHash(
           string ts, string publicKey, string privateKey)
        {
            byte[] bytes =
                Encoding.UTF8.GetBytes(ts + privateKey + publicKey);
            var gerador = MD5.Create();
            byte[] bytesHash = gerador.ComputeHash(bytes);
            return BitConverter.ToString(bytesHash)
                .ToLower().Replace("-", String.Empty);
        }

    }
}

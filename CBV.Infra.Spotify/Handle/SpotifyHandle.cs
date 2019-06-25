using CBV.Core.Application.Interfaces.Handle;
using CBV.Core.Application.Interfaces.Repositories;
using CBV.Core.Domain.Entities;
using CBV.Core.Domain.Enum;
using CBV.Core.Domain.Exception;
using CBV.Core.Domain.Shared;
using CBV.Infra.Spotify.Models;
using CBV.Infra.Spotify.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CBV.Core.Domain.Shared.Enumerators;

namespace CBV.Infra.Spotify.Handle
{
    public class SpotifyHandle : ISpotifyHandle
    {
        private readonly IHttpHandle _httpHandle;
        private readonly IJsonHandle _jsonHandle;
        private readonly SpotifySettings _spotifySettings;
        private readonly IDiscoRepository _discoRepository;

        public SpotifyHandle(IHttpHandle httpHandle, IJsonHandle jsonHandle, IOptions<SpotifySettings> spotifySettings, IDiscoRepository discoRepository)
        {
            _httpHandle = httpHandle;
            _jsonHandle = jsonHandle;
            _spotifySettings = spotifySettings.Value;
            _discoRepository = discoRepository;
        }

        public async Task InsertDiscs()
        {
            if (_discoRepository.Any())
                return;

            var token = await GetToken();
            var listGeneros = Enumerators.GetEnumDescriptions(typeof(GeneroEnum));
            var listDisco = Disco.ListEmpty();

            foreach (var item in listGeneros)
            {
                var list = await GetDiscsByGenre(token, item);
                listDisco.AddRange(list);
            }

            try
            {
                _discoRepository.AddList(listDisco);
            }
            catch (Exception ex)
            {
                var data = listDisco == null || !listDisco.Any()
                     ? "NULL"
                     : _jsonHandle.SerializeObject(listDisco);

                var error = ex.InnerException == null
                     ? ex.Message
                     : _jsonHandle.SerializeObject(ex.InnerException);

                DataException.ThrowInsertException("Disco", error, data);
            }
        }

        #region Auxiliary methods
        private async Task<string> GetToken()
        {
            var requestToken = HttpRequestToken.Build(_spotifySettings.TokenUrl, _spotifySettings.ClientId, _spotifySettings.ClientSecret);

            var response = await _httpHandle.GetTokenBasic(requestToken);

            if (!response.IsSuccess())
                HttpException.ThrowGetTokenException(_spotifySettings.TokenUrl, (int)response.StatusCode);

            var valueToken = _jsonHandle.DeserializeObject<SpotifyToken>(response.GetDataString());
            return valueToken.access_token;
        }

        private async Task<List<Disco>> GetDiscsByGenre(string token, EnumDescription genero)
        {
            var urlTrack = RestSearch.BuildUrlTrack(_spotifySettings.SearchUrl, genero.Value, _spotifySettings.MaximumLimitByGenre, 1);
            var response = await GetTracks(urlTrack, token);
            var listDisco = Disco.ListEmpty();

            foreach (var item in response?.tracks?.items)
            {
                var newObj = Disco.Build(genero.Key, item.name, item.GetNamesArtists());
                listDisco.Add(newObj);
            }

            return listDisco;
        }

        private async Task<ResponseTrack> GetTracks(string url, string token)
        {
            var response = await _httpHandle.GetAsync(url, token);

            if (!response.IsSuccess())
                HttpException.ThrowGetException(url, (int)response.StatusCode);

            return _jsonHandle.DeserializeObject<ResponseTrack>(response.GetDataString());
        }

        #endregion
    }
}

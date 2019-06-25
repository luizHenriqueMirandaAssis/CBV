using System;
using System.Collections.Generic;
using System.Text;

namespace CBV.Infra.Spotify.Settings
{
    public static class RestSearch
    {
        public static string BuildUrlTrack(string urlBase, string genero, int max, int offset)
        {
            return $"{urlBase}q=genre%3A{genero.ToLower()}&type=track&limit={max}&offset={offset}";
        }
    }
}

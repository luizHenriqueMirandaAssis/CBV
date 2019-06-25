namespace CBV.Infra.Spotify.Settings
{
    public class SpotifySettings
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string TokenUrl { get; set; }
        public string SearchUrl { get; set; }
        public int MaximumLimitByGenre { get; set; }
    }
}

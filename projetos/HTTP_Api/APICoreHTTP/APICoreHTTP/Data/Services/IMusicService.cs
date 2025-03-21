
using APICoreHTTP.Models;
using Microsoft.AspNetCore.Mvc;

namespace APICoreHTTP.Data.Services
{
    public interface IMusicService
    {
        public IEnumerable<Music> GetAllMusics();
        public IEnumerable<Music> GetAllMusicsByArtist(string artist);
        public IEnumerable<Music> GetMusicByName(string name);
        public Task AddMusic(Music music);
        public Task RemoveMusic(Music music);

    }
}

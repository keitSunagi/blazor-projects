
using APICoreHTTP.Models;

namespace APICoreHTTP.Data.Services
{
    public interface IMusicService
    {
        public IEnumerable<Music> GetAllMusics();
        public IEnumerable<Music> GetAllMusicsByArtist(string artist);
        public Music GetMusicByName(string name);
        public Task AddMusic(Music music);
        public Task RemoveMusic(Music music);

    }
}

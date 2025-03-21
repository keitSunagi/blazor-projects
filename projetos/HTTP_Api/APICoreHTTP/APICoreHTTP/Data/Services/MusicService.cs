using APICoreHTTP.Models;

namespace APICoreHTTP.Data.Services
{
    public class MusicService : IMusicService
    {
        private readonly MusicAppContext _context;

        public MusicService(MusicAppContext context)
        {
            _context = context;
        }

        public Task AddMusic(Music music)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Music> GetAllMusics()
        {
            try
            {
                return _context.Musics.ToList<Music>();

            }
            catch(Exception)
            {
                throw;
            }
        }

        public IEnumerable<Music> GetAllMusicsByArtist(string artist)
        {
            throw new NotImplementedException();
        }

        public Music GetMusicByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task RemoveMusic(Music music)
        {
            throw new NotImplementedException();
        }
    }
}

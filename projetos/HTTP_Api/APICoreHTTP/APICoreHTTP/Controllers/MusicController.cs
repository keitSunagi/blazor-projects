using APICoreHTTP.Data.Services;
using APICoreHTTP.Models;
using Microsoft.AspNetCore.Mvc;
namespace APICoreHTTP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _musicService;

        public MusicController(IMusicService musicservice)
        {
            _musicService = musicservice;
        }


        [HttpGet]
        public IEnumerable<Music> Get()
        {
            try
            {
                return _musicService.GetAllMusics();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("getbyname/{name}")]
        public Music GetByName(string name)
        {
            try
            {
                return _musicService.GetMusicByName(name);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

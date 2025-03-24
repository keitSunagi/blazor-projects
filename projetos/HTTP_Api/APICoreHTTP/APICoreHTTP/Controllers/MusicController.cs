using APICoreHTTP.Data.Services;
using APICoreHTTP.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public IEnumerable<Music> GetByName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                try
                {
                    return _musicService.GetMusicByName(name);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            else return null;
            
        }
        [HttpDelete("deleteMusic/{name}")]
        public async Task<ActionResult> DeleteMusic(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name)) return BadRequest("Nome não é válido");
                var music = _musicService.GetMusicByName(name);
                if (music is null) return NotFound("Música não encontrada");
                else
                {
                    await _musicService.RemoveMusic(music.First());
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: " + ex.Message);
            }
        }
        [HttpPut("add/{music}")]
        public async Task<IActionResult> AddMusic(Music music)
        {
            try
            {
                var resultMusic = new Music(music.Name, music.Artist, music.UrlMusic, music.Genre);
                if (resultMusic is null) return NotFound("Música inválida.");
                else
                {
                    await _musicService.AddMusic(resultMusic);
                    return Ok("Música adicionada com sucesso");
                }

            }catch(Exception ex)
            {
                return StatusCode(500, $"Erro interno: " + ex.Message);
            }
        }
    }
}

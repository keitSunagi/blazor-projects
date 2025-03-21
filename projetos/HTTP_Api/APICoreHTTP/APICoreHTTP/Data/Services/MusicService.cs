using APICoreHTTP.Exceptions;
using APICoreHTTP.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace APICoreHTTP.Data.Services
{
    public class MusicService : IMusicService
    {
        private readonly MusicAppContext _context;

        public MusicService(MusicAppContext context)
        {
            _context = context;
        }

        //Adiciona uma nova música.
        public async Task AddMusic(Music music)
        {
            try
            {
                await _context.Musics.AddAsync(music);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("[MusicService - AddMusic] Erro ao adicionar música : " + ex.Message);
            }
        }
        //Recupera todas as musicas.
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
        //Buscar por artista
        public IEnumerable<Music> GetAllMusicsByArtist(string artist)
        {
            try
            {
                return _context.Musics.Where(p => p.Artist == artist).ToList();
            }
            catch (Exception ex)
            {
                throw new OtherExceptions(" ERRO |MusicService.GetAllMusicsByArtist| " + ex.Message, ex.InnerException.Message);
            }
        }
        //Buscar por nome - Pode termais de uma música com mesmo nome
        public IEnumerable<Music> GetMusicByName(string name)
        {
            try
            {
                var musics = _context.Musics.Where(p => p.Name == name).ToList();
                if (musics == null)
                {
                    throw new MusicNotFoundException(name);
                }
                else return musics;
            }
            catch (Exception ex)
            {
                throw new OtherExceptions(" ERRO |MusicService.GetMusicByName| " + ex.Message, ex.InnerException.Message);
            }
        }
        //Remover Música
        public async Task RemoveMusic(Music music)
        {
            try
            {
               await _context.Musics.Where(p => p.Id == music.Id)
                    .ExecuteDeleteAsync();
               await _context.SaveChangesAsync();
                
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

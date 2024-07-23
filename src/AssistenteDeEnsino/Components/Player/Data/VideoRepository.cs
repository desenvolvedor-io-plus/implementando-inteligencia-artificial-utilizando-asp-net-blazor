using AssistenteDeEnsino.Data;
using Microsoft.EntityFrameworkCore;

namespace AssistenteDeEnsino.Components.Player.Data
{
    public class VideoRepository : IVideoRepository
    {
        private readonly AppDbContext _context;

        public VideoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Video>> GetAllAsync()
        {
            return await _context.Videos.ToListAsync();
        }

        public async Task<Video> GetByIdAsync(Guid id)
        {
            var vid = await _context.Videos.FindAsync(id);
            return vid ?? new Video();
        }

        public async Task<Video> GetBySlugAsync(string slug)
        {
            var vid = _context.Videos.Where(v=>v.Slug == slug).FirstOrDefault();
            return vid ?? new Video();
        }

        public async Task AddAsync(Video video)
        {
            await _context.Videos.AddAsync(video);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Video video)
        {
            _context.Videos.Update(video);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var video = await _context.Videos.FindAsync(id);
            if (video != null)
            {
                _context.Videos.Remove(video);
                await _context.SaveChangesAsync();
            }
        }
    }

}

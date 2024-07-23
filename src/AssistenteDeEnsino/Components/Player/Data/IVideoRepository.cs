namespace AssistenteDeEnsino.Components.Player.Data
{
    public interface IVideoRepository
    {
        Task<IEnumerable<Video>> GetAllAsync();
        Task<Video> GetByIdAsync(Guid id);
        Task<Video> GetBySlugAsync(string slug);
        Task AddAsync(Video video);
        Task UpdateAsync(Video video);
        Task DeleteAsync(Guid id);
    }

}

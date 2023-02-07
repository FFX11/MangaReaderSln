using DataLibrary.Models.MangaDex;

namespace MangaReader.Client.Services.MangaServices
{
    public interface IMangaService
    {
        Task<MangaGridModel> GetMangaById(List<string> ids);
        Task<MangaGridModel> GetMangaList(string fileRating);
        Task<GetChapters> GetChaptersByMangaId(string id, int chapterNum);
        Task<MangaCover> GetCover(string id);
        Task<MangaGridModel> SearchByTitle(string title);
        Task<ChapterModel> GetChapterById(string id);
        Task<GetChapter> GetChapter(string id);
        Task<GetChapters> GetChapters(string id);
    }
}

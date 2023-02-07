using DataLibrary.Models.MangaDex;
using System.Net.Http.Json;

namespace MangaReader.Client.Services.MangaServices
{
    public class MangaService : IMangaService
    {
        private readonly HttpClient _httpClient;
        public MangaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetChapter> GetChapter(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<GetChapter>($"chapter/{id}");
            if (result.result == null)
            {
                throw new Exception(result.result);
            }
            return result;
        }

        public async Task<ChapterModel> GetChapterById(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<ChapterModel>($"at-home/server/{id}");
            if (result.Result == null)
            {
                throw new Exception(result.Response);
            }
            return result;
        }

        public async Task<GetChapters> GetChapters(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<GetChapters>($"manga/{id}/feed?limit=50&translatedLanguage%5B%5D=en&order%5Bvolume%5D=asc&order%5Bchapter%5D=asc");
            if (result.result == null)
            {
                throw new Exception(result.response);
            }
            return result;
        }

        public async Task<GetChapters> GetChaptersByMangaId(string id, int chapterNum)
        {
            var result = await _httpClient.GetFromJsonAsync<GetChapters>($"manga/{id}/feed?limit={chapterNum}&translatedLanguage%5B%5D=en&order%5Bvolume%5D=asc&order%5Bchapter%5D=asc");
            if (result.data.Length < 0)
            {
                throw new Exception(result.response);
            }
            return result;
        }

        public async Task<MangaCover> GetCover(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<MangaCover>($"cover?limit=1&manga%5B%5D={id}&order%5BcreatedAt%5D=asc&order%5BupdatedAt%5D=asc&order%5Bvolume%5D=asc");
            if (result.Data.Length < 0)
            {
                throw new Exception(result.Response);
            }
            return result;
        }

        public async Task<MangaGridModel> GetMangaList(string fileRating)
        {
            var result = await _httpClient.GetFromJsonAsync<MangaGridModel>($"/manga?limit=10&includedTagsMode=AND&excludedTagsMode=OR&contentRating%5B%5D={fileRating}&order%5BlatestUploadedChapter%5D=desc&includes%5B%5D=cover_art&hasAvailableChapters=true");

            if (result.Data.Length < 0)
            {
                throw new Exception(result.Response);
            }
            return result;
        }

        public async Task<MangaGridModel> SearchByTitle(string title)
        {
            var result = await _httpClient.GetFromJsonAsync<MangaGridModel>($"manga?limit=10&title={title}&includedTagsMode=AND&excludedTagsMode=OR&contentRating%5B%5D=safe&contentRating%5B%5D=suggestive&contentRating%5B%5D=erotica&order%5BlatestUploadedChapter%5D=desc&includes%5B%5D=cover_art&hasAvailableChapters=true");

            if (result.Data.Length < 0)
            {
                throw new Exception(result.Response);
            }
            return result;
        }
        public async Task<MangaGridModel> GetMangaById(List<string> ids)
        {
            List<string> modIds = new();
            string modifiedId = string.Empty;
            string modifiedIds = string.Empty;

            foreach (var id in ids)
            {
                modifiedId = $"&ids%5B%5D={id}";

                modIds.Add(modifiedId);
            }
            modifiedIds = string.Join("", modIds);

            var result = await _httpClient.GetFromJsonAsync<MangaGridModel>($"manga?limit=100&includedTagsMode=AND&excludedTagsMode=OR{modifiedIds}&contentRating%5B%5D=safe&contentRating%5B%5D=suggestive&contentRating%5B%5D=erotica&order%5BlatestUploadedChapter%5D=desc&includes%5B%5D=cover_art&hasAvailableChapters=true");

            return result;
        }
    }
}

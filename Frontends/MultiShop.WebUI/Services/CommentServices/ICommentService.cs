
using MultiShop.DtoLayer.CatalogDtos.CommentDtos;

namespace MultiShop.WebUI.Services.CommentServices
{
    public interface ICommentService
    {
        Task<List<ResultCommentDto>> GetAllCommentAsync();
        Task<List<ResultCommentDto>> CommentListByProductId(string id); //Veritabanı olarak sql tuttuğumuz için id değeri int olacak
        Task CreateCommentAsync(CreateCommentDto createCommentDto);
        Task UpdateCommentAsync(UpdateCommentDto updateCommentDto);
        Task DeleteCommentAsync(string id);
        Task<UpdateCommentDto> GetByIdCommentAsync(string id);
    }
}

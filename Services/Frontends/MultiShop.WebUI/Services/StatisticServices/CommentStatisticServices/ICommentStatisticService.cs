namespace MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices
{
    public interface ICommentStatisticService
    {
        Task<int> GetCommentTotalCount();
        Task<int> GetCommentConfirmedCount();
        Task<int> GetCommentUnconfirmedCount();
    }
}

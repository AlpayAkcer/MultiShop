using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public interface IUserMessageService
    {
        Task<List<ResultMessageDto>> GetAllMessageAsync();
        Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id); //Gelen Mesajlar
        Task<List<ResultSendBoxMessageDto>> GetSendBoxMessageAsync(string id); //Giden Mesajlar
        Task CreateMessageAsync(CreateMessageDto createMessageDto);
        Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
        Task DeleteMessageAsync(int id);
        Task<GetByIdMessageDto> GetByIdMessageAsync(int id);
        Task<int> GetTotalMessageCount();   //Toplam Gelen Mesaj Sayısı
        Task<int> GetTotalMessageReadCount(); // Okunan mesaj sayısı
        Task<int> GetTotalMessageUnReadCount(); // Okunmayan Mesaj sayısı
        Task<int> GetTotalMessageByReceiverId(string id); // Giriş yapan kullanıcıya göre toplam mesaj sayısını alacak.
    }
}

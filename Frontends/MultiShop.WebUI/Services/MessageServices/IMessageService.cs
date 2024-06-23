using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Services.MessageServices
{
    public interface IMessageService
    {
        Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id); //Gelen Mesajlar
        Task<List<ResultSendBoxMessageDto>> GetSendBoxMessageAsync(string id); //Giden Mesajlar
        //Task CreateMessageAsync(CreateMessageDto createMessageDto);
        //Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
        //Task DeleteMessageAsync(int id);
        //Task<GetByIdMessageDto> GetByIdMessageAsync(int id);
        
        Task<int> GetTotalMessageByReceiverId(string id);
    }
}

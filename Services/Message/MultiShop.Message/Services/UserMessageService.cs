﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DAL.Context;
using MultiShop.Message.DAL.Entities;
using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public class UserMessageService : IUserMessageService
    {
        private readonly MessageContext _messageContext;
        private readonly IMapper _mapper;

        public UserMessageService(MessageContext messageContext, IMapper mapper)
        {
            _messageContext = messageContext;
            _mapper = mapper;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            var value = _mapper.Map<UserMessage>(createMessageDto);
            await _messageContext.UserMessages.AddAsync(value);
            await _messageContext.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(int id)
        {
            var value = await _messageContext.UserMessages.FindAsync(id);
            _messageContext.UserMessages.Remove(value);
            await _messageContext.SaveChangesAsync();
        }

        public async Task<List<ResultMessageDto>> GetAllMessageAsync()
        {
            var value = await _messageContext.UserMessages.ToListAsync();
            return _mapper.Map<List<ResultMessageDto>>(value);
        }

        public async Task<GetByIdMessageDto> GetByIdMessageAsync(int id)
        {
            var value = await _messageContext.UserMessages.FindAsync(id);
            return _mapper.Map<GetByIdMessageDto>(value);
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id)
        {
            var value = await _messageContext.UserMessages.Where(x => x.ReceiverId == id).ToListAsync();
            return _mapper.Map<List<ResultInboxMessageDto>>(value);
        }

        public async Task<List<ResultSendBoxMessageDto>> GetSendBoxMessageAsync(string id)
        {
            var value = await _messageContext.UserMessages.Where(x => x.SenderId == id).ToListAsync();
            return _mapper.Map<List<ResultSendBoxMessageDto>>(value);
        }

        public async Task<int> GetTotalMessageByReceiverId(string id)
        {
            var values = await _messageContext.UserMessages.Where(x => x.ReceiverId == id).CountAsync();
            return values;
        }

        public async Task<int> GetTotalMessageCount()
        {
            int valueCount = await _messageContext.UserMessages.CountAsync();
            return valueCount;
        }

        public async Task<int> GetTotalMessageReadCount()
        {
            int valueCount = await _messageContext.UserMessages.Where(x => x.IsRead == true).CountAsync();
            return valueCount;
        }

        public async Task<int> GetTotalMessageUnReadCount()
        {
            int valueCount = await _messageContext.UserMessages.Where(x => x.IsRead == false).CountAsync();
            return valueCount;
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            var value = _mapper.Map<UserMessage>(updateMessageDto);
            _messageContext.UserMessages.Update(value);
            await _messageContext.SaveChangesAsync();
        }
    }
}

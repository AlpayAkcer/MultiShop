using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.MessageServices;
using MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices;
using System.Runtime.CompilerServices;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponent
{
    public class _AdminLayoutHeaderComponentPartial : ViewComponent
    {
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;
        private readonly ICommentStatisticService _commentStatisticService;
        public _AdminLayoutHeaderComponentPartial(IUserService userService, IMessageService messageService, ICommentStatisticService commentStatisticService)
        {
            _userService = userService;
            _messageService = messageService;
            _commentStatisticService = commentStatisticService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _userService.GetUserInfo();
            var messageCount = await _messageService.GetTotalMessageByReceiverId(value.Id);
            ViewBag.MessageCount = messageCount;

            var commentCount = await _commentStatisticService.GetCommentTotalCount();
            ViewBag.CommentCount = commentCount;
            return View(value);
        }
    }
}

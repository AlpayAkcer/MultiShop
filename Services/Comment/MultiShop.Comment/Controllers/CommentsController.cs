using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _commentContext;

        public CommentsController(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var value = _commentContext.UserComments.ToList();
            return Ok(value);
        }

        [HttpGet("CommentListByProductId/{id}")]
        public IActionResult CommentListByProductId(string id)
        {
            var value = _commentContext.UserComments.Where(x => x.ProductId == id).ToList();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetCommentById(int id)
        {
            var value = _commentContext.UserComments.Find(id);
            return Ok(value);
        }

        [HttpGet("ChangeStatus/{id}")]
        public IActionResult ChangeStatus(int id)
        {
            var value = _commentContext.UserComments.Find(id);
            if (value.Status == true)
            {
                value.Status = false;
            }
            else
            {
                value.Status = true;
            }
            _commentContext.UserComments.Update(value);
            _commentContext.SaveChanges();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateComment(UserComment userComment)
        {
            _commentContext.UserComments.Add(userComment);
            _commentContext.SaveChanges();
            return Ok("Yorum Başarıyla Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var value = _commentContext.UserComments.Find(id);
            _commentContext.UserComments.Remove(value);
            _commentContext.SaveChanges();
            return Ok("Yorum Başarıyla Silindi");
        }

        [HttpPut]
        public IActionResult UpdateComment(UserComment userComment)
        {
            _commentContext.UserComments.Update(userComment);
            _commentContext.SaveChanges();
            return Ok("Yorum Başarıyla Güncellendi");
        }

        [HttpGet("GetCommentTotalCount")]
        public IActionResult GetCommentTotalCount()
        {
            var value = _commentContext.UserComments.Count();
            return Ok(value);
        }

        [HttpGet("GetCommentConfirmedCount")]
        public IActionResult GetCommentConfirmedCount()
        {
            int commentConfirmedCount = _commentContext.UserComments.Where(x => x.Status == true).Count();
            return Ok(commentConfirmedCount);
        }

        [HttpGet("GetCommentUnconfirmedCount")]
        public IActionResult GetCommentUnconfirmedCount()
        {
            int commentUnConfirmedCount = _commentContext.UserComments.Where(x => x.Status == false).Count();
            return Ok(commentUnConfirmedCount);
        }
    }
}

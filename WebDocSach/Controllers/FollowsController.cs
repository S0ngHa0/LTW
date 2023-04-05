using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebDocSach.DTOs;
using WebDocSach.Models;

namespace WebDocSach.Controllers
{
    public class FollowsController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public FollowsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        [Authorize]
        public IHttpActionResult Follow (FollowBook followBook)
        {
            var userId = User.Identity.GetUserId();
            var follow = new Follow
            {
                BookId = followBook.BookId,
                FolloweeId = userId
            };
            Follow find = _dbContext.Follows.FirstOrDefault(f => f.FolloweeId == userId && f.BookId == followBook.BookId);
            if (find == null)
            {
                _dbContext.Follows.Add(follow);
            }
            else
            {
                _dbContext.Follows.Remove(find);
            }
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDocSach.Models
{
    public class Follow
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public ApplicationUser Followee { get; set; }
        public string FolloweeId { get; set; }
    }
}
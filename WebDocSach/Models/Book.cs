using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDocSach.Models
{
    public class Book 
    {
        public int Id { get; set; }
        public ApplicationUser UserName { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        [StringLength(255)]
        public string TenSach { get; set; }
        public TheLoai TheLoai { get; set; }
        public byte IdTheLoai { get; set; }
        [Required]
        [StringLength(255)]
        public string TacGia { get; set; }
        public string NoiDung { get; set; }
        [Required]
        [StringLength(255)]
        public string HinhAnh { get; set; }
        public string TinhTrang { get; set; }
        public string NgayTao { get; set; }
        public string Nguon { get; set; }
        //
        public List<TheLoai> ListTheLoai = new List<TheLoai>();
        public static Book FindBookById (int id)
        {
            ApplicationDbContext _dbContext = new ApplicationDbContext();
            return _dbContext.Books.FirstOrDefault(p => p.Id == id);
        }
        public bool isShowFollow = false;
    }
}
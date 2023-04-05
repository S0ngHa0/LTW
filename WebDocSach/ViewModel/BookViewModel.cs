using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using WebDocSach.Models;
using System.ComponentModel.DataAnnotations;


namespace WebDocSach.ViewModel
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string TenSach { get; set; }
        public string TacGia { get; set; }
        public string NoiDung { get; set; }
        public string HinhAnh { get; set; }
        public string TinhTrang { get; set; }
        public byte TheLoai { get; set; }
        public string NgayTao { get; set; }
        public string Nguon { get; set; }
        public IEnumerable<TheLoai> theloais { get; set; }

    }
}
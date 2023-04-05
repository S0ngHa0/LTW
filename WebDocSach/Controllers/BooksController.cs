using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDocSach.Models;
using WebDocSach.ViewModel;

namespace WebDocSach.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext _dbContext;
        public BooksController ()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Books
        [Authorize]
        public ActionResult Index()
        {
            var books = _dbContext.Books
                .Include("TheLoai")
                .ToList();

            var loginUser = User.Identity.GetUserId();
            ViewBag.LoginUser = loginUser;
            foreach (Book i in books)
            {
                Follow find = _dbContext.Follows.FirstOrDefault(f => f.FolloweeId == loginUser && f.BookId == i.Id);
                if (find == null)
                {
                    i.isShowFollow = true;
                }
            }
            return View(books);
        }
        public ActionResult Create()
        {
            Book book = new Book();
            book.ListTheLoai = _dbContext.TheLoais.ToList();
            return View(book);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>()
                .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            book.UserId = user.Id;

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Books");
        }

        [Authorize]
        public ActionResult Detail(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Book find = Book.FindBookById(id.Value);
            if (find == null)
                return HttpNotFound();
            return View(find);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var books = _dbContext.Books.Single(c => c.Id == id && c.UserId == userId);
            var viewModel = new BookViewModel
            {
                TenSach = books.TenSach,
                TacGia = books.TacGia,
                NoiDung = books.NoiDung,
                theloais = _dbContext.TheLoais.ToList(),
                TheLoai = books.IdTheLoai,
                HinhAnh = books.HinhAnh,
                TinhTrang = books.TinhTrang,
                NgayTao = books.NgayTao,
                Nguon = books.Nguon,
                Id = books.Id
            };
            return View("Edit",viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.theloais = _dbContext.TheLoais.ToList();
                return View(viewModel);
            }
            var userId = User.Identity.GetUserId();
            var books = _dbContext.Books.Single(c => c.Id == viewModel.Id && c.UserId == userId);
            books.TenSach = viewModel.TenSach;
            books.TacGia = viewModel.TacGia;
            books.NoiDung = viewModel.NoiDung;
            books.IdTheLoai = viewModel.TheLoai;
            books.TinhTrang = viewModel.TinhTrang;
            books.HinhAnh = viewModel.HinhAnh;
            books.NgayTao = viewModel.NgayTao;
            books.Nguon = viewModel.Nguon;
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Books");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            Book books = _dbContext.Books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }


        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                Book books = _dbContext.Books.Find(id);
                _dbContext.Books.Remove(books);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index", "Books");
        }


        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/Img/" + file.FileName));
            return "/Content/Img/" + file.FileName;
        }


    }

}
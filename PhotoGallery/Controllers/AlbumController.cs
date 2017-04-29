using Common.DTO;
using DataAccess;
using Infrastructure.IServices;
using PhotoGallery.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using static PhotoGallery.Models.GalleryViewModel;

namespace PhotoGallery.Controllers
{
    public class AlbumController : Controller
    {
        private IAlbumService _albumService;
        private IUserService _userService;
        private IPhotoService _photoService;

        public AlbumController(IAlbumService albumService, IUserService userService, IPhotoService photoService)
        {
            _albumService = albumService;
            _userService = userService;
            _photoService = photoService;
        }

        // GET: Album/AllAlbums
        public ActionResult AllAlbums()
        {
            var model = new AlbumSearchViewModel();
            model.SearchResults = _albumService.GetAllAlbums();
            return View(model);
        }

        // POST: Album/AllAlbums
        [HttpPost]
        public ActionResult AllAlbums(AlbumSearchViewModel model)
        {
            var albums = _albumService.GetAllAlbums();

            if (!string.IsNullOrWhiteSpace(model.SearchWord))
            {
                albums = albums.Where(b => b.AlbumName.ToLower().Contains(model.SearchWord.ToLower())).ToList();
            }

            if (model.CategoryId > 0)
            {
                albums = albums.Where(x => x.CategoryId == model.CategoryId).ToList();
            }

            model.SearchResults = albums;

            return View(model);
        }

        [ChildActionOnly]
        public PartialViewResult GetCategories()
        {
            return PartialView(new CategoryList());
        }

        //
        // GET: Album/CreateAlbum
        public ActionResult MyAlbums()
        {

            if (Session["User"] != null)
            {
                var currentUser = this.Session["User"] as UserDTO;
                var userId = currentUser.Id;

                var model = new AlbumSearchViewModel();
                model.SearchResults = _albumService.GetAllAlbums().Where(x => x.UserId == userId).ToList();

                return View(model);
            }
            else
                return RedirectToAction("Login", "Account");
        }

        // POST: Album/AllAlbums
        [HttpPost]
        public ActionResult MyAlbums(AlbumSearchViewModel model)
        {
            var currentUser = this.Session["User"] as UserDTO;
            var userId = currentUser.Id;

            var albums = _albumService.GetAllAlbums().Where(x => x.UserId == userId).ToList();

            model.SearchResults = albums;

            return View(model);
        }

        //
        // GET: Album/CreateAlbum
        public ActionResult CreateAlbum()
        {
            if (Session["User"] != null)
                return View();
            else
                return RedirectToAction("Login", "Account");
        }

        //
        // POST: Album/CreateAlbum
        [HttpPost]
        public ActionResult CreateAlbum(AlbumCreateViewModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid && file != null && file.ContentLength > 0)
            {
                var currentUser = Session["User"] as UserDTO;

                MemoryStream fileContent = new MemoryStream();
                file.InputStream.CopyTo(fileContent);

                _albumService.InsertAlbum(new AlbumDTO
                {
                    AlbumName = model.AlbumName,
                    AlbumImage = fileContent.ToArray(),
                    UserId = currentUser.Id,
                    CategoryId = model.CategoryId
                });
                return RedirectToAction("AllAlbums", "Album");
            }
            return View(model);
        }

        //
        // GET: Album/Details
        public ActionResult Details(int id)
        {
            var album = _albumService.GetAlbum(id);
            var user = _userService.GetUserById(album.UserId);
            var photos = _photoService.GetAllAlbumPhotos(album.Id);

            var model = new AlbumDetailsViewModel()
            {
                Id = album.Id,
                AlbumName = album.AlbumName,
                AlbumImage = album.AlbumImage,
                UserDetails = user,
                Photos = photos
            };

            return View(model);
        }
    }
}
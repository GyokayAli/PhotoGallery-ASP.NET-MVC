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
        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
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
        public ActionResult CreateAlbum()
        {
            return View();
        }

        //
        // POST: Album/CreateAlbum
        [HttpPost]
        public ActionResult CreateAlbum(AlbumCreateViewModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid && file != null && file.ContentLength > 0)
            {
                MemoryStream fileContent = new MemoryStream();
                file.InputStream.CopyTo(fileContent);

                _albumService.InsertAlbum(new AlbumDTO
                {
                    AlbumName = model.AlbumName,
                    AlbumImage = fileContent.ToArray(),
                    UserId = model.UserId,
                    CategoryId = model.CategoryId
                });
                return RedirectToAction("AllAlbums", "Gallery");
            }
            return View(model);
        }
    }
}
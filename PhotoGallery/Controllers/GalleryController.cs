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
    public class GalleryController : Controller
    {
        private IAlbumService _albumService;
        public GalleryController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        // GET: Gallery/AllAlbums
        public ActionResult AllAlbums()
        {
            var albums = _albumService.GetAllAlbums();

            return View(albums);
        }

        [ChildActionOnly]
        public PartialViewResult GetCategories()
        {
            return PartialView(new CategoryList());
        }

        //
        // GET: Gallery/CreateAlbum
        public ActionResult CreateAlbum()
        {
            return View();
        }

        //
        // POST: Gallery/CreateAlbum
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
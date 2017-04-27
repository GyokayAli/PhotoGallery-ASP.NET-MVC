using DataAccess;
using PhotoGallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PhotoGallery.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery/AllAlbums
        public ActionResult AllAlbums()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult GetCategories()
        {
            return PartialView(new CategoryList());
        }

        [HttpGet]
        public ActionResult CreateAlbum()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAlbum(AlbumCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var db = new PhotoGalleryEntities();

                db.Albums.Add(new Album()
                {
                    ALBUM_NAME = model.AlbumName,
                    ALBUM_IMG = Encoding.ASCII.GetBytes(model.AlbumImage),
                    USER_ID = model.UserId,
                    CATEGORY_ID = model.CategoryId
                });
                db.SaveChanges();
            }
            return View();
        }
    }
}
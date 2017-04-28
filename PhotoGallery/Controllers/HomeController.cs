using DataAccess;
using Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoGallery.Controllers
{
    public class HomeController : Controller
    {
        private IAlbumService _albumService;
        public HomeController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public ActionResult Index()
        {
            // get latest 3 albums
            var albums = _albumService.GetLatestAlbums(3);
            return View(albums);
        }
    }
}
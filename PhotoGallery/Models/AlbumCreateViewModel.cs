using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoGallery.Models
{
    public class AlbumCreateViewModel
    {
        public string AlbumName { get; set; }
        public string AlbumImage { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
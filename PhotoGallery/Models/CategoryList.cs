using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoGallery.Models
{
    public class CategoryList
    {
        PhotoGalleryEntities db = new PhotoGalleryEntities();

        public int DDLCategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories
        {
            get
            {
                return db.Categories.Select(x =>
                      new SelectListItem
                      {
                          Value = x.ID.ToString(),
                          Text = x.CATEGORY_NAME
                      }).ToList();
            }
            set { }
        }
    }
}
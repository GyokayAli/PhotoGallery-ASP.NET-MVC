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
        public int CategoryItemId { get; set; }
        public IEnumerable<SelectListItem> Categories
        {
            get
            {
                return new[] { new SelectListItem { Value = "0", Text = "Select Category", Selected=true }}.Concat(
                    new PhotoGalleryEntities().Categories.Select(x =>
                      new SelectListItem
                      {
                          Value = x.ID.ToString(),
                          Text = x.CATEGORY_NAME
                      }).ToList()
                );
            }
            set {}
        }
    }
}
using Common.DTO;
using Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoGallery.Models
{
    public class GalleryViewModel
    {

        public class AlbumCreateViewModel
        {
            [Required]
            [Display(Name = "Album Name")]
            public string AlbumName { get; set; }

            public int UserId { get; set; }

            [Required]
            [Display(Name = "Category")]
            public int CategoryId { get; set; }
        }

        public class AlbumListViewModel
        {
            public int Id;

            [Display(Name = "Album Name")]
            public string AlbumName { get; set; }

            [Display(Name = "Album Image")]
            public byte[] AlbumImage { get; set; }
        }

        public class AlbumSearchViewModel
        {
            [Display(Name = "Search")]
            public string SearchWord { get; set; }

            [Display(Name = "Category")]
            public int CategoryId { get; set; }

            public List<AlbumDTO> SearchResults { get; set; }

            public AlbumSearchViewModel()
            {
                SearchResults = new List<AlbumDTO>();
            }
        }
    }
}
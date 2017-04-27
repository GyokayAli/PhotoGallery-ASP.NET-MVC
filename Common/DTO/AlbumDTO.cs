using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class AlbumDTO
    {
        public int Id { get; set; }
        public string AlbumName { get; set; }
        public byte[] AlbumImage { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}

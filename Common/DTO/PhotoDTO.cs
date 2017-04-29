using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class PhotoDTO
    {
        public int Id { get; set; }
        public string PhotoName { get; set; }
        public byte[] PhotoImage { get; set; }
        public int AlbumId { get; set; }
    }
}

using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IServices
{
    public interface IPhotoService
    {
        List<PhotoDTO> GetAllPhotos();

        List<PhotoDTO> GetAllAlbumPhotos(int albumId);

        void InsertPhoto(PhotoDTO dto);
    }
}

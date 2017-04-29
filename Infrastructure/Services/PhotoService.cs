using Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTO;
using DataAccess;
using DataAccess.GenericRepository;

namespace Infrastructure.Services
{
    public class PhotoService : IPhotoService
    {
        private GenericRepository<Photo> _repo;

        public PhotoService()
        {
            _repo = new GenericRepository<Photo>();
        }

        public List<PhotoDTO> GetAllPhotos()
        {
            return AutoMapper.Mapper
                .Map<List<PhotoDTO>>(_repo
                .GetAllRecords()
                .ToList());
        }

        public List<PhotoDTO> GetAllAlbumPhotos(int albumId)
        {
            return AutoMapper.Mapper
                .Map<List<PhotoDTO>>(_repo
                .GetAllRecords()
                .Where(x => x.ALBUM_ID == albumId)
                .ToList());
        }
        
        public void InsertPhoto(PhotoDTO dto)
        {
            var entity = new Photo()
            {
                ID = dto.Id,
                PHOTO_NAME = dto.PhotoName,
                PHOTO_IMG = dto.PhotoImage,
                ALBUM_ID = dto.AlbumId
            };
            _repo.InsertSaveRecord(entity);
        }
    }
}

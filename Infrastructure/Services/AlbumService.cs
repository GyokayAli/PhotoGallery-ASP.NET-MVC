namespace Infrastructure.Services
{
    using Common.DTO;
    using DataAccess;
    using DataAccess.GenericRepository;
    using Infrastructure.IServices;
    using System.Collections.Generic;
    using System.Linq;

    public class AlbumService : IAlbumService
    {
        private GenericRepository<Album> _repo;

        public AlbumService()
        {
            _repo = new GenericRepository<Album>();
        }

        public AlbumDTO GetAlbum(int id)
        {
            AlbumDTO dto = new AlbumDTO();
            if (id != 0)
            {
                dto = AutoMapper.Mapper
                     .Map<AlbumDTO>(_repo
                     .GetAllRecords()
                     .Where(x => x.ID == id)
                     .SingleOrDefault());
            }

            return dto;
        }

        public List<AlbumDTO> GetAllAlbums()
        {
            return AutoMapper.Mapper
                .Map<List<AlbumDTO>>(_repo
                .GetAllRecords()
                .ToList());
        }

        public List<AlbumDTO> GetLatestAlbums(int n)
        {
            return AutoMapper.Mapper
                .Map<List<AlbumDTO>>(_repo
                .GetAllRecords()
                .OrderByDescending(x => x.ID)
                .Take(n)
                .ToList());
        }

        public void InsertAlbum(AlbumDTO dto)
        {
            var entity = new Album()
            {
                ID = dto.Id,
                ALBUM_NAME = dto.AlbumName,
                ALBUM_IMG = dto.AlbumImage,
                USER_ID = dto.UserId,
                CATEGORY_ID = dto.CategoryId
            };
            _repo.InsertSaveRecord(entity);
        }
    }
}

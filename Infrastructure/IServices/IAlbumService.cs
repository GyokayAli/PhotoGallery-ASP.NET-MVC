namespace Infrastructure.IServices
{
    using Common.DTO;
    using System.Collections.Generic;

    public interface IAlbumService
    {
        List<AlbumDTO> GetAllAlbums();

        void InsertAlbum(AlbumDTO dto);
    }
}

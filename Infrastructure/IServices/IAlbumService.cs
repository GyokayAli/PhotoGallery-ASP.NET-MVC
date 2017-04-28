namespace Infrastructure.IServices
{
    using Common.DTO;
    using System.Collections.Generic;

    public interface IAlbumService
    {
        List<AlbumDTO> GetAllAlbums();

        List<AlbumDTO> GetLatestAlbums(int n);

        void InsertAlbum(AlbumDTO dto);
    }
}

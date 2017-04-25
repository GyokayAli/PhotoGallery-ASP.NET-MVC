namespace Infrastructure.IServices
{
    using Common.DTO;
    using DataAccess;
    using System.Collections.Generic;

    public interface IUserService
    {
        List<UserDTO> GetAllUsers();

        void InsertUser(UserDTO dto);
    }
}

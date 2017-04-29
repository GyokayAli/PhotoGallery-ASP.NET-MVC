namespace Infrastructure.IServices
{
    using Common.DTO;
    using System.Collections.Generic;

    public interface IUserService
    {
        List<UserDTO> GetAllUsers();

        UserDTO GetUserByEmail(string email);
        UserDTO GetUserById(int id);

        void InsertUser(UserDTO dto);
    }
}

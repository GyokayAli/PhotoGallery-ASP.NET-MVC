namespace Infrastructure.Services
{
    using Common.DTO;
    using DataAccess;
    using DataAccess.GenericRepository;
    using Infrastructure.IServices;
    using System.Collections.Generic;
    using System.Linq;

    public class UserService : IUserService
    {
        private GenericRepository<User> _repo;

        public UserService()
        {
            _repo = new GenericRepository<User>();
        }
        
        public List<UserDTO> GetAllUsers()
        {
            return AutoMapper.Mapper
                .Map<List<UserDTO>>(_repo
                .GetAllRecords()
                .ToList());
        }

        public void InsertUser(UserDTO dto)
        {
            var entity = new User()
            {
                ID = dto.Id,
                FIRST_NAME = dto.FirstName,
                LAST_NAME = dto.LastName,
                EMAIL = dto.Email,
                PASS = dto.Password,
            };
            _repo.InsertSaveRecord(entity);
        }
    }
}


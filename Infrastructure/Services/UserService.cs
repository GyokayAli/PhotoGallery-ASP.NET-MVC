namespace Infrastructure.Services
{
    using Common.DTO;
    using DataAccess;
    using DataAccess.GenericRepository;
    using Infrastructure.IServices;
    using System.Collections.Generic;
    using System.Linq;
    using System;

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

        public UserDTO GetUserByEmail(string email)
        {
            UserDTO dto = new UserDTO();
            if (!string.IsNullOrWhiteSpace(email))
            {
                dto = AutoMapper.Mapper
                     .Map<UserDTO>(_repo
                     .GetAllRecords()
                     .Where(x => x.EMAIL == email)
                     .SingleOrDefault());
            }

            return dto;
        }

        public UserDTO GetUserById(int id)
        {
            UserDTO dto = new UserDTO();
            if (id != 0)
            {
                dto = AutoMapper.Mapper
                     .Map<UserDTO>(_repo
                     .GetAllRecords()
                     .Where(x => x.ID == id)
                     .SingleOrDefault());
            }

            return dto;
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


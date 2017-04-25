namespace Infrastructure.Services
{
    using Common.DTO;
    using DataAccess;
    using DataAccess.GenericRepository;
    using Infrastructure.IServices;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserService : IUserService
    {
        private GenericRepository<Users> _repo;

        public UserService()
        {
            _repo = new GenericRepository<Users>();
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
            Users entity = new Users()
            {
                ID = dto.Id,
                USERNAME = dto.Username,
                EMAIL = dto.Email,
                PASS = dto.Password,
            };
            _repo.InsertSaveRecord(entity);
        }
    }
}


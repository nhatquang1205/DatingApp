using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatingApp.API.Database.Entities;
using DatingApp.API.DTOs;

namespace DatingApp.API.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserRepository(DataContext context, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;

        }

        public void CreateUser(User user)
        {
            if(this.GetUserByUsername(user.Username) != null) return;
            _context.Add(user);
        }

        public MemberDto GetMemberByUsername(string username)
        {
            return _context.Users
                    .Where(u => u.Username.Equals(username))
                    .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefault();
        }

        public IEnumerable<MemberDto> GetMembers()
        {
            return _context.Users
                    .ProjectTo<MemberDto>(_mapper.ConfigurationProvider);
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User GetUserByUsername(string username)
        {
             return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }
    }
}
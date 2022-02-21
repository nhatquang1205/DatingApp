using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Database.Entities;
using DatingApp.API.DTOs;

namespace DatingApp.API.Database.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        
        User GetUserByUsername(string username);
        User GetUserById(int id);
        bool SaveChanges();
        void CreateUser(User user);
        IEnumerable<MemberDto> GetMembers();
        MemberDto GetMemberByUsername(string username);

    }
}
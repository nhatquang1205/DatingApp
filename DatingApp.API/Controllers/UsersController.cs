using System.Collections.Generic;
using AutoMapper;
using DatingApp.API.Database.Entities;
using DatingApp.API.Database.Repositories;
using DatingApp.API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        [HttpGet]
        public  ActionResult<IEnumerable<MemberDto>> GetUsers()
        {

            return Ok(_userRepository.GetMembers());
        }
        // [HttpGet("{id}")]
        // public ActionResult<User> GetUsers(int id)
        // {
        //     var user = _userRepository.GetUserById(id);
        //     if (user == null)
        //     {
        //         return NotFound();
        //     }
        //     return Ok(user);
        // }
        [HttpGet("{username}")]
        public ActionResult<MemberDto> GetUsers(string username)
        {
            var member = _userRepository.GetMemberByUsername(username);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);
        }
    }
}
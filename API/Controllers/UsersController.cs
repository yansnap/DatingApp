using API.Data;
using API.DTOs;
using API.Entitites;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
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
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
               =>  Ok(await _userRepository.GetMembersAsync());

        // api/users/3 - get user under 3 id
        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username) 
            => await _userRepository.GetMemberAsync(username);
           
        

    }
}
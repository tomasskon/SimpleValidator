using System;
using AutoMapper;
using LibraryImplementation.Contracts.User;
using LibraryImplementation.Domain.Models;
using LibraryImplementation.Server.Attributes;
using LibraryImplementation.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryImplementation.Server.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    [ExceptionHandling]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [HttpGet]
        public IActionResult GetById(Guid userId)
        {
            return Ok(_userService.Get(userId));
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserContract user)
        {
            return Ok(_userService.Create(_mapper.Map<User>(user)));
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserContract user)
        {
            _userService.Update(_mapper.Map<User>(user));

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteUser(Guid userId)
        {
            _userService.Delete(userId);

            return Ok();
        }
    }
}
﻿using AutoMapper;
using ManageStore.BusinessAccess;
using ManageStore.BusinessAccess.Helper;
using ManageStore.Models.DTO;
using ManageStore.Models.Enum;
using ManageStore.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ManageStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokenFactory _tokenFactory;

        public AccountController(IUnitOfWork unitOfWork, IMapper mapper, ITokenFactory tokenFactory)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenFactory = tokenFactory;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            var account = await _unitOfWork.Users.GetByUserNameAsync(userDto.UserName);
            if (account != null)
                return BadRequest($"Account with username :{userDto.UserName} already registered.");
            var user = _mapper.Map<User>(userDto);
            user.CreatedDateTime = DateTime.Now;
            user.RegisterStatus = RegisterStatus.Enabled;
            user.Password = user.Password.ToSha256();
            user.CreatedBy = await _unitOfWork.Users.GetAsync(1);
            _unitOfWork.Users.Add(user);
            await _unitOfWork.Complete();
            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserDto userDto)
        {
            var user = await _unitOfWork.Users.FindByCredentials(userDto.UserName, userDto.Password.ToSha256());
            if (user == null)
                return BadRequest($"Account with username and password :{userDto.UserName} not found.");

            var token = _tokenFactory.GenerateToken(user.UserName, user.UserRole);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
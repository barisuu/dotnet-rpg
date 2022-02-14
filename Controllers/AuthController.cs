using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Data;
using dotnet_rpg.DTOs.User;
using dotnet_rpg.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IauthRepository _authRepo;
        public AuthController(IauthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto request){
            ServiceResponse<int> response = await _authRepo.Register(
                new User { Username = request.Username}, request.Password
            );
            if(!response.Success){
                return BadRequest(response);
            }
            return Ok(response);

        }
        
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto request){
            ServiceResponse<string> response = await _authRepo.Login(
                request.Username, request.Password
            );
            if(!response.Success){
                return BadRequest(response);
            }
            return Ok(response);

        }
        
    }
}
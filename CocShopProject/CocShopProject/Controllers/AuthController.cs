using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CocShop.Model;
using CocShopProject.VIewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CocShopProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<MyUser> _userManager;

        public AuthController(UserManager<MyUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("token")]
        public async Task<ActionResult> GetToken([FromBody]LoginVM model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return BadRequest("Invalid Username");
            }
            var result = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!result)
            {
                return BadRequest("Invalid Password");
            }

            await _userManager.UpdateAsync(user);
            return new OkObjectResult(GenerateToken(user).Result);
        }

        private async Task<Token> GenerateToken(MyUser user)
        {
            //security key
            string securityKey = "qazedcVFRtgbNHYujmKIolp";
            //symmectric security key
            var symmectricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

            //signing credentials
            var signingCredentials = new SigningCredentials(symmectricSecurityKey, SecurityAlgorithms.HmacSha256);

            //add Claims
            var claims = new List<Claim>();
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            //create token
            var token = new JwtSecurityToken(
                    issuer: "dongtv",
                    audience: user.FullName,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: signingCredentials,
                    claims: claims
                );
            //return token
            return new Token
            {
                roles = _userManager.GetRolesAsync(user).Result.ToArray(),
                fullname = user.FullName,
                access_token = new JwtSecurityTokenHandler().WriteToken(token),
                expires_in = (int)TimeSpan.FromDays(1).TotalSeconds
            };
        }
        //tự đăng kí
        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody]RegisterVM model)
        {
            try
            {
                var user = new MyUser()
                {
                    UserName = model.Username,
                    Email = model.Email,
                    FullName = model.Fullname,
                };
                var resultUser = await _userManager.CreateAsync(user, model.Password);
                //var resultRole = await _userManager.AddToRoleAsync(user, "user");
                if (resultUser.Succeeded)// && resultRole.Succeeded)
                {
                    return new OkObjectResult(GenerateToken(user).Result);
                }
                else
                {
                    return BadRequest(resultUser.Errors);// + " \n" + resultRole.Errors);
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
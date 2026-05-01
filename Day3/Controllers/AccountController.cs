using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Day3.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Day3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {

        [HttpPost]
        public ActionResult login(LoginUserDTO loginUser)
        {

            if (loginUser.userName == "admin" && loginUser.password == 123)
            {

                #region Claims
                List<Claim> claims = new List<Claim>();

                claims.Add(new Claim("name", loginUser.userName));
                claims.Add(new Claim(ClaimTypes.MobilePhone, "01201414304"));
                #endregion

                #region Create SigningCredentials with Encoded SecretKey
                String secertKey = "Hello My Name Is kiro And I love u All";
                var encodedSecretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secertKey));
                var sigCred = new SigningCredentials(encodedSecretKey, SecurityAlgorithms.HmacSha256Signature);
                #endregion

                #region Create Token
                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: sigCred
                );

                string stringToken = token.ToString();
                string stringTokenHandler = new JwtSecurityTokenHandler().WriteToken(token);
                #endregion

                return Ok(stringTokenHandler);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult getAll()
        {
            return Ok();
        }

    }
}
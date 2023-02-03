using Admin_Data.DataContext;
using Admin_Data.Models;
using Admin_Data.Services;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Pump_Data.Models;
using ILogger = NLog.ILogger;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Admin_Data.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AdminLoginController : Controller
    {
        AdminLoginService adminLoginService;

        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        private readonly JwtSettings jwtSettings;

        //private readonly IRefereshTokenGenerator refereshTokenGenerator;

        public AdminLoginController(AdminDBContext adminDBContext, IOptions<JwtSettings> options)
        {
            adminLoginService = new AdminLoginService(adminDBContext);
            this.jwtSettings = options.Value;
        }
        [HttpPost("Authenticate")]
        public IActionResult AdminLogin(AdminLogin Details)
        {
            try
            {
                bool status = adminLoginService.AdminLogin(Details);
                JsonResponse jsonResponse = new JsonResponse();
                
                if (status)
                {
                    var tokenhandler = new JwtSecurityTokenHandler();
                    var tokenkey = Encoding.UTF8.GetBytes("thisisoursecurekey");
                    var tokendesc = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, Details.tblUsername) }),
                        Expires = DateTime.Now.AddMinutes(20),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
                    };
                    var token = tokenhandler.CreateToken(tokendesc);
                    string finaltoken = tokenhandler.WriteToken(token);

                    jsonResponse.Result = true;
                    jsonResponse.Message = finaltoken;
                }
                else
                {
                    jsonResponse.Result = false;
                    jsonResponse.Message = "Login failed";
                }
                logger.Info("sucess");
                return Ok(jsonResponse);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        public IActionResult GetAdmin()
        {
            return Ok("hi");
        }

    }
}

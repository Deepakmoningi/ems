using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly EmpDbContext _context;
        private readonly IConfiguration _config;
        public LoginController(EmpDbContext empDbContext, IConfiguration config)
        {
            _context = empDbContext;
            _config = config;
        }

        [HttpPost("signup")]
        public IActionResult signUp(Signup signupObj)
        {
            if(signupObj==null)
            {
                return BadRequest();
            }
            else
            {
                _context.signups.Add(signupObj);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode=200,
                    message="SignUp Succesfull",
                    signupObj
                });
            }
        }

        [HttpPost("Login")]
        public IActionResult login(Login loginObj)
        {
            if (loginObj == null)
            {
                return BadRequest();
            }
            else
            {
                var data = _context.signups.Where(x => x.Email == loginObj.Email && x.Password == loginObj.Password).FirstOrDefault();
                if(data!=null)
                {
                    return Ok(new
                    {
                        StatusCode=200,
                        message="Login Successfull"
                    });

                }
                else
                {
                    return BadRequest(new
                    {
                        StatusCode=400,
                        message="Invalid Credentials"
                    });
                }
            }
        }
    }
}

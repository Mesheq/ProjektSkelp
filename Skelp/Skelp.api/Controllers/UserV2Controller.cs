using System.Linq;
using System.Threading.Tasks;
using Skelp.Api.Mappers;
using Skelp.Api.Validation;
using Skelp.Data.Sql;
using Skelp.IServices.User;
using Microsoft.AspNetCore.Mvc;

namespace Skelp.Api.Controllers
{
    [ApiVersion( "2" )]
    [Route( "api/v{version:apiVersion}/user" )]
    public class UserV2Controller: Controller
    {
        private readonly SkelpDbContext _context;
        private readonly IUserService _userService;

        /// <inheritdoc />
        public UserV2Controller(SkelpDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        
        [HttpGet("{userId:min(1)}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _userService.GetUserByUserId(userId);
            if (user != null)
            {
                return Ok(UserToUserViewModelMapper.UserToUserViewModel(user));
            }
            return NotFound();
        }
        
        
        [HttpGet("name/{firstName}", Name = "GetUserByUserName")]
        public async Task<IActionResult> GetUserByUserName(string firstName)
        {
            var user = await _userService.GetUserByUserName(firstName);
            if (user != null)
            {
                return Ok(UserToUserViewModelMapper.UserToUserViewModel(user));
            }
            return NotFound();
        }
        [HttpGet("getallUsers", Name = "GetAllusers")]
        public async Task<IActionResult> GetUsers()
        {
            var user = _context.User.Where(x => x.UserId != 0);
            return Ok(user);
        }

        [ValidateModel]
        public async Task<IActionResult> Post([FromBody] IServices.Requests.CreateUser createUser)
        {
            var user = await _userService.CreateUser(createUser);
            
            return Created(user.UserId.ToString(),UserToUserViewModelMapper.UserToUserViewModel(user)) ;
        }
        
        
        [ValidateModel]
        [HttpPatch("edit/{userId:min(1)}", Name = "EditUser")]
//        public async Task<IActionResult> EditUser([FromBody] EditUser editUser,[FromQuery] int userId)
        public async Task<IActionResult> EditUser([FromBody] IServices.Requests.EditUser editUser, int userId)
        {
            await _userService.EditUser(editUser, userId);
            
            return NoContent();
        }
        [HttpDelete("{userId:min(1)}", Name = "DeleteUser")]
        [ValidateModel]
        public async Task<IActionResult> RemoveUser(int userId)
        {
            
            await _userService.RemoveUser(userId);
            return NoContent();
        }
    }
}

    

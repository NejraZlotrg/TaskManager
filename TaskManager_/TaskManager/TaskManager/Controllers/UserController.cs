using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly DBContext _dbContext;


        public UserController(ILogger<UserController> logger, DBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet("/GetUser")]
        public IEnumerable<UserVM> Get()
        {
            var upit = _dbContext.Users.OrderBy(p => p.UserID).Select(x => new UserVM
            {
                 UserID = x.UserID,
                  email=x.email,
                   username= x.username

            });
            return upit.ToList();
        }

        [HttpPost("/User/Add")]
        public ActionResult AddUser ([FromBody] UserAdd x) 
        {
            var noviUser = new User
            {
                
                 username=x.username,
                 password=x.password,
                 email=x.email
            };
            _dbContext.Add(noviUser);
            _dbContext.SaveChanges();
            return Ok(noviUser);

        }

        [HttpDelete("/User/Delete")]
        public ActionResult Delete(int id)
        {
            User obj = _dbContext.Users.Find(id);

            if (obj == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(obj);

            _dbContext.SaveChanges();
            return Ok(obj);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly DBContext _dbContext;


        public TaskController(ILogger<UserController> logger, DBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet(Name = "GetTask")]
        public List<TaskGetVM> Get()
        {
            var upit = _dbContext.Tasks.OrderBy(p => p.TaskID).Select(x => new TaskGetVM
            {
                UserID = x.UserID,
                    DatumKreiranja = x.DatumKreiranja,
                     Naslov=x.Naslov,
                      Opis=x.Opis,
                       User=x.User,
                       
                 
                    

            });
            return upit.ToList();
        }

        [HttpPost("/Task/Add")]
        public ActionResult AddTask([FromBody] TaskAddVM x)
        {
            var noviTask = new Task
            {
                DatumKreiranja = x.DatumKreiranja,
                Naslov = x.Naslov,
                Opis = x.Opis,
                UserID =x.UserID,
               
            };
            _dbContext.Add(noviTask);
            _dbContext.SaveChanges();
            return Ok(noviTask);

        }

        [HttpDelete("/Task/Delete")] 
        public ActionResult Delete(int id)
        {
            Task obj = _dbContext.Tasks.Find(id);

            if (obj == null)
                return BadRequest("pogresan ID");

            _dbContext.Remove(obj);

            _dbContext.SaveChanges();
            return Ok(obj);
        }
    }
}




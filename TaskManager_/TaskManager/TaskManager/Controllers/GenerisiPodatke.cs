using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenerisiPodatke : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly DBContext _dbContext;


        public GenerisiPodatke(ILogger<UserController> logger, DBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpPost("/Task/GenerisiPocetnePodatke")]
        public ActionResult AddTask()
        {
            var noviUser = new User
            {
                 username="korisnik 1",
                  email="korisnik1@gmail.com",
                    password="12345"

            };
            _dbContext.Add(noviUser);
            _dbContext.SaveChanges();

            var user1 = _dbContext.Users.Find(noviUser.UserID);
            var noviTask = new Task
            {
                DatumKreiranja = System.DateTime.Now,
                Naslov = "Task1",
                Opis = "Ovo je prvi task",
                UserID = user1.UserID
                 
                 
            };
            _dbContext.Add(noviTask);
            _dbContext.SaveChanges();
          
            return Ok();
           


        }
    }
}

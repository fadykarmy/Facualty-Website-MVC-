using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using The_project.Data;
using The_project.model;

namespace The_project.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly AppDBcontext _dbcontext;

        public AccountController(AppDBcontext context)
        {
            _dbcontext = context;

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.RegisterViewModels.Add(user);
                _dbcontext.SaveChanges();
                return RedirectToAction("Login", "Account");
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            if (ModelState.IsValid)
            {
                var user = await _dbcontext.RegisterViewModels.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

                if (user != null)
                {
                    HttpContext.Session.SetString("Name", model.Email);
                    return RedirectToAction("services", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Sorry, Email or Password were incorrect. Please try again.");
                }
            }
            return View(model);
        }
        
    }
}

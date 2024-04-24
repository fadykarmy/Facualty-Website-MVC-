using Microsoft.AspNetCore.Mvc;
using The_project.Data;
using The_project.model;
using Microsoft.EntityFrameworkCore;

namespace The_project.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly AppDBcontext _dbcontext;

        public AdminController(AppDBcontext context)
        {
            _dbcontext = context;

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterAdmin());
        }
        [HttpPost]
        public IActionResult Register(RegisterAdmin user)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.RegisterAdmins.Add(user);
                _dbcontext.SaveChanges();
                return RedirectToAction("Login", "Admin");
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Admin model)
        {
            if (ModelState.IsValid)
            {
                var user = _dbcontext.RegisterAdmins.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

                if (user != null)
                {
                    HttpContext.Session.SetString("Email", model.Email);
                    return RedirectToAction("Admin_services", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Wrong data");
                }
            }
            return null;
        }
    }
}

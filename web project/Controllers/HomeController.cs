using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using web_project.Data;
using web_project.Models;

namespace web_project.Controllers
{

    public class HomeController : Controller
    {
        public static bool isLoggedIn;

        private readonly web_projectContext _context;
        public readonly Login _loginModel;

        public HomeController(web_projectContext context)
        {
            _context = context;
            _loginModel = new Login();
        }

        public IActionResult Menu()
        {
            if (isLoggedIn)
            {
                ViewData["login"] = isLoggedIn;
                var menus = _context.Menu.ToList();
                return View(menus);
            }
            else
            {
                isLoggedIn = false;
                ViewData["login"] = isLoggedIn;
                var menus = _context.Menu.ToList();
                return View(menus);
            }
        }
        [HttpGet]
        public IActionResult LoginAdmin()
        {
            if (_loginModel.IsLoggedIn)
            {
                return RedirectToAction("Index");
            }

            return View(_loginModel);
        }

        [HttpPost]
        public IActionResult ValidateLogin(Login loginModel)
        {

            if (loginModel.Username == "Admin" && loginModel.Password == "123")
            {
                isLoggedIn = true;
                ViewData["login"] = isLoggedIn;
                loginModel.IsLoggedIn = true;


                return View("Index");
            }
            else
            {
                ModelState.AddModelError("Password", "the username or password is wrong");

            }
            return View("LoginAdmin", loginModel);
        }

        public IActionResult Logout()
        {

            isLoggedIn = false;
            ViewData["login"] = isLoggedIn;
            _loginModel.IsLoggedIn = false;

            return RedirectToAction("Index", isLoggedIn);

        }
        public IActionResult Index()
        {
            if (isLoggedIn)
            {
                isLoggedIn = true;
                ViewData["login"] = isLoggedIn;

                return View("Index");
            }
            else
            {
                isLoggedIn = false;
                ViewData["login"] = isLoggedIn;
                return View();
            }

        }



        public IActionResult About()


        {
            if (isLoggedIn == true)
            {
                ViewData["login"] = isLoggedIn;
                return View("About");
            }
            else
            {
                isLoggedIn = false; 
                ViewData["login"] = false;
                return View();
            }
        }



   

    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
} }


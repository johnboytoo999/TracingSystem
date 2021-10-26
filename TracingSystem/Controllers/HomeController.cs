using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TracingSystem.Models;
using TracingSystem.Service;


namespace TracingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthorityService _authorityService;
        private readonly IIssueListService _issueListService;

        public HomeController(ILogger<HomeController> logger , IAuthorityService authorityService, IIssueListService issueListService)
        {
            _logger = logger;
            _authorityService = authorityService;
            _issueListService = issueListService;

        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]   // 避免XSS、CSRF攻擊
        public ActionResult Login(TrackingUser User)
        {

            var loginResult = _authorityService.Login(User.Account, User.Password);

            if (loginResult.IsSuccess)
            {
                var claimsIdentity = new ClaimsIdentity((IEnumerable<Claim>)loginResult.Data, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties{};
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                                      new ClaimsPrincipal(claimsIdentity),
                                                      authProperties);
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            else
            {
                ViewBag.errorMessage = loginResult.Message;
                return View();
            }

        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(actionName: "Login", controllerName: "Home");
        }

        [Authorize]
        public IActionResult Index()
        {
            ViewBag.ResolveIssue = User.Claims.FirstOrDefault(x => x.Type == "ResolveIssue")?.Value;
            ViewBag.CreateIssue = User.Claims.FirstOrDefault(x => x.Type == "CreateIssue")?.Value;
            ViewBag.UpdateIssue = User.Claims.FirstOrDefault(x => x.Type == "UpdateIssue")?.Value;
            ViewBag.DeleteIssue = User.Claims.FirstOrDefault(x => x.Type == "DeleteIssue")?.Value;

            var result = _issueListService.GetIssueList();

            return View(result);  
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using TracingSystem.Models;
using TracingSystem.Service;


namespace TracingSystem.Controllers
{
    public class IssueController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IIssueListService _issueListService;

        public IssueController(ILogger<HomeController> logger, IIssueListService issueListService)
        {
            _logger = logger;     
            _issueListService = issueListService;

        }



        [Authorize]
        public IActionResult Index()
        {
            
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Index(IssueList issue)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
            var result = _issueListService.InsertIssue(issue, Convert.ToInt32(userId));

            if(result.IsSuccess)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            else
            {
                return View();
            }
            
        }


        [Authorize]
        public IActionResult Update(int id)
        {
            var result = _issueListService.GetIssueList(id);
            return View(result);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Update(IssueList issue)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
            var result = _issueListService.UpdateIssue(issue, Convert.ToInt32(userId));

            if (result.IsSuccess)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var result = _issueListService.DeleteIssue(id);
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        [Authorize]
        public IActionResult UpdateStatus(int id)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
            var result = _issueListService.UpdateIssueStatus(id, Convert.ToInt32(userId));

            if (result.IsSuccess)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            else
            {
                return View();
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

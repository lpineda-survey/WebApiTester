using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using JsonDiffPatchDotNet;
using WebApiTester.Models;

namespace WebApiTester.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Compare(Request request)
        {
            var status = false;
            string diffs = GetDiffs(request, ref status);

            return Json(new { status, msg = diffs });
        }

        private string GetDiffs(Request request, ref bool status)
        {
            var jdp = new JsonDiffPatch();
            string output;
            try
            {
                status = true;
                output = jdp.Diff(request.jsonLeft, request.jsonRight);
                if (string.IsNullOrEmpty(output))
                {
                    status = false;
                    output = "there are not differences";
                }
            }
            catch (Exception ex)
            {
                status = false;
                output = ex.Message;
            }
            return output;
        }
    }
}

using Capturing_Details.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Repo.Data;
using Repo.Data.Models;
using System.Diagnostics;

namespace Capturing_Details.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ClientDbContext _context;

        public HomeController(ILogger<HomeController> logger, ClientDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(NotificationViewModel? notification = null)
        {
            var registerModel = new CaptureViewModel();

            registerModel.Locations = _context.Location.ToList();
            registerModel.Notification = notification;

            return View(registerModel);
        }


        [HttpPost]
        public IActionResult Capture(CaptureViewModel model)
        {
            var notification = new NotificationViewModel();

            if (ModelState.IsValid)
            {
                if (_context.SystemUser.Any(x => x.ClienName == model.ClienName!.ToLower()))
                {
                    notification.Show = true;
                    notification.Title = "Oops";
                    notification.Message = "A client with the same name already exists in the system.";

                    return RedirectToAction("Index", notification);
                }
                else 
                {
                    _context.SystemUser.Add(new SystemUser
                    {
                        ClienName = model.ClienName!.ToLower(),
                        Number = model.Number,
                        DateRegistered = DateOnly.FromDateTime(model.DateRegistered),
                        LocationId = model.LocationId
                    });

                    _context.SaveChangesAsync();

                    notification.Show = true;
                    notification.Title = "Saved";
                    notification.Message = $"{model.ClienName} has been saved successfully";
                }
            }
            else 
            {
                notification = GetModelStateError(ModelState);
            }

            return RedirectToAction("Index", notification);
        }

        private NotificationViewModel GetModelStateError(ModelStateDictionary ModelState)
        {
            var notification = new NotificationViewModel();

            foreach (var state in ModelState)
            {
                string propertyName = state.Key;
                var errors = state.Value.Errors;

                foreach (var error in errors)
                {
                    var errorMessage = error.ErrorMessage;
                    notification.Message = $"{errorMessage}";
                }
            }

            notification.Show = true;
            notification.Title = "Oops";

            return notification  ;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

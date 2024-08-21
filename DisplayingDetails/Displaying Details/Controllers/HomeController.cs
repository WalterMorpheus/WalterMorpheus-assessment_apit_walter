using Displaying_Details.Models;
using Microsoft.AspNetCore.Mvc;
using Repo;
using Repo.Data;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Displaying_Details.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ClientDbContext _context;
        private UserRepository userRepository;

        public HomeController(ILogger<HomeController> logger, ClientDbContext context)
        {
            _logger = logger;
            _context = context;
            userRepository = new UserRepository(_context);
        }

        public IActionResult Index()
        {
            return View(GetDashboard());
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            return PartialView("_DashboardTables", GetDashboard());
        }

        private DashboardViewModel GetDashboard()
        {
            var dashboardViewModel = new DashboardViewModel();

            dashboardViewModel.MaxUserCount = _context.SystemUser.Sum(x => x.Number);
            dashboardViewModel.UsersPerLocations = userRepository.GetUsersPerLocation();
            dashboardViewModel.ClientsCreatedPerDate = userRepository.ClientsCreatedPerDate();

            return dashboardViewModel;
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

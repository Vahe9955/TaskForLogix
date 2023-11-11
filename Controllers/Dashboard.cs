using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskForLogix.Data;

namespace TaskForLogix.Controllers
{
    public class Dashboard : Controller
    {
        private readonly ApplicationContext _context;
        public Dashboard(ApplicationContext context)
        {
            _context = context;
        }
        public async IActionResult Index()
        {
            var users = await _context.applicationUsers.ToListAsync();

            return View(users);
        }
    }
}

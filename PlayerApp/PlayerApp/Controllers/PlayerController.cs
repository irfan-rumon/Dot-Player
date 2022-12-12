using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayerApp.Data;
using PlayerApp.Models;

namespace PlayerApp.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PlayerController(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Player player)
        {
            if(ModelState.IsValid)
            {
                await _db.AddAsync(player);
                await _db.SaveChangesAsync();

            }
            return RedirectToAction(nameof(Index)); ;
        }
    }
}

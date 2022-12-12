using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayerApp.Data;
using PlayerApp.Models;
using System.Numerics;

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
            var AllPlayers = from player in _db.Players
                             select player;
            return View(await AllPlayers.ToListAsync());
        }

        public IActionResult Create()
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

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var player = await _db.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                _db.Update(player);
                await _db.SaveChangesAsync();

            }
            return RedirectToAction(nameof(Index)); ;
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var player = await _db.Players.FindAsync(id);
            _db.Remove(player);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index)); ;

        }
 
    }
}

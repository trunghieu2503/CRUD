using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class PlayersController : Controller
    {
        public IActionResult Index(string searchString)
        {
            var players = ClubRepository.GetAllPlayers();

            if (!string.IsNullOrEmpty(searchString))
            {
                players = players.Where(p => p.Ten_ct.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            ViewBag.SearchString = searchString; // Lưu trữ chuỗi tìm kiếm để hiển thị lại trong view
            return View(players);
        }

        public IActionResult Create()
        {
            ViewBag.Clubs = ClubRepository.GetAllClubs();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tbl_cauthu player)
        {
            if (ModelState.IsValid)
            {
                ClubRepository.AddPlayer(player);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Clubs = ClubRepository.GetAllClubs();
            return View(player);
        }

        public IActionResult Edit(int id)
        {
            var player = ClubRepository.GetPlayerById(id);
            if (player == null)
            {
                return NotFound();
            }
            ViewBag.Clubs = ClubRepository.GetAllClubs();
            return View(player);
        }

        [HttpPost]
        public IActionResult Edit(Tbl_cauthu player)
        {
            if (ModelState.IsValid)
            {
                ClubRepository.UpdatePlayer(player);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Clubs = ClubRepository.GetAllClubs();
            return View(player);
        }

        public IActionResult Delete(int id)
        {
            var player = ClubRepository.GetPlayerById(id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            ClubRepository.DeletePlayer(id);
            return RedirectToAction(nameof(Index));
        }

        // Thêm action để xem chi tiết cầu thủ
        public IActionResult Details(int id)
        {
            var player = ClubRepository.GetPlayerById(id);
            if (player == null)
            {
                return NotFound(); // Trả về 404 nếu không tìm thấy cầu thủ
            }
            return View(player);
        }
    }
}

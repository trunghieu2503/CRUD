using CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class ClubsController : Controller
    {
        public IActionResult Index()
        {
            var clubs = ClubRepository.GetAllClubs();
            return View(clubs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tbl_clb club)
        {
            if (ModelState.IsValid)
            {
                ClubRepository.AddClub(club);
                return RedirectToAction(nameof(Index));
            }
            return View(club);
        }

        public IActionResult Edit(int id)
        {
            var club = ClubRepository.GetClubById(id);
            if (club == null)
            {
                return NotFound();
            }
            return View(club);
        }

        [HttpPost]
        public IActionResult Edit(Tbl_clb club)
        {
            if (ModelState.IsValid)
            {
                ClubRepository.UpdateClub(club);
                return RedirectToAction(nameof(Index));
            }
            return View(club);
        }

        public IActionResult Delete(int id)
        {
            var club = ClubRepository.GetClubById(id);
            if (club == null)
            {
                return NotFound();
            }
            return View(club);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            ClubRepository.DeleteClub(id);
            return RedirectToAction(nameof(Index));
        }

        // Thêm action để xem chi tiết câu lạc bộ
        public IActionResult Details(int id)
        {
            var club = ClubRepository.GetClubById(id);
            if (club == null)
            {
                return NotFound(); // Trả về 404 nếu không tìm thấy câu lạc bộ
            }
            return View(club);
        }
    }
}

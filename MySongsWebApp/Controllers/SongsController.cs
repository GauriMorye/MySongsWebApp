using Microsoft.AspNetCore.Mvc;
using MySongsWebApp.Data;
using MySongsWebApp.Models;

namespace MySongsWebApp.Controllers
{
    public class SongsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SongsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<MySongs> objSongList = _db.Songs.ToList();
            return View(objSongList);
        }

        //Adding a Song To the PlayList
        //Get 
        public IActionResult Add()
        {
            return View();
        }

        //Post
        [HttpPost]
        public IActionResult Add(MySongs obj)
        {
            if (ModelState.IsValid) {
                _db.Songs.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Added Successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);          
        }


        //Deleting a Song from the Playlist
        //Get 
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var songFromDb = _db.Songs.Find(id);
            if (songFromDb == null)
            {
                return NotFound();
            }

            return View(songFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Songs.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Songs.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully!";
            return RedirectToAction("Index");

        }
    }
}

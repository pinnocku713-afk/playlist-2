using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace playlist_2.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly List<string> _songs = new()
        {
            "DV-i Love theme - jepple",
            "Advice for the young at heart - Tears for fears",
            "Mad World - Tears for fears",
            "Family Man - Daryl Hall & John Oates",
            "Bad - Michael Jackson",
            "Toast - Koffee"
        };

        public IActionResult Index()
        {
           
            return View(_songs);
        }

        [Route("liner-notes")]
        public IActionResult LinerNotes()
        {
            return View();

        }

        
        [Route("track/{number?}")]
        public IActionResult Track(int? number)
        {
            var n = number ?? 1;

            
            if (n < 1 || n > _songs.Count)
                return NotFound();

            ViewData["TrackNumber"] = n;
            ViewData["Song"] = _songs[n - 1];
            ViewData["HasPrev"] = n > 1;
            ViewData["HasNext"] = n < _songs.Count;
            ViewData["Prev"] = n - 1;
            ViewData["Next"] = n + 1;

            return View();
        }

        
        [Route("find/{*term}")]
        public IActionResult Find(string term)
        {
            
            if (string.IsNullOrWhiteSpace(term))
            {
                ViewData["Term"] = string.Empty;
                return View("FindInvalid");
            }


            if (!term.All(char.IsLetter))
            {
                ViewData["Term"] = term;
                return View("FindInvalid");
            }

            
            var idx = _songs.FindIndex(s => s.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0);
            ViewData["Word"] = term;
            if (idx >= 0)
            {
                ViewData["Found"] = true;
                ViewData["Song"] = _songs[idx];
                ViewData["TrackNumber"] = idx + 1;
            }
            else
            {
                ViewData["Found"] = false;
            }

            return View("Find");
        }

    }
}

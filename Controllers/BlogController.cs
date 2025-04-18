using Microsoft.AspNetCore.Mvc;
using BlogProject.Data;
using BlogProject.Models;
using System.Linq;

namespace BlogProject.Controllers
{
    public class BlogController(BlogContext context) : Controller
    {
        private readonly BlogContext _context = context;

        // Elenco dei post
        public IActionResult Index()
        {
            var posts = _context.Posts.OrderByDescending(p => p.CreatedAt).ToList();
            return View(posts);
        }

        // Dettaglio di un post
        public IActionResult Details(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        //Create, Edit e Delete.. CRUD operations

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                post.CreatedAt = DateTime.Now;
                _context.Posts.Add(post);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        public IActionResult Edit(int id)
        {
            var post = _context.Posts.Find(id);
            if (post == null) return NotFound();
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Post post)
        {
            if (!ModelState.IsValid)
                return View(post);
            post.CreatedAt = DateTime.Now;
            _context.Posts.Update(post);
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = post.Id });
        }

        public IActionResult Delete(int id)
        {
            var post = _context.Posts.Find(id);
            if (post == null) return NotFound();
            return View(post);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var post = _context.Posts.Find(id);
            if (post == null) return NotFound();

            _context.Posts.Remove(post);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}

using Microsoft.AspNetCore.Mvc;
using BlogProject.Data;
using BlogProject.Models;
using System.Linq;
using BlogProject.Generics;

namespace BlogProject.Controllers
{
    public class BlogController(IRepository<Post> taskRepo) : Controller
    {
        private readonly IRepository<Post> _taskRepo = taskRepo;

        // Elenco dei post
        public Task<IActionResult> Index()
        {
            var posts = _taskRepo.ListAllAsync();
            return Task.FromResult<IActionResult>(View(posts));
        }
        
        //public IActionResult Index()
        //{
        //    var posts = _taskRepo.ListAll();
        //    return View(posts);
        //}

        // Dettaglio di un post
        public Task<IActionResult> Details(int id)
        {
            
        }
        
        public IActionResult Details(int id)
        {
            var post = _taskRepo.FindById(id);
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
            if (!ModelState.IsValid) return View(post);
            post.CreatedAt = DateTime.Now;
            _taskRepo.Add(post);
            _taskRepo.Save();
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Edit(int id)
        {
            var post = _taskRepo.FindById(id);
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
            _taskRepo.Update(post);
            _taskRepo.Save();
            return RedirectToAction("Details", new { id = post.Id });
        }

        public IActionResult Delete(int id)
        {
            var post = _taskRepo.FindById(id);
            if (post == null) return NotFound();
            return View(post);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var post = _taskRepo.FindById(id);
            if (post == null) return NotFound();

            _taskRepo.Remove(post);
            _taskRepo.Save();
            return RedirectToAction("Index");
        }


    }
}

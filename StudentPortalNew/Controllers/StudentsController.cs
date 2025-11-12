using Microsoft.AspNetCore.Mvc;
using StudentPortal.Data;
using StudentPortalNew.Data;
using StudentPortalNew.Models.Entities;

namespace StudentPortalNew.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ApplicationDbContext dbContext, ILogger<StudentsController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult List()
        {
            var students = _dbContext.Students.ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            return ToList(id);
        }

        private IActionResult ToList(Guid id)
        {
            var student = _dbContext.Students.Find(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student model)
        {
            _dbContext.Students.Update(model);
            _dbContext.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var student = _dbContext.Students.Find(id);
            if (student != null)
            {
                _dbContext.Students.Remove(student);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}

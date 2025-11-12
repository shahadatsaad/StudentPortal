using Microsoft.AspNetCore.Mvc;
using StudentPortalNew.Models;
using StudentPortalNew.Models.Entities;

namespace StudentPortalNew.Controllers
{
    public class StudentsControllerBase
    {
        private object _dbContext;

        [HttpPost]
        public IActionResult Add(AddStudentViewModel viewModel)
        {
            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subscribed = viewModel.Subscribed


            };
            GetStudents().Add(student);
            _dbContext.SaveChanges();

            return RedirectToAction("List");

            object GetStudents()
            {
                return GetStudents1();
            }
        }

        private object GetStudents1()
        {
            return _dbContext.Students;
        }

        private IActionResult RedirectToAction(string v)
        {
            throw new NotImplementedException();
        }
    }
}
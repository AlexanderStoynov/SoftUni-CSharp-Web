using AspNetCoreIntro.Contracts;
using AspNetCoreIntro.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreIntro.Controllers
{
    public class IntroController : Controller
    {
        private readonly IStudentService studentService;
        public IntroController(IStudentService _studentService)
        {
            studentService = _studentService;
        }
        public IActionResult Index()
        {
			ViewBag.Title = "Intro";

            return View();
        }

        public IActionResult GetNumber(int number)
        {
            ViewBag.Title = "GetNumber";

            return View(number);
        }

        public IActionResult GetStudentData(int id)
        {
            ViewBag.Title = "GetStudentData";

            var model = studentService.GetStudent(id);

            return View("StudentData", model);
        }

        public IActionResult EditStudent(Student model)
        {
            if (!ModelState.IsValid)
            {
                return View("StudentData", model);
			}

            if(studentService.UpdateStudent(model))
            {
				return RedirectToAction(nameof(GetStudentData), new {id = model.Id});
			}

            return RedirectToAction(nameof(Index));
            
        }
    }
}

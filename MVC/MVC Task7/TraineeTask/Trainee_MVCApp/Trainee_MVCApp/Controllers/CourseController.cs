using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trainee_MVCApp.BusinessLogic.Interfaces;
using Trainee_MVCApp.Models;

namespace Trainee_MVCApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly IGenericRepository<Course> genericRepository;
        private readonly ICourseRepository courseRepo;
        private readonly IGenericRepository<Trainee> traineeRepo;

        public CourseController(IGenericRepository<Course> genericRepository,ICourseRepository courseRepo,
            IGenericRepository<Trainee> traineeRepo)
        {
            this.genericRepository = genericRepository;
            this.courseRepo = courseRepo;
            this.traineeRepo = traineeRepo;
        }


        public ActionResult Index()
        {
            return View(courseRepo.GetAllCoursesWithTrainee());
        }


        public ActionResult Details(int id)
        {

            return View(courseRepo.GetCourseWithTrainee(id));
        }


        public ActionResult Create()
        {
            ViewBag.Trainees= traineeRepo.GetAll();
            return View();
        }


        [HttpPost]
        public ActionResult Create(Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = genericRepository.Add(course);
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                }
                ViewBag.Trainees = traineeRepo.GetAll();
                return View(course);
            }
            catch
            {
                ViewBag.Trainees = traineeRepo.GetAll();
                return View(course);
            }
        }


        public ActionResult Edit(int id)
        {
            var course = genericRepository.GetById(id);
            if (course == null) return NotFound();
            ViewBag.Trainees = traineeRepo.GetAll();
            return View(course);
        }


        [HttpPost]
        public ActionResult Edit(int id, Course course)
        {
            if (id != course.Id) return BadRequest();
            try
            {
                if (ModelState.IsValid)
                {
                    var result = genericRepository.Update(course);
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                }
                ViewBag.Trainees = traineeRepo.GetAll();
                return View(course);
            }
            catch
            {
                ViewBag.Trainees = traineeRepo.GetAll();
                return View(course);
            }
        }


        public ActionResult Delete(int id)
        {
            var course = genericRepository.GetById(id);
            if (course == null) return NotFound();

            var result = genericRepository.Delete(course);

            if (result > 0)
                return RedirectToAction(nameof(Index));
            return BadRequest();

        }
    }
}

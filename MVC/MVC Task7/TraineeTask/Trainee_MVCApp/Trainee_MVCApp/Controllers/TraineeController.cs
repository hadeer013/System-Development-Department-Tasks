using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trainee_MVCApp.BusinessLogic.Interfaces;
using Trainee_MVCApp.Models;

namespace Trainee_MVCApp.Controllers
{
    public class TraineeController : Controller
    {
        private readonly ITraineeRepository traineeRepo;
        private readonly IGenericRepository<Trainee> genericRepository;
		private readonly IGenericRepository<Track> trackRepo;

		public TraineeController(ITraineeRepository traineeRepo,IGenericRepository<Trainee> genericRepository,
            IGenericRepository<Track> trackRepo)
        {
            this.traineeRepo = traineeRepo;
            this.genericRepository = genericRepository;
			this.trackRepo = trackRepo;
		}

        public ActionResult Index()
        {
            return View(traineeRepo.GetAllWithTrack());
        }

        
        public ActionResult Details(int id)
        {
            return View(traineeRepo.GetByIdAllInc(id));
        }

        
        public ActionResult Create()
        {
            ViewBag.Tracks = trackRepo.GetAll();
            return View();
        }

        
        [HttpPost]
        public ActionResult Create(Trainee trainee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = genericRepository.Add(trainee);
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                }
                ViewBag.Tracks = trackRepo.GetAll();
                return View(trainee);
            }
            catch
            {
                ViewBag.Tracks = trackRepo.GetAll();
                return View(trainee);
            }
        }

       
        public ActionResult Edit(int id)
        {
            var trainee = traineeRepo.GetByIdAllInc(id);
            if (trainee == null) return NotFound();
            ViewBag.Tracks = trackRepo.GetAll();
            return View(trainee);
        }

        
        [HttpPost]
        public ActionResult Edit(int id, Trainee trainee)
        {
            if (id != trainee.Id) return BadRequest();
            try
            {
                if (ModelState.IsValid)
                {
                    var result = genericRepository.Update(trainee);
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                }
                ViewBag.Tracks = trackRepo.GetAll();
				return View(trainee);
            }
            catch
            {
				ViewBag.Tracks = trackRepo.GetAll();
				return View(trainee);
            }
        }

        
        public ActionResult Delete(int id)
        {
            var trainee= genericRepository.GetById(id);

            if (trainee == null) return NotFound();

            var result=genericRepository.Delete(trainee);

            if(result>0)
                return RedirectToAction(nameof(Index));
            return BadRequest();

        }

        
    }
}

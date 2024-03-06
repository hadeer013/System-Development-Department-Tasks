using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trainee_MVCApp.BusinessLogic.Interfaces;
using Trainee_MVCApp.BusinessLogic.Repositories;
using Trainee_MVCApp.Models;
using Trainee_MVCApp.ViewModels;

namespace Trainee_MVCApp.Controllers
{
    [Route("TRK")]
    public class TrackController : Controller
    {
        private readonly IGenericRepository<Track> genericRepository;

        public TrackController(IGenericRepository<Track> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        [Route("")]
        public ActionResult Index()
        {
            return View(genericRepository.GetAll());
        }

        [Route("Details/{id:int}")]
        public ActionResult Details(int id)
        {
            return View(genericRepository.GetById(id));
        }

        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }


        [Route("Create")]
        [HttpPost]
        public ActionResult Create(Track track)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = genericRepository.Add(track);
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                }
                return View(track);
            }
            catch
            {
                return View(track);
            }
        }

        [Route("Edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            var track = genericRepository.GetById(id);
            if (track == null) return NotFound();
            return View(track);
        }


        [Route("Edit/{id:int}")]
        [HttpPost]
        public ActionResult Edit(int id, Track track)
        {
            if (id != track.Id) return BadRequest();
            try
            {
                if (ModelState.IsValid)
                {
                    var result = genericRepository.Update(track);
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                }
                return View(track);
            }
            catch
            {
                return View(track);
            }
        }


        [Route("Delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            var track = genericRepository.GetById(id);
            if (track == null) return NotFound();

            var result = genericRepository.Delete(track);

            if (result > 0)
                return RedirectToAction(nameof(Index));
            return BadRequest();

        }

    }
}

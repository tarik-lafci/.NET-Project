#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Contexts;
using DataAccess.Entities;
using Business.Models;
using Business.Services;
using MVC.Controllers.Bases;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

//Generated from Custom Template.
namespace MVC.Controllers
{
    public class ActorsController : MvcController
    {
        // TODO: Add service injections here
        private readonly IActorService _actorService;
        private readonly IMovieService _movieService;

		public ActorsController(IActorService actorService, IMovieService movieService)
		{
			_actorService = actorService;
			_movieService = movieService;
		}

		// GET: Actors
		public IActionResult Index()
        {
            List<ActorModel> actorList = _actorService.GetList(); // TODO: Add get collection service logic here
            return View(actorList);
        }

        // GET: Actors/Details/5
        public IActionResult Details(int id)
        {
            ActorModel actor = _actorService.GetItem(id); // TODO: Add get item service logic here
            if (actor == null)
            {
                //return NotFound();
                return View("Error", "Actor not found!");
            }
            return View(actor);
        }

        // GET: Actors/Create
        public IActionResult Create()
        {
			// TODO: Add get related items service logic here to set ViewData if necessary
			ViewBag.Movie = new MultiSelectList(_movieService.Query().ToList(), "Id", "MovieName");

			return View();
        }

        // POST: Actors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ActorModel actor)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert service logic here
                var result = _actorService.Add(actor);
                if (result.IsSuccesful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new {id = actor.Id});
                }
                ModelState.AddModelError("", result.Message);
                // TODO: Add get related items service logic here to set ViewData if necessary
            }
			ViewBag.Movie = new MultiSelectList(_movieService.Query().ToList(), "Id", "MovieName");
			return View(actor);
		}

			// GET: Actors/Edit/5
			public IActionResult Edit(int id)
        {
            ActorModel actor = _actorService.GetItem(id); // TODO: Add get item service logic here
            if (actor == null)
            {
                return View("Error", "Owner not found!");
            }
			// TODO: Add get related items service logic here to set ViewData if necessary
			ViewBag.Movie = new MultiSelectList(_movieService.Query().ToList(), "Id", "MovieName");
			return View(actor);
        }

        // POST: Actors/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ActorModel actor)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update service logic here
                var result = _actorService.Update(actor);
                if (result.IsSuccesful)
                {
					TempData["Message"] = result.Message;
					return RedirectToAction(nameof(Details), new { id = actor.Id });
				}
                ModelState.AddModelError("", result.Message);
            }
			// TODO: Add get related items service logic here to set ViewData if necessary
			ViewBag.Movie = new MultiSelectList(_movieService.Query().ToList(), "Id", "MovieName");
			return View(actor);
        }

        // GET: Actors/Delete/5
        public IActionResult Delete(int id)
        {
            ActorModel actor = _actorService.GetItem(id); // TODO: Add get item service logic here
            if (actor == null)
            {
                return View("Error", "Owner not found!");
            }
            return View(actor);
        }

        // POST: Actors/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: Add delete service logic here
            var result = _actorService.Delete(id);
            TempData["Message"] = result.Message;   
            return RedirectToAction(nameof(Index));
        }
	}
}

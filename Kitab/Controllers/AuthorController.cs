using Kitab.Data;
using Microsoft.AspNetCore.Mvc;
using Kitab.Models;
using Microsoft.EntityFrameworkCore;
using Kitab.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitab.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _service;
        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allAuthors = await _service.GetAllAsync();
            return View(allAuthors);
        }

        //GET: Author/Create
        public IActionResult Create()
        {
            return View();
        }


        //see in detail what async and await does
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Author author)
        {
            if (!ModelState.IsValid)  //what is model state
            {
                return View(author);
            }
            await _service.AddAsync(author);
            return RedirectToAction(nameof(Index)); //what does this do?
        }

        //Get: Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var authorDetails = await _service.GetByIdAsync(id);

            if (authorDetails == null)
            {
                return View("NotFound");
            }
            return View(authorDetails);

        }

        //GET: Author/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var authorDetails = await _service.GetByIdAsync(id);

            if (authorDetails == null)
            {
                return View("NotFound");
            }
            return View(authorDetails);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Author author)
        {
            if (!ModelState.IsValid)
            {
                return View(author);
            }
            await _service.UpdateAsync(id, author);
            return RedirectToAction(nameof(Index));
        }

        //GET: Author/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var authorDetails = await _service.GetByIdAsync(id);

            if (authorDetails == null)
            {
                return View("NotFound");
            }
            return View(authorDetails);
        }

        [HttpPost, ActionName("Delete")] //Why actionname
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authorDetails = await _service.GetByIdAsync(id);

            if (authorDetails == null)
            {
                return View("NotFound");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

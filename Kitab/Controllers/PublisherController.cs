using Kitab.Data;
using Kitab.Data.Services;
using Kitab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kitab.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService _service;

        public PublisherController(IPublisherService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allPublishers = await _service.GetAllAsync();
            return View(allPublishers);
        }

        //GET: Publishers/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var publisherDetails = await _service.GetByIdAsync(id);
            if (publisherDetails == null)
                return NotFound();
            return View(publisherDetails);
        }

        //GET: Publishers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Publisher publisher)
        {
            if (!ModelState.IsValid)
                return View(publisher);

            await _service.AddAsync(publisher);
            return RedirectToAction(nameof(Index));
        }

        //GET: Publishers/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var publisherDetails = await _service.GetByIdAsync(id);
            if (publisherDetails == null)
                return View("NotFound");
            return View(publisherDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Publisher publisher)
        {
            if (!ModelState.IsValid)
                return View(publisher);

            if (id == publisher.Id)
            {
                await _service.UpdateAsync(id, publisher);
                return RedirectToAction(nameof(Index));
            }
            return View(publisher);
            
        }

        //GET: Publishers/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var publisherDetails = await _service.GetByIdAsync(id);
            if (publisherDetails == null)
                return View("NotFound");
            return View(publisherDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publisherDetails = await _service.GetByIdAsync(id);
            if (publisherDetails == null)
                return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}

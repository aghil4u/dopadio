using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dopadCore.Data;
using dopadCore.Models;
using Microsoft.AspNetCore.Authorization;

namespace dopadCore.Controllers
{
    public class WorksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorksController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Works
        public async Task<IActionResult> Index()
        {
            return View(await _context.Work.ToListAsync());
        }

        // GET: Works/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _context.Work
                .SingleOrDefaultAsync(m => m.Id == id);
            if (work == null)
            {
                return NotFound();
            }

            return View(work);
        }

        // GET: Works/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Works/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PostingUserID,Title,Description,PostingDate,Location,FromDate,Expiry,WorkType,SkillLevel,WorkCategory,AlternateContact,RenumerationType,RenumerationAmount,ImgUrl,ImgUrl2,ImgUrl3,ImgUrl4,ImgUrl5,Tags,Latitude,Longitude")] Work work)
        {
            if (ModelState.IsValid)
            {
                _context.Add(work);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(work);
        }

        // GET: Works/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _context.Work.SingleOrDefaultAsync(m => m.Id == id);
            if (work == null)
            {
                return NotFound();
            }
            return View(work);
        }

        // POST: Works/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,PostingUserID,Title,Description,PostingDate,Location,FromDate,Expiry,WorkType,SkillLevel,WorkCategory,AlternateContact,RenumerationType,RenumerationAmount,ImgUrl,ImgUrl2,ImgUrl3,ImgUrl4,ImgUrl5,Tags,Latitude,Longitude")] Work work)
        {
            if (id != work.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(work);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkExists(work.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(work);
        }

        // GET: Works/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var work = await _context.Work
                .SingleOrDefaultAsync(m => m.Id == id);
            if (work == null)
            {
                return NotFound();
            }

            return View(work);
        }

        // POST: Works/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var work = await _context.Work.SingleOrDefaultAsync(m => m.Id == id);
            _context.Work.Remove(work);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool WorkExists(string id)
        {
            return _context.Work.Any(e => e.Id == id);
        }
    }
}

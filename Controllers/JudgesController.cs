using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aicupper.models;

namespace aicupper.Controllers
{
    [Route("api/[controller]")]
    public class JudgesController : Controller
    {
        private readonly dbContext _context;

        public JudgesController(dbContext context)
        {
            _context = context;
        }

        // GET: Judges
        public async Task<IActionResult> Index()
        {
            return View(await _context.Judges.ToListAsync());
        }

        [HttpGet("[action]")]
        public async  Task<IEnumerable<judge>> List()
        {
            return await _context.Judges.ToListAsync();
        }


        // GET: Judges/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var judge = await _context.Judges
                .FirstOrDefaultAsync(m => m.Id == id);
            if (judge == null)
            {
                return NotFound();
            }

            return View(judge);
        }

        // GET: Judges/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Judges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AICupperAccountID,JudgeName,KnownAs,EmailAddress,PhoneNumber,CreatedOn,IsEnabled")] judge judge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(judge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(judge);
        }

        // GET: Judges/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var judge = await _context.Judges.FindAsync(id);
            if (judge == null)
            {
                return NotFound();
            }
            return View(judge);
        }

        // POST: Judges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AICupperAccountID,JudgeName,KnownAs,EmailAddress,PhoneNumber,CreatedOn,IsEnabled")] judge judge)
        {
            if (id != judge.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(judge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!judgeExists(judge.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(judge);
        }

        // GET: Judges/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var judge = await _context.Judges
                .FirstOrDefaultAsync(m => m.Id == id);
            if (judge == null)
            {
                return NotFound();
            }

            return View(judge);
        }

        // POST: Judges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var judge = await _context.Judges.FindAsync(id);
            _context.Judges.Remove(judge);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool judgeExists(int id)
        {
            return _context.Judges.Any(e => e.Id == id);
        }
    }
}

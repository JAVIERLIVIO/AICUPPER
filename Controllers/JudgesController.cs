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
                .FirstOrDefaultAsync(m => m.JudgeID == id);
            if (judge == null)
            {
                return NotFound();
            }

            return View(judge);
        }

        // POST: Judges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody] judge judgeObject)
        {
            if( judgeObject.EmailAddress.Length == 0 )
                return BadRequest(new { Message = "Judge record cannot be created. Email is missing." });
            else if( judgeObject.JudgeName.Length == 0 )
                return BadRequest(new { Message = "Judge record cannot be created. Judge Name is missing." });
            else if( judgeObject.AICupperAccountID == null )
                return BadRequest(new { Message = "Judge record cannot be created. AICUPPER Account is missing." });
            else {
                try {
                    _context.Add(judgeObject);
                    await Task.Run(() => _context.SaveChangesAsync());
                    return Accepted(new { Message = "Judge record successfully created" });
                } catch (Exception ex) {
                    return StatusCode(500);
                }
            }
            // return NotFound(new { Message = "Judge record cannot be created. Email is missing." });
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
        public async Task<IActionResult> Edit(int id, [Bind("JudgeID,AICupperAccountID,JudgeName,KnownAs,EmailAddress,PhoneNumber,CreatedOn,IsEnabled")] judge judge)
        {
            if (id != judge.JudgeID)
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
                    if (!judgeExists(judge.JudgeID))
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
                .FirstOrDefaultAsync(m => m.JudgeID == id);
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
            return _context.Judges.Any(e => e.JudgeID == id);
        }
    }
}

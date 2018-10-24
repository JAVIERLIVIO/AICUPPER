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

        [HttpGet("[action]")]
        public async  Task<IEnumerable<judge>> List()
        {
            return await _context.Judges.ToListAsync();
        }

        [HttpGet("[action]/{id}")]
        // GET: Judges/Details/5
        public async Task<judge> Details(int id)
        {
            if (id <= 0)
                throw new KeyNotFoundException($"Invalid id: {id}.");

            var judge = await _context.Judges.FirstOrDefaultAsync(m => m.JudgeID == id);
            if (judge == null)
                throw new KeyNotFoundException($"No Judge with id: {id} was found.");

            return judge;
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
        }

        // PUT: Judges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] judge judge)
        {
            if (id <= 0)
                throw new KeyNotFoundException($"Invalid id: {id}.");

            if (id != judge.JudgeID)
                return NotFound(new { Message = $"Judge id: {id} does not match given data, id: {judge.JudgeID}." });

            try 
            {
                _context.Update(judge);
                await _context.SaveChangesAsync();
                return Accepted(new { Message = $"Judge record successfully updated id: {id}" });
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500);
            }
        }

        // GET: Judges/Delete/5
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                throw new KeyNotFoundException($"Invalid id: {id}.");

            var judge = await _context.Judges.FirstOrDefaultAsync(m => m.JudgeID == id);
            if (judge == null)
               return NotFound(new { Message = $"Judge id: {id} not found." });
            try
            {
                _context.Judges.Remove(judge);
                await _context.SaveChangesAsync();            
                return Accepted(new { Message = $"Judge record successfully deleted id: {id}" });
            }   
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500);
            }
        }
    }
}
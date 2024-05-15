using Finance.Data;
using Finance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finance.Controllers
{
    public class ColumnController : Controller
    {
        private readonly FinanceContext _context;

        public ColumnController(FinanceContext context)
        {
            _context = context;
        }

        // GET: Columns
        public async Task<IActionResult> Index()
        {
            return View(await _context.Columns.ToListAsync());
        }

        // POST: Columns/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Column column)
        {
            if (ModelState.IsValid)
            {
                _context.Add(column);
                await _context.SaveChangesAsync();
                return Json(column);
            }
            return BadRequest(ModelState);
        }

        // PUT: Columns/Edit/5
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Column column)
        {
            if (ModelState.IsValid)
            {
                _context.Update(column);
                await _context.SaveChangesAsync();
                return Json(column);
            }
            return BadRequest(ModelState);
        }

        // DELETE: Columns/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var column = await _context.Columns.FindAsync(id);
            if (column == null)
            {
                return NotFound();
            }

            _context.Columns.Remove(column);
            await _context.SaveChangesAsync();
            return Json(column);
        }
    }
}

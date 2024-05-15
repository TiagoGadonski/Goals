using Finance.Data;
using Finance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finance.Controllers
{
    public class CategoryController : Controller
    {
        private readonly FinanceContext _context;

        public CategoryController(FinanceContext context)
        {
            _context = context;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // POST: Categories/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return Json(category);
            }
            return BadRequest(ModelState);
        }

        // PUT: Categories/Edit/5
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Update(category);
                await _context.SaveChangesAsync();
                return Json(category);
            }
            return BadRequest(ModelState);
        }

        // DELETE: Categories/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return Json(category);
        }
    }
}

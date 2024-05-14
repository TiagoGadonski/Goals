using Finance.Data;
using Finance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finance.Controllers
{
    public class TaskItemController : Controller
    {
        private readonly FinanceContext _context;

        public TaskItemController(FinanceContext context)
        {
            _context = context;
        }

        // GET: TaskItems
        public async Task<IActionResult> Index()
        {
            var taskItems = await _context.TaskItems
                                          .Include(t => t.Column)
                                          .Include(t => t.Category)
                                          .ToListAsync();

            ViewBag.Columns = await _context.Columns.OrderBy(c => c.Id).ToListAsync();
            ViewBag.Categories = await _context.Categories.OrderBy(c => c.Id).ToListAsync();

            return View(taskItems);
        }

        // POST: TaskItems/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskItem taskItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskItem);
                await _context.SaveChangesAsync();
                return Json(taskItem);
            }
            return BadRequest(ModelState);
        }

        // PUT: TaskItems/Edit/5
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] TaskItem taskItem)
        {
            if (ModelState.IsValid)
            {
                _context.Update(taskItem);
                await _context.SaveChangesAsync();
                return Json(taskItem);
            }
            return BadRequest(ModelState);
        }

        // DELETE: TaskItems/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }

            _context.TaskItems.Remove(taskItem);
            await _context.SaveChangesAsync();
            return Json(taskItem);
        }
    }
}

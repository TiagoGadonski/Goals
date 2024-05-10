﻿using Finance.Data;
using Finance.Models;
using Finance.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Finance.Controllers
{
    namespace Finance.Controllers
    {
        public class TransactionController : Controller  // Ensure the class name ends with 'Controller'
        {
            private readonly FinanceContext _context;

            public TransactionController(FinanceContext context)
            {
                _context = context;
            }

            public async Task<IActionResult> Index()
            {
                var transactions = await _context.Transactions.Include(t => t.Category).ToListAsync();
                var categoryOptions = await _context.TransactionCategories
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                    .ToListAsync();

                var viewModel = new TransactionViewModel
                {
                    Transactions = transactions,
                    CategoryOptions = categoryOptions
                };

                return View(viewModel);
            }

            // GET: api/Transactions
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
            {
                return await _context.Transactions.Include(t => t.Category).ToListAsync();
            }

            // GET: api/Transactions/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Transaction>> GetTransaction(int id)
            {
                var transaction = await _context.Transactions.Include(t => t.Category).FirstOrDefaultAsync(t => t.Id == id);

                if (transaction == null)
                {
                    return NotFound();
                }

                return transaction;
            }

            // POST: api/Transactions
            [HttpPost]
            public async Task<ActionResult<Transaction>> PostTransaction(Transaction transaction)
            {
                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetTransaction), new { id = transaction.Id }, transaction);
            }

            // PUT: api/Transactions/5
            [HttpPut("{id}")]
            public async Task<IActionResult> PutTransaction(int id, Transaction transaction)
            {
                if (id != transaction.Id)
                {
                    return BadRequest();
                }

                _context.Entry(transaction).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }

            // DELETE: api/Transactions/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteTransaction(int id)
            {
                var transaction = await _context.Transactions.FindAsync(id);
                if (transaction == null)
                {
                    return NotFound();
                }

                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool TransactionExists(int id)
            {
                return _context.Transactions.Any(e => e.Id == id);
            }
        }
    }

}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.Models;

namespace PaymentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccsController : ControllerBase
    {
        private readonly paymentsystemContext _context;

        public AccsController(paymentsystemContext context)
        {
            _context = context;
        }

        // GET: api/Accs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acc>>> GetAcc()
        {
            return await _context.Acc.ToListAsync();
        }

        // GET: api/Accs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Acc>> GetAcc(int id)
        {
            var acc = await _context.Acc.FindAsync(id);

            if (acc == null)
            {
                return NotFound();
            }

            return acc;
        }

        // PUT: api/Accs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcc(int id, Acc acc)
        {
            if (id != acc.id_acc)
            {
                return BadRequest();
            }

            _context.Entry(acc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccExists(id))
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

        // POST: api/Accs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Acc>> PostAcc(Acc acc)
        {
            _context.Acc.Add(acc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcc", new { id = acc.id_acc }, acc);
        }

        // DELETE: api/Accs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Acc>> DeleteAcc(int id)
        {
            var acc = await _context.Acc.FindAsync(id);
            if (acc == null)
            {
                return NotFound();
            }

            _context.Acc.Remove(acc);
            await _context.SaveChangesAsync();

            return acc;
        }

        private bool AccExists(int id)
        {
            return _context.Acc.Any(e => e.id_acc == id);
        }
    }
}

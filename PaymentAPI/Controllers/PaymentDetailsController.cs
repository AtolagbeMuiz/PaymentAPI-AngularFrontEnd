using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailsController : ControllerBase
    {
        private readonly PaymentDetailsDBContext _context;

        public PaymentDetailsController(PaymentDetailsDBContext context)
        {
            _context = context;
        }

        // GET: api/PaymentDetails
        //[HttpGet("GetPaymentDetails")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetails>>> GetPaymentDetails()
        {
            //try
            //{
                return await _context.PaymentDetails.ToListAsync();
            //}
            //catch (Exception ex)
            //{
               // var mes = ex.Message.ToString();
           // }
        }

        // GET: api/PaymentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetails>> GetPaymentDetails(int id)
        {
            var paymentDetails = await _context.PaymentDetails.FindAsync(id);

            if (paymentDetails == null)
            {
                return NotFound();
            }

            return paymentDetails;
        }

        // PUT: api/PaymentDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentDetails(int id, PaymentDetails paymentDetails)
        {
            if (id != paymentDetails.PaymentID)
            {
                return BadRequest();
            }

            _context.Entry(paymentDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentDetailsExists(id))
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

        // POST: api/PaymentDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost("PostPaymentDetails")]

        [HttpPost]
        public async Task<ActionResult<PaymentDetails>> PostPaymentDetails(PaymentDetails paymentDetails)
        {
            try
            {
                _context.PaymentDetails.Add(paymentDetails);
                await _context.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {

                var res = ex.Message;
            }
            //return RedirectToAction("GetPaymentDetails");
            return CreatedAtAction("GetPaymentDetails", new { id = paymentDetails.PaymentID }, paymentDetails);
        }

        // DELETE: api/PaymentDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentDetails(int id)
        {
            var paymentDetails = await _context.PaymentDetails.FindAsync(id);
            if (paymentDetails == null)
            {
                return NotFound();
            }

            _context.PaymentDetails.Remove(paymentDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentDetailsExists(int id)
        {
            return _context.PaymentDetails.Any(e => e.PaymentID == id);
        }
    }
}

using BooksAndDot.Models;
using BooksAndDot.Models.DTO.Orders;
using BooksAndDot.Models.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndDot.Controllers.Orders {
    
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase {
        AppDbContext _context;
        public PaymentsController(AppDbContext context) {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDTO>>> GetPayments() {
            var payments = await _context.Payments.ToListAsync();
            List<PaymentDTO> result = new List<PaymentDTO>();
            foreach (var payment in payments) {
                result.Add(payment.PaymentExtension());
            }
            
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> SetPayment(PaymentDTO payDTO) {
            if (payDTO == null) {
                return BadRequest("Not correct payment");
            }

            _context.Payments.Add(payDTO.PaymentDTOExtension());
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePayment(PaymentDTO payDTO) {
            if (payDTO == null) {
                return BadRequest("Error payment");
            }
            Payment pay = _context.Payments
                .FirstOrDefault(p => p.PaymentId == payDTO.PaymentId);
            if (pay == null) {
                return NotFound();
            }

            pay.PaymentId = payDTO.PaymentId;
            pay.Sum = payDTO.Sum;
            pay.DatePayment = payDTO.DatePayment;
            _context.Payments.Update(pay);
            await _context.SaveChangesAsync();
            return Ok(pay.PaymentExtension());
        }
        


    }
}

using BooksAndDot.Models;
using BooksAndDot.Models.DTO.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAndDot.Controllers.Orders
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase {
        AppDbContext _context;
        public PaymentsController(AppDbContext context)
        {
            _context = context;
        }
        /*
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDTO>>> GetPayments() {
            return Ok(await _context.Payments.
                Where(p => p.UserId == 0).ToListAsync());
        }
        */
    }
}

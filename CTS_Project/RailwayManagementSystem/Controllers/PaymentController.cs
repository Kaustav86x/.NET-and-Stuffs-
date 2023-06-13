using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RailwayManagementSystem.Data;
using RailwayManagementSystem.Models.DbModels;
using RailwayManagementSystem.Models.AddModels;
using Microsoft.AspNetCore.Authorization;

namespace RailwayManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly RailwayDbContext _RailwayDbContext;

        public PaymentController(RailwayDbContext context)
        {
            _RailwayDbContext = context;
        }

        // GET: api/Payment/5
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> GetAllTransactions()
        {
            if (_RailwayDbContext.Payments == null)
            {
                return NotFound("No transactions being found in the database");
            }
            return Ok(_RailwayDbContext.Payments);
        }

        // PUT: api/Payment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> GetTransactionById(Guid id)
        {
            var pay = await _RailwayDbContext.Payments.FirstOrDefaultAsync(p => p.Id == id);
            if (pay == null)
            {
                return BadRequest("Transaction Id doesn't match");
            }
            else
                return Ok(pay);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> CreateTransaction([FromBody] AddPayment payment)
        {
            // var pay = _RailwayDbContext.Payments.
            var p = new Payment()
            {
                Id = Guid.NewGuid(),
                Date = payment.Date,
                Payment_method = payment.Payment_method,
                Payment_status = payment.Payment_status,
                Reservation_Id = payment.Reservation_Id,
            };
            await _RailwayDbContext.Payments.AddAsync(p);
            await _RailwayDbContext.SaveChangesAsync();
            return Ok("Payment addded successfully");
        }
    }
}

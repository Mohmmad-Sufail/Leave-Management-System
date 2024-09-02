using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Leave_Management_System.Models;

namespace Leave_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveDetailsController : ControllerBase
    {
        private readonly LeaveDetailsContext _context;
        private object config;

        public LeaveDetailsController(LeaveDetailsContext context)
        {
            _context = context;
        }


        [HttpGet]

        public async Task<ActionResult<IEnumerable<LeaveDetails>>> GetDetails()
        {
            var items = _context.LeaveDetails.ToList();
            if (items == null || items.Count == 0)
            {
                return NotFound("No Data Found");
            }
            return await _context.LeaveDetails.ToListAsync();
        }


        [HttpGet("{id}")]

        public async Task<ActionResult<LeaveDetails>> GetLeaveDetails(int id)
        {
            var leaveDetail = await _context.LeaveDetails.FindAsync(id);

            if (leaveDetail == null)
            {
                return NotFound("Data not Found");

            }

            return leaveDetail;
        }


        [HttpPut("{id}")]

        public async Task<IActionResult> PutPaymentDetail(int id, LeaveDetails leaveDetail)
        {
            if (id != leaveDetail.ID)
            {
                return BadRequest();
            }

            _context.Entry(leaveDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!LeaveDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw ex;
                }
            }

            return NoContent();
        }


        [HttpPost]

        public async Task<ActionResult<LeaveDetails>> PostLeaveDetails(LeaveDetails leaveDetail)
        {
            _context.LeaveDetails.Add(leaveDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeaveDetails", new { id = leaveDetail.ID }, leaveDetail);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<LeaveDetails>> DeleteLeaveDetails(int id)
        {
            var leaveDetail = await _context.LeaveDetails.FindAsync(id);
            if (leaveDetail == null)
            {
                return NotFound();
            }

            _context.LeaveDetails.Remove(leaveDetail);
            await _context.SaveChangesAsync();

            return leaveDetail;
        }

        private bool LeaveDetailsExists(int id)
        {
            return _context.LeaveDetails.Any(e => e.ID == id);
        }
    }
}

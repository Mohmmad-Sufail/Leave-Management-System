using Microsoft.EntityFrameworkCore;
using Leave_Management_System.Models;
using System.Collections.Generic;
namespace Leave_Management_System.Models
{
    public class LeaveDetailsContext : DbContext
    {
        public LeaveDetailsContext(DbContextOptions<LeaveDetailsContext> options) : base(options)
        {

        }
        public DbSet<LeaveDetails> LeaveDetails { get; set; }
    }
}

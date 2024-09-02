using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leave_Management_System.Models
{
    public class LeaveDetails
    {
        [Key]
        public int ID { get; set; }

        public int EmployeeID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string EmployeeName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string EmployeeEmail { get; set; }

        [Column(TypeName = "nvarchar(100)")]

        public string EmployeePhone { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Manager { get; set; }

        public int EmployeeAge { get; set; }

        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int Totaldays { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Reason { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Status { get; set; }


    }
}

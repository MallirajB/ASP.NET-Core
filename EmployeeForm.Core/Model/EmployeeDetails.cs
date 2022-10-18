using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Core.Model
{
    public class EmployeeDetails
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmployeeAddress { get; set; }
        public DateTime DateofJoining { get; set; }
        public int EmployeeAge { get; set; }
        public string? EmployeeWorkLocation { get; set; }
        public int EmployeeExperience { get; set; }
        public long? ContactNumber { get; set; }
        public string? CreatePassword { get; set; }
        public string? ConfirmPassword { get; set; }
        public string DateStr { get; set; }

    }
}
